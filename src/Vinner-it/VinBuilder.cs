using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Vinner_it;

public class VinBuilder
{
    private ImmutableList<Func<string?, bool>> _validators = ImmutableList<Func<string?, bool>>.Empty;

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

    public VinBuilder ValidateRegex()
    {
        AddValidator(FastVin.IsValid);
        return this;
    }

    public VinValidator Build() => VinValidator.Create(_validators);

    private void AddValidator(Func<string?, bool> validator) => _validators = _validators.Add(validator);
}

public class VinValidator
{

    private readonly ImmutableList<Func<string?, bool>> _validators;

    private VinValidator(ImmutableList<Func<string?, bool>> validators)
    {
        _validators = validators;
    }

    internal static VinValidator Create(ImmutableList<Func<string?, bool>> validators)
    {
        return new VinValidator(validators);
    }
    public bool Validate(string? vin) => _validators.All(f => f(vin));
}