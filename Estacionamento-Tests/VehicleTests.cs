using Estacionamento.Alura.Estacionamento.Modelos;
using Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Estacionamento_Tests;

public class VehicleTests : IDisposable
{
    private ITestOutputHelper TestOutputHelper { get; }

    private Veiculo _veiculoTest = new("Tiago")
    {
        Tipo = TipoVeiculo.Automovel,
        Cor = "Green",
        Modelo = "New Fiesta",
        Placa = "ABC-1234"
    };

    public VehicleTests(ITestOutputHelper testOutputHelper)
    {
        TestOutputHelper = testOutputHelper;
        TestOutputHelper.WriteLine("Testing console output.");
    }

    [Fact(DisplayName = "Testing vehicle acceleration")]
    [Trait("Function", "Vehicle")]
    public void TestVehicleAcelerate()
    {
        // Arrange

        // Act
        _veiculoTest.Acelerar(10);
        // Assert
        Assert.Equal(100, _veiculoTest.VelocidadeAtual);
    }

    [Fact(DisplayName = "Testing vehicle brake")]
    [Trait("Function", "Vehicle")]
    public void TestVehicleBrake()
    {
        // Arrange
        // Act
        _veiculoTest.Frear(10);
        // Assert
        Assert.Equal(-150, _veiculoTest.VelocidadeAtual);
    }


    [Fact(DisplayName = "Testing vehicle type")]
    [Trait("Function", "Vehicle")]
    public void TestTypeVehicle()
    {
        // Arrange
        // Act
        // Assert
        Assert.Equal(TipoVeiculo.Automovel, _veiculoTest.Tipo);
    }

    [Fact(Skip = "Test not implemented.")]
    [Trait("Function", "Vehicle")]
    public void ValidPropertyName()
    {
    }

    [Theory]
    [ClassData(typeof(Veiculo))]
    [Trait("Function", "Vehicle")]
    public void TestClassVehicle(Veiculo vehicle)
    {
        _veiculoTest.Acelerar(10);
        vehicle.Acelerar(10);

        Assert.Equal(vehicle.VelocidadeAtual, _veiculoTest.VelocidadeAtual);
    }

    [Fact]
    [Trait("Function", "Vehicle")]
    public void VehicleData()
    {
        var data = _veiculoTest.ToString();

        Assert.Contains("Vehicle type: Automovel", data!);
    }

    [Fact]
    [Trait("Function", "Vehicle")]
    public void CheckPropertyNameWithLessThenThreeCharacters()
    {
        var propertyName = "Ti";

        Assert.Throws<FormatException>(
            () => new Veiculo(propertyName)
        );
    }

    [Fact]
    [Trait("Function", "Vehicle")]
    public void CheckExceptionMessageOfFourthPlateCharacter()
    {
        var plate = "ABCD1234";

        var exception = Assert.Throws<FormatException>(
            () => new Veiculo().Placa = plate
        );
        
        Assert.Equal("O 4° caractere deve ser um hífen", exception.Message);
    }


    public void Dispose()
    {
    }
}