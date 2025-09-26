using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Quark.Validations.Tests;

[Collection("Collection")]
public sealed class ValidationTests : FixturedUnitTest
{
    public ValidationTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
