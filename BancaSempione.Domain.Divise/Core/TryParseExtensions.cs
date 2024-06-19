namespace BancaSempione.Domain.Divise.Core;

public static class TryParseExtensions
{
    public static bool TryParse(this string value, out decimal result)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            result = 0;
            return true;
        }

        return decimal.TryParse(value.Trim(), out result);
    }

    public static bool TryParse(this string? value, out int result)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            result = 0;
            return true;
        }

        return int.TryParse(value.Trim(), out result);
    }

    public static bool TryParse(this string value, out long result)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            result = 0;
            return true;
        }

        return long.TryParse(value.Trim(), out result);
    }

    public static bool TryParse(this string value, out DateTime result)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            result = default;
            return false;
        }

        return DateTime.TryParse(value.Trim(), out result);
    }

    public static decimal ParseToDecimal(this decimal? value)
    {
        return value == null ? 0m : Convert.ToDecimal(value);
    }

    public static decimal ParseToDecimal(this double? value)
    {
        return value == null ? 0m : Convert.ToDecimal(value);
    }

    public static bool ParseToBoolean(this decimal? value)
    {
        if (value == null)
            return false;

        if (value.Value == 1)
            return true;

        return false;
    }

    public static bool ParseToBoolean(this string value)
    {
        if (value == null)
            return false;

        if (value == "1")
            return true;

        return false;
    }

    public static string TrimOrEmpty(this string? value)
    {
        return value?.Trim() ?? String.Empty;
    }
}