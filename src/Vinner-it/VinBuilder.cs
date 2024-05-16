using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Vinner_it;

public class VinBuilder
{
    public static bool FastVin([NotNullWhen(true)] string? vin)
    {
        if (vin is null) return false;

        var vinRegex = "^[A-HJ-NPR-Z0-9]{17}$";

        try
        {
            return Regex.IsMatch(vin, vinRegex, RegexOptions.None, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
    }

    public static bool TryParseVin(string? input, [NotNullWhen(true)] out ValidVin? vin)
    {
        if (FastVin(input))
        {
            vin = new ValidVin(input);
            return true;
        }

        vin = null;
        return false;
    }
}

public record ValidVin
{
    public string Vin { get; init; }

    internal ValidVin(string vin)
    {
        // TODO: how do we make sure that serializers are not able to highjack validation-flow?
        if (!VinBuilder.FastVin(vin)) throw new ArgumentException("Input {0} is not a valid vin", nameof(vin));
        Vin = vin;
    }
}