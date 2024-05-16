using System.Text.RegularExpressions;

namespace Vinner_it;

public class VinBuilder
{
    public bool FastVin(string? vin)
    {
        if (vin is null) return false;
        
        var vinRegex = "^[A-HJ-NPR-Z0-9]{17}$";
        
        return Regex.Match(vin, vinRegex).Success;
    }
}

public class ValidVin
{
}