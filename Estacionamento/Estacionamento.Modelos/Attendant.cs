using System;

namespace Estacionamento.Estacionamento.Modelos;

public class Attendant
{
    private string _registration { get; set; }
    private string _name { get; set; }
    public string Registration
    {
        get => _registration;
        private set => _registration = value;
    }
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public Attendant()
    {
        Registration = Guid.NewGuid().ToString()[..8];
    }

    public override string ToString()
    {
        return $"Attendant: {_name}\n" +
               $"Registration: {_registration}";
    }
}