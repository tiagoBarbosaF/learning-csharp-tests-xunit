using System.Diagnostics.CodeAnalysis;
using Estacionamento.Alura.Estacionamento.Modelos;
using Estacionamento.Modelos;

namespace Estacionamento_Tests;

public class VehicleTests
{
    private Veiculo _veiculoTest = new();
    
    [Fact(DisplayName = "Testing vehicle acelerate")]
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
}