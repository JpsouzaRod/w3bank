using System;
using w3bank.Domain.BankContext.Interfaces;
using w3bank.Domain.BankContext.ValueObject;

namespace w3bank.Domain.BankContext.ValueObject
{
    public class RequestExtrato : Request
    {
        public RequestExtrato(int agencia, int conta, string dataInicial, string dataFinal) : base(agencia, conta)
        {
            DataInicial = DateTime.Parse(dataInicial).Date;
            DataFinal = DateTime.Parse(dataFinal).Date;
        }
        
        public DateTime DataInicial {get; set;}
        public DateTime DataFinal {get; set;}
    }

}