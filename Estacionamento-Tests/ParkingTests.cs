using Estacionamento.Alura.Estacionamento.Modelos;
using Estacionamento.Modelos;

namespace Estacionamento_Tests;

public class ParkingTests
{
    private Patio _patio = new();

    private Veiculo _vehicle = new("Tiago")
    {
        Tipo = TipoVeiculo.Automovel,
        Cor = "Green",
        Modelo = "New Fiesta",
        Placa = "ABC-1234"
    };

    [Fact(DisplayName = "Valid billing parking.")]
    public void ValidBilling()
    {
        _patio.RegistrarEntradaVeiculo(_vehicle);
        _patio.RegistrarSaidaVeiculo(_vehicle.Placa);

        // Act
        var billing = _patio.TotalFaturado();

        // Assert
        Assert.Equal(2, billing);
    }

    [Theory]
    [InlineData("Tiago", "CFT-3469", "Black", "Kwid")]
    [InlineData("Rakel", "LAS-3098", "Yellow", "Ranger")]
    [InlineData("Peter", "JAO-1489", "Blue", "Troller")]
    public void ValidBillingForManyVehicles(string property, string plate, string color, string model)
    {
        // Arrange
        _vehicle.Proprietario = property;
        _vehicle.Placa = plate;
        _vehicle.Cor = color;
        _vehicle.Modelo = model;

        _patio.RegistrarEntradaVeiculo(_vehicle);
        _patio.RegistrarSaidaVeiculo(_vehicle.Placa);

        // Act
        var billing = _patio.TotalFaturado();

        // Assert
        Assert.Equal(2, billing);
    }
}