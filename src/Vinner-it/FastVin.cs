using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Vinner_it;

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
        return new FastVin(vin);
    }

    internal static bool IsValid([NotNullWhen(true)] string? vin)
    {
        if (vin is null) return false;

        try
        {
            return Regex.IsMatch(vin, "^[A-HJ-NPR-Z0-9]{17}$",
                RegexOptions.None, TimeSpan.FromMilliseconds(250));
        }
        catch (RegexMatchTimeoutException e)
        {
            return false;
        }
    }
}