using System;

namespace w3bank.Domain.BankContext.ValueObject
{
    public class Extrato
    {
        public Extrato(double valor)
        {
            Data = DateTime.Now;
            Valor = valor;
        }

        public DateTime Data {get; set;}
        public double Valor {get; set; }
    }
}