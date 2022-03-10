using System;
using w3bank.Domain.BankContext.Interfaces;
using w3bank.Domain.BankContext.ValueObject;

namespace w3bank.Domain.BankContext.ValueObject
{
    public class RequestExtrato : RequestBase
    {
        public RequestExtrato(int agencia, int conta, string dataInicial, string dataFinal)
        {
            Agencia = agencia;
            Conta = conta;
            DataInicial = DateTime.Parse(dataInicial).Date;
            DataFinal = DateTime.Parse(dataFinal).Date;
        }
        
        public DateTime DataInicial {get; set;}
        public DateTime DataFinal {get; set;}
    }

}