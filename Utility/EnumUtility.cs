namespace Utility;

public static class EnumUtility
{
    // deduce enum value from its string represetnation (e.g. DeduceEnumFromString<Month>("jUnE") = Month.June)
    public static TEnum? DeduceEnumFromString<TEnum>(string? enumString) where TEnum : struct, Enum
    {
        if (enumString == null)
        {
            return null;
        }

        var enumStringUniform = enumString.Trim().ToLower();

        var enumValues = Enum.GetValues<TEnum>();
        foreach (var enumValue in enumValues)
        {
            if (enumValue.ToString().ToLower() == enumStringUniform)
            {
                return enumValue;
            }
        }

        return null;
    }
}
