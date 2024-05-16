using Vinner_it;

namespace UnitTests;

public class VinBuilderTests
{
    [Fact]
    public void Fast_VIN_Should_Return_True_If_Valid()
    {
        var tryResult = VinBuilder.TryParseVin("KNDPB3A21B7082471", out var vin);
        
        Assert.True(tryResult);
        Assert.NotNull(vin);
        Assert.NotEmpty(vin.Vin);
    }
    
    [Fact]
    public void Fast_VIN_Should_Return_False_If_Invalid()
    {
        
        var tryCreat = VinBuilder.TryParseVin("KB3A21B7082471", out var vin);

        Assert.False(tryCreat);
        Assert.Null(vin);
    }
    
    [Fact]
    public void Fast_VIN_Should_Return_False_If_Null()
    {
        
        var tryCreate = VinBuilder.TryParseVin(null, out var vin);

        Assert.False(tryCreate);
        Assert.Null(vin);
    }
}

