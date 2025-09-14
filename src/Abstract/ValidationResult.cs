using System;
using Microsoft.AspNetCore.Components;
using Soenneker.Quark.Validations.Dtos;

namespace Soenneker.Quark.Validations.Abstract;

/// <summary>
/// Base class for validation result messages.
/// </summary>
public abstract class ValidationResult : ComponentBase, IDisposable
{
    private Validation? previousParentValidation;

    /// <summary>
    /// Gets or sets the reference to the parent validation.
    /// </summary>
    [CascadingParameter] protected Validation? ParentValidation { get; set; }

    /// <summary>
    /// Specifies the content to be rendered inside this validation result.
    /// </summary>
    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <inheritdoc/>
    protected override void OnParametersSet()
    {
        if (ParentValidation != previousParentValidation)
        {
            DetachValidationStatusChangedListener();
            if (ParentValidation != null)
            {
                ParentValidation.ValidationStatusChanged += OnValidationStatusChanged;
            }
            previousParentValidation = ParentValidation;
        }
    }

    private void DetachValidationStatusChangedListener()
    {
        if (previousParentValidation != null)
        {
            previousParentValidation.ValidationStatusChanged -= OnValidationStatusChanged;
        }
    }

    /// <summary>
    /// Handles validation status changes.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The event arguments.</param>
    protected virtual async void OnValidationStatusChanged(object? sender, ValidationStatusChangedEventArgs e)
    {
        await InvokeAsync(StateHasChanged);
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        DetachValidationStatusChangedListener();
        GC.SuppressFinalize(this);
    }
}
