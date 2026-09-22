using System.Reflection;
using FluentAssertions;
using HelpfulThings.Connect.Scryfall.Enums;

namespace HelpfulThings.Connect.Scryfall.Tests;

public class EnumExtensionsTests
{
    private static IEnumerable<Enum> AllEnumValues() =>
        typeof(Colors).Assembly
            .GetTypes()
            .Where(t => t.IsEnum && t.Namespace == typeof(Colors).Namespace)
            .SelectMany(t => Enum.GetValues(t).Cast<Enum>());

    [TestCaseSource(nameof(AllEnumValues))]
    public void EveryEnumMember_HasANonEmptyEnumMemberValue(Enum value)
    {
        var enumValue = GetEnumValue(value);

        enumValue.Should().NotBeNullOrEmpty(
            $"{value.GetType().Name}.{value} should declare a non-empty [EnumMember] value");
    }

    private static string GetEnumValue(Enum value)
    {
        var method = typeof(EnumExtensions)
            .GetMethod(nameof(EnumExtensions.GetEnumValue))!
            .MakeGenericMethod(value.GetType());

        return (string)method.Invoke(null, [value])!;
    }
}
