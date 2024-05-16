using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Vinner_it;

public static class Vin
{
    public static bool IsValid(string? input) => ValidateVin(input);

    public static bool TryCreate(string? input, [NotNullWhen(true)]out VinType? vin)
    {

        if (ValidateVin(input))
        {
            vin = new VinType(input);
            return true;
        }

        vin = null;
        return false;
    }
    private static bool ValidateVin([NotNullWhen(true)]string? input)
    {
        try
        {
            return input is not null && Regex.IsMatch(input, @"^[A-HJ-NPR-Z0-9]{17}$", RegexOptions.None,
                TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
    }
}

public record VinType
{
    public string Vin { get; init; }

    internal VinType(string vin)
    {
        Vin = vin;
    }
}