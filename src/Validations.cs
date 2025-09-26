using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Soenneker.Quark;

public sealed partial class Validations : ComponentBase
{
    private readonly List<IValidation> _validations = [];
    private EditContext? _editContext;
    private bool _hasSetEditContextExplicitly;

    [Parameter]
    public ValidationMode Mode { get; set; } = ValidationMode.Auto;

    [Parameter]
    public bool ValidateOnLoad { get; set; } = false;

    [Parameter]
    public EditContext? EditContext
    {
        get => _editContext;
        set
        {
            _editContext = value;
            _hasSetEditContextExplicitly = value is not null;
        }
    }

    [Parameter]
    public object? Model { get; set; }

    [Parameter]
    public EventCallback<object> ModelChanged { get; set; }

    [Parameter]
    public string? MissingFieldsErrorMessage { get; set; }

    [Parameter]
    public Type? HandlerType { get; set; }

    [Parameter]
    public EventCallback ValidatedAll { get; set; }

    [Parameter]
    public EventCallback<ValidationsStatusChangedEventArgs> StatusChanged { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    internal event Action<ValidationsStatusChangedEventArgs>? _statusChanged;

    protected override void OnParametersSet()
    {
        if (_hasSetEditContextExplicitly && Model is not null)
            throw new InvalidOperationException("Validations requires a Model parameter, or an EditContext parameter, but not both.");

        if (Model is not null && !ReferenceEquals(Model, _editContext?.Model))
            _editContext = new EditContext(Model);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && ValidateOnLoad && Mode == ValidationMode.Auto)
        {
            await Validate();
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    public async Task<bool> Validate()
    {
        bool result = await TryValidate();

        if (result)
        {
            RaiseStatusChanged(ValidationStatus.Success, null, null);
            await InvokeAsync(() => ValidatedAll.InvokeAsync());
        }
        else if (HasFailedValidations)
        {
            RaiseStatusChanged(ValidationStatus.Error, FailedValidations, null);
        }

        return result;
    }

    public Task ClearAll()
    {
        ClearingAll?.Invoke();
        RaiseStatusChanged(ValidationStatus.None, null, null);
        return Task.CompletedTask;
    }

    private async Task<bool> TryValidate()
    {
        var validated = true;

        foreach (IValidation v in _validations)
        {
            if (await v.ValidateAsync() == ValidationStatus.Error)
                validated = false;
        }

        return validated;
    }

    public void NotifyValidationInitialized(IValidation validation)
    {
        if (!_validations.Contains(validation))
            _validations.Add(validation);
    }

    public void NotifyValidationRemoved(IValidation validation)
    {
        if (_validations.Contains(validation))
            _validations.Remove(validation);
    }

    public void NotifyValidationStatusChanged(IValidation validation)
    {
        if (Mode == ValidationMode.Manual)
            return;

        if (AllValidationsSuccessful)
        {
            RaiseStatusChanged(ValidationStatus.Success, null, validation);
            ValidatedAll.InvokeAsync();
        }
        else if (HasFailedValidations)
        {
            RaiseStatusChanged(ValidationStatus.Error, FailedValidations, validation);
        }
        else
        {
            RaiseStatusChanged(ValidationStatus.None, null, validation);
        }
    }

    private void RaiseStatusChanged(ValidationStatus status, IReadOnlyCollection<string>? messages, IValidation? validation)
    {
        var args = new ValidationsStatusChangedEventArgs(status, messages, validation);
        _statusChanged?.Invoke(args);
        InvokeAsync(() => StatusChanged.InvokeAsync(args));
    }

    public bool AllValidationsSuccessful => _validations.All(x => x.Status == ValidationStatus.Success);
    public bool HasFailedValidations => _validations.Any(x => x.Status == ValidationStatus.Error);

    private IReadOnlyCollection<string> FailedValidations => _validations.Where(x => x.Status == ValidationStatus.Error && x.Messages?.Any() == true)
        .SelectMany(x => x.Messages!)
        .Concat(_validations.Any(v => v.Status == ValidationStatus.Error && (v.Messages is null || !v.Messages.Any()) && !_validations
            .Where(v2 => v2.Status == ValidationStatus.Error && v2.Messages?.Any() == true)
            .Contains(v))
            ? new string[] { MissingFieldsErrorMessage ?? "One or more fields have an error." }
            : Array.Empty<string>())
        .ToList();

    public event Action? ClearingAll;
}