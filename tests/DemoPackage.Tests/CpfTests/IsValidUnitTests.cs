using FluentAssertions;

namespace DemoPackage.Tests.CpfTests;

public class IsValidUnitTests
{
    [Theory]
    [InlineData("123456789012")]
    [InlineData("12345678909")]
    [InlineData("123.456.789-09")]
    [InlineData("874.746.830-77")]
    [InlineData("102.553.980-39")]
    [InlineData("032.193.701-27")]
    [InlineData("844.331.890-23")]
    [InlineData("568.071.832-48")]
    [InlineData("033.150.477-48")]
    [InlineData("103.703.337-00")]
    [InlineData("777.777.777-77")]
    [Trait(nameof(CpfHelper), nameof(CpfHelper.IsValid))]
    public void GivenAnInvalidCPF_WhenIsValidIsCalled_ShouldReturnFalse(string cpf)
    {
        var result = CpfHelper.IsValid(cpf);

        result.Should().BeFalse();
    }

    [Theory]
    [InlineData("98765432100")]
    [InlineData("13.703.337-06")]
    [Trait(nameof(CpfHelper), nameof(CpfHelper.IsValid))]
    public void GivenAValidCpfNumber_WhenIsValidIsCalled_ShouldReturnTrue(string cpf)
    {
        var result = CpfHelper.IsValid(cpf);

        result.Should().BeTrue();
    }

}