﻿using System;
using System.Collections.Generic;
using System.Linq;
using Estacionamento.Alura.Estacionamento.Modelos;
using Estacionamento.Modelos;

namespace Estacionamento.Estacionamento.Modelos
{
    public class Patio
    {
        public Patio()
        {
            Faturado = 0;
            veiculos = new List<Veiculo>();
        }

        private Attendant _attendantParking { get; set; }
        public Attendant Attendant
        {
            get => _attendantParking;
            set => _attendantParking = value;
        }

        private List<Veiculo> veiculos;
        private double faturado;

        public double Faturado
        {
            get => faturado;
            set => faturado = value;
        }

        public List<Veiculo> Veiculos
        {
            get => veiculos;
            set => veiculos = value;
        }

        public double TotalFaturado()
        {
            return this.Faturado;
        }

        public string MostrarFaturamento()
        {
            string totalfaturado = String.Format("Total faturado até o momento :::::::::::::::::::::::::::: {0:c}",
                this.TotalFaturado());
            return totalfaturado;
        }

        public void RegistrarEntradaVeiculo(Veiculo veiculo)
        {
            veiculo.HoraEntrada = DateTime.Now;
            TicketGenerate(veiculo);
            this.Veiculos.Add(veiculo);
        }

        public string RegistrarSaidaVeiculo(String placa)
        {
            Veiculo procurado = null;
            string informacao = string.Empty;

            foreach (Veiculo v in this.Veiculos)
            {
                if (v.Placa == placa)
                {
                    v.HoraSaida = DateTime.Now;
                    TimeSpan tempoPermanencia = v.HoraSaida - v.HoraEntrada;
                    double valorASerCobrado = 0;
                    if (v.Tipo == TipoVeiculo.Automovel)
                    {
                        /// o método Math.Ceiling(), aplica o conceito de teto da matemática onde o valor máximo é o inteiro imediatamente posterior a ele.
                        /// Ex.: 0,9999 ou 0,0001 teto = 1
                        /// Obs.: o conceito de chão é inverso e podemos utilizar Math.Floor();
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 2;
                    }

                    if (v.Tipo == TipoVeiculo.Motocicleta)
                    {
                        valorASerCobrado = Math.Ceiling(tempoPermanencia.TotalHours) * 1;
                    }

                    informacao = string.Format(" Hora de entrada: {0: HH: mm: ss}\n " +
                                               "Hora de saída: {1: HH:mm:ss}\n " +
                                               "Permanência: {2: HH:mm:ss} \n " +
                                               "Valor a pagar: {3:c}", v.HoraEntrada, v.HoraSaida,
                        new DateTime().Add(tempoPermanencia), valorASerCobrado);
                    procurado = v;
                    this.Faturado = this.Faturado + valorASerCobrado;
                    break;
                }
            }

            if (procurado != null)
            {
                this.Veiculos.Remove(procurado);
            }
            else
            {
                return "Não encontrado veículo com a placa informada.";
            }

            return informacao;
        }


        public Veiculo SearchVehicle(string idTicket)
        {
            var finded = (from veiculo in Veiculos where veiculo.IdTicket.Equals(idTicket) select veiculo)
                .SingleOrDefault();

            return finded;
        }

        public Veiculo ChangeVehicleData(Veiculo vehicle)
        {
            var vehicleTemp = (from veiculo in Veiculos where veiculo.Placa.Equals(vehicle.Placa) select veiculo)
                .SingleOrDefault();

            vehicleTemp?.ChangeData(vehicle);

            return vehicleTemp;
        }

        private string TicketGenerate(Veiculo veiculo)
        {
            veiculo.IdTicket = new Guid().ToString().Substring(0, 5);

            var ticket = "=== Ticket Parking ===\n" +
                         $"--- Identity: {veiculo.IdTicket}\n" +
                         $"--- Date/Hour entrance: {DateTime.Now}\n" +
                         $"--- Vehicle Plate: {veiculo.Placa}\n" +
                         $"--- Attendant parking:\n" +
                         $"---  - Name: {_attendantParking.Name}\n" +
                         $"---  - Registration: {_attendantParking.Registration}\n";

            veiculo.Ticket = ticket;

            return ticket;
        }
    }
}