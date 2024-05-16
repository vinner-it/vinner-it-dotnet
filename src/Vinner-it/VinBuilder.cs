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

    public static bool TryParseVin(string? input, [NotNullWhen(true)] out FastVin? vin)
    {
        if (FastVin(input))
        {
            vin = Vinner_it.FastVin.Create(input);
            return true;
        }

        vin = null;
        return false;
    }
}

public record FastVin
{
    public string Vin { get; }

    private FastVin(string vin)
    {
        Vin = vin;
    }
    internal static FastVin Create(string vin)
    {
        // TODO: how do we make sure that serializers are not able to highjack validation-flow?
        if (!VinBuilder.FastVin(vin)) throw new ArgumentException($"Input {nameof(vin)} is not valid");
        return new FastVin(vin);
    }
}
