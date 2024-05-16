using Vinner_it;

namespace UnitTests;

public class Tests
{
    [Fact]
    public void Fast_VIN_Should_Return_True_If_Valid()
    {
        var vinBuilder = new VinBuilder();
        
        var result = VinBuilder.FastVin("KNDPB3A21B7082471");
        var tryResult = VinBuilder.TryParseVin("KNDPB3A21B7082471", out var vin);
        
        Assert.True(tryResult);
        Assert.NotNull(vin);
        Assert.NotEmpty(vin.Vin);
        Assert.True(result);
    }
    
    [Fact]
    public void Fast_VIN_Should_Return_False_If_Invalid()
    {
        
        var result = VinBuilder.FastVin("KB3A21B7082471");
        var tryCreat = VinBuilder.TryParseVin("KB3A21B7082471", out var vin);

        Assert.False(tryCreat);
        Assert.Null(vin);
        Assert.False(result);
    }
    
    [Fact]
    public void Fast_VIN_Should_Return_False_If_Null()
    {
        
        var result = VinBuilder.FastVin(null);
        var tryCreate = VinBuilder.TryParseVin(null, out var vin);

        Assert.False(tryCreate);
        Assert.Null(vin);
        Assert.False(result);
    }
}

