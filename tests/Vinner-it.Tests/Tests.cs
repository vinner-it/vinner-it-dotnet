using Vinner_it;

namespace UnitTests;

public class Tests
{
    [Fact]
    public void Fast_VIN_Should_Return_True_If_Valid()
    {
        var vinBuilder = new VinBuilder();
        
        var result = vinBuilder.FastVin("KNDPB3A21B7082471");

        Assert.True(result);
    }
    
    [Fact]
    public void Fast_VIN_Should_Return_False_If_Invalid()
    {
        var vinBuilder = new VinBuilder();
        
        var result = vinBuilder.FastVin("KB3A21B7082471");

        Assert.False(result);
    }
    
    [Fact]
    public void Fast_VIN_Should_Return_False_If_Null()
    {
        var vinBuilder = new VinBuilder();
        
        var result = vinBuilder.FastVin(null);

        Assert.False(result);
    }
    
}

