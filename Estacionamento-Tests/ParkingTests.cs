using Estacionamento.Alura.Estacionamento.Modelos;
using Estacionamento.Estacionamento.Modelos;
using Estacionamento.Modelos;

namespace Estacionamento_Tests;

public class ParkingTests : IDisposable
{
    private readonly Patio _patio = new();

    private readonly Attendant _attendant = new()
    {
        Name = "John"
    };

    private Veiculo _vehicle = new("Tiago")
    {
        Tipo = TipoVeiculo.Automovel,
        Cor = "Green",
        Modelo = "New Fiesta",
        Placa = "ABC-1234"
    };

    [Fact(DisplayName = "Valid billing parking.")]
    [Trait("Function", "Parking")]
    public void ValidBilling()
    {
        _patio.Attendant = _attendant;
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
    [Trait("Function", "Parking")]
    public void ValidBillingForManyVehicles(string property, string plate, string color, string model)
    {
        // Arrange
        _vehicle.Proprietario = property;
        _vehicle.Placa = plate;
        _vehicle.Cor = color;
        _vehicle.Modelo = model;

        _patio.Attendant = _attendant;
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
    [Trait("Function", "Parking")]
    public void LocateVehicleInParkingUsingIdTicket(string property, string plate, string color, string model)
    {
        // Arrange
        _vehicle.Proprietario = property;
        _vehicle.Placa = plate;
        _vehicle.Cor = color;
        _vehicle.Modelo = model;

        _patio.Attendant = _attendant;
        _patio.RegistrarEntradaVeiculo(_vehicle);
        
        // Act
        var search = _patio.SearchVehicle(_vehicle.IdTicket);
        
        // Assert
        Assert.Contains($"Identity: {_vehicle.IdTicket}", search.Ticket);
    }

    [Fact]
    [Trait("Function", "Parking")]
    public void ChangeVehicleData()
    {
        // Arrange
        _patio.Attendant = _attendant;
        _patio.RegistrarEntradaVeiculo(_vehicle);
        
        var vehicle = new Veiculo("Tiago")
        {
            Tipo = TipoVeiculo.Automovel,
            Cor = "Black",
            Modelo = "New Fiesta",
            Placa = "ABC-1234"
        };

        // Act
        var changed = _patio.ChangeVehicleData(vehicle);
        
        // Assert
        Assert.Equal(changed.Cor, _vehicle.Cor);

    }

    [Fact]
    [Trait("Function", "Parking")]
    public void CheckTicketGenerationInRecordVehicle()
    {
        
    }

    public void Dispose()
    {
        
    }
}