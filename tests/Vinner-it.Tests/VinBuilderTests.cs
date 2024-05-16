using Vinner_it;

namespace UnitTests;

public class VinBuilderTests
{
    [Fact]
    public void Fast_VIN_Should_Return_True_If_Valid()
    {
        var result = VinBuilder.TryParseVin("KNDPB3A21B7082471", out var vin);
        
        Assert.True(result);
        Assert.NotNull(vin);
        Assert.NotEmpty(vin.Vin);
    }
    
    [Fact]
    public void Fast_VIN_Should_Return_False_If_Invalid()
    {
        
        var result = VinBuilder.TryParseVin("KB3A21B7082471", out var vin);

        Assert.False(result);
        Assert.Null(vin);
    }
    
    [Fact]
    public void Fast_VIN_Should_Return_False_If_Null()
    {
        
        var tryCreate = VinBuilder.TryParseVin(null, out var vin);

        Assert.False(tryCreate);
        Assert.Null(vin);
    }

    [Fact]
    public void Validate_WithRegex_ShouldReturnFalse()
    {
        var builder = new VinBuilder().ValidateRegex().Build();

        var result = builder.Validate("test");
        
        Assert.False(result);
    }

    [Fact]
    public void Validate_WithValidRegexVin_ShouldReturnTrue()
    {
        var builder = new VinBuilder().ValidateRegex().Build();

        var result = builder.Validate("KNDPB3A21B7082471");
        
        Assert.True(result);
    }
}
