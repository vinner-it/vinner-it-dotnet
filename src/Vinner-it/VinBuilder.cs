using System.Diagnostics.CodeAnalysis;

namespace Vinner_it;

public class VinBuilder
{
    public static bool TryParseVin(string? input, [NotNullWhen(true)] out FastVin? vin)
    {
        if (FastVin.IsValid(input))
        {
            vin = FastVin.Create(input);
            return true;
        }

        vin = null;
        return false;
    }
}