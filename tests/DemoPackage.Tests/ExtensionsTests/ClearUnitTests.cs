using DemoPackage.Extensions;
using FluentAssertions;
using System.Text.RegularExpressions;

namespace DemoPackage.Tests.ExtensionsTests;

public class ClearUnitTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    [Trait(nameof(StringExtensions), nameof(StringExtensions.Clear))]
    public void GivenAnEmptyText_WhenClearIsCalledWithThat_ShouldReturnEmptyString(string? text)
    {
        var result = text!.Clear();

        result.Should().BeEmpty();
    }

    [Theory]
    [InlineData("123456")]
    [InlineData("123.456.789-00")]
    [InlineData("Anything")]
    [Trait(nameof(StringExtensions), nameof(StringExtensions.Clear))]
    public void GivenAnyText_WhenClearIsCalled_ShouldReturnTheTextWithoutAnyNonNumericalCharactere(string? text)
    {
        var result = text!.Clear();

        result.Should().Be(new Regex(@"[^\d]").Replace(text!, ""));
    }
}