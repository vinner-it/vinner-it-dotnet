using System.ComponentModel.DataAnnotations;
using System.Text.Json;
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
        var builder = new VinBuilderProvider().ValidateRegex().Build();

        var result = builder.Validate("test");
        var valid = builder.TryCreate("test", out var vin);

        Assert.False(result);
        Assert.False(valid);
        Assert.Null(vin);
    }

    [Fact]
    public void Validate_WithValidRegexVin_ShouldReturnTrue()
    {
        var builder = new VinBuilderProvider().ValidateRegex().Build();

        var result = builder.Validate("KNDPB3A21B7082471");
        var valid = builder.TryCreate("KNDPB3A21B7082471", out var vin);

        Assert.True(result);
        Assert.True(valid);
        Assert.NotNull(vin);
        Assert.NotEmpty(vin.Vin);
    }

    [Fact]
    public void ValidationAttribute_WithInvalidVin_ShouldReturnFalse()
    {
        var input = new TestClass()
        {
            VinString = "test"
        };
        var context = new ValidationContext(input);
        var validationErrors = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(input, context, validationErrors, true);

        Assert.False(isValid);

    }

    [Fact]
    public void ValidationAttribute_WithValidVin_ShouldReturnTrue()
    {

        var input = new TestClass()
        {
            VinString = "YS2PB3A21B7082471",
        };
        var context = new ValidationContext(input);
        var validationErrors = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(input, context, validationErrors, true);

        Assert.True(isValid);
    }

    [Fact]
    public void ValidationAttribute_WithOptionalVin_ShouldReturnTrue()
    {
        var input = new TestClass() { VinString = null };
        var validationErrors = new List<ValidationResult>();

        var result = Validator.TryValidateObject(input, new ValidationContext(input), validationErrors, true);
        
        Assert.True(result);
    }

    [Fact]
    public void ValidationAttribute_WithInvalidVin_WhenDeserializing_ShouldReturnFalse()
    {
        var json = """{"VinString":"YS2PB3A2IB7082471"}""";

        var result = JsonSerializer.Deserialize<TestClass>(json);

        var context = new ValidationContext(result, null);
        var validationErrors = new List<ValidationResult>();

        var isValid = Validator.TryValidateObject(result, context, validationErrors, true);

        Assert.NotNull(result);
        Assert.False(isValid);
        Assert.Single(validationErrors);
    }

}

public class TestClass
{
    [FastVin]
    public string? VinString { get; set; }
}
