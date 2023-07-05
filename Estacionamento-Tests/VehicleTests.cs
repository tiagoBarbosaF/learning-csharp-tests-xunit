using Estacionamento.Alura.Estacionamento.Modelos;
using Estacionamento.Modelos;

namespace Estacionamento_Tests;

public class VehicleTests
{
    private Veiculo _veiculoTest = new();
    
    [Fact(DisplayName = "Testing vehicle acceleration")]
    [Trait("Function", "Accelerate")]
    public void TestVehicleAcelerate()
    {
        // Arrange
        // var vehicle = new Veiculo();
        // Act
        _veiculoTest.Acelerar(10);
        // Assert
        Assert.Equal(100, _veiculoTest.VelocidadeAtual);
    }

    [Fact(DisplayName = "Testing vehicle brake")]
    [Trait("Function", "Brake")]
    public void TestVehicleBrake()
    {
        // Arrange
        // var vehicle = new Veiculo();
        // Act
        _veiculoTest.Frear(10);
        // Assert
        Assert.Equal(-150, _veiculoTest.VelocidadeAtual);
    }


    [Fact(DisplayName = "Testing vehicle type")]
    public void TestTypeVehicle()
    {
        // Arrange
        // Act
        // Assert
        Assert.Equal(TipoVeiculo.Automovel, _veiculoTest.Tipo);
    }

    [Fact(Skip = "Test not implemented.")]
    public void ValidPropertyName()
    {
        
    }

    [Theory]
    [ClassData(typeof(Veiculo))]
    public void TestClassVehicle(Veiculo vehicle)
    {
        _veiculoTest.Acelerar(10);
        vehicle.Acelerar(10);
        
        Assert.Equal(vehicle.VelocidadeAtual, _veiculoTest.VelocidadeAtual);
    }
}