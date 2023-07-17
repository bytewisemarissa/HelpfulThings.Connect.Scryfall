using System.Reflection;
using System.Runtime.Serialization;

namespace HelpfulThings.Connect.Scryfall;

public static class EnumExtensions
{
    public static string GetEnumValue<T>(this T value)
    {
        if (value is null)
        {
            throw new NullReferenceException("Value can not be null");
        }

        var enumValue = typeof(T)
            .GetTypeInfo()
            .DeclaredMembers
            .SingleOrDefault(x => x.Name == value.ToString())
            ?.GetCustomAttribute<EnumMemberAttribute>(false)
            ?.Value;
        return enumValue ?? "";
    }
}