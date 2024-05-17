using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Vinner_it;

public record FastVin
{
    public string Vin { get; }

    internal static FastVin Create(string vin)
    {
        return new FastVin(vin);
    }

    private FastVin(string vin)
    {
        Vin = vin;
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

[AttributeUsage(validOn: AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
public class FastVinAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return DefaultValidation(value);
    }

    private static ValidationResult? DefaultValidation(object? value)
    {
        var isValid = value switch
        {
            string vin => FastVin.IsValid(vin),
            _ => true
        };

        return !isValid
            ? new ValidationResult("Invalid characters or length encountered")
            : ValidationResult.Success;
    }
}