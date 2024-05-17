using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

namespace Vinner_it;

public class VinBuilderProvider
{
    private ImmutableList<Func<string?, bool>> _validators =
        ImmutableList<Func<string?, bool>>.Empty;

    private Func<string, FastVin> Factory = FastVin.Create;

    public VinBuilderProvider ValidateRegex()
    {
        AddValidator(FastVin.IsValid);
        return this;
    }

    public VinBuilder Build() => VinBuilder.Create(Factory, _validators.Distinct().ToImmutableList());

    private void AddValidator(Func<string?, bool> validator) => _validators = _validators.Add(validator);
}

public class VinBuilder
{
    private readonly ImmutableList<Func<string?, bool>> _validators;
    private readonly Func<string, FastVin> _factory;

    private VinBuilder(Func<string, FastVin> factory, ImmutableList<Func<string?, bool>> validators)
    {
        _validators = validators;
        _factory = factory;
    }

    internal static VinBuilder Create(Func<string, FastVin> factory, ImmutableList<Func<string?, bool>> validators)
    {
        return new VinBuilder(factory, validators);
    }

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
    public bool TryCreate(string? input, [NotNullWhen(true)] out FastVin? vin)
    {
        if (Validate(input))
        {
            vin = _factory(input);
            return true;
        }

        vin = null;
        return false;
    }

    public bool Validate([NotNullWhen(true)] string? vin) => _validators.All(f => f(vin));
}