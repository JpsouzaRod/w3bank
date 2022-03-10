using w3bank.Domain.BankContext.Interfaces;
using w3bank.Domain.BankContext.ValueObject;

namespace w3bank.Domain.BankContext.ValueObject
{
    public class RequestTransacao : RequestBase
    {
        public RequestTransacao(int agencia, int conta, double valor)
        {
            Agencia = agencia;
            Conta = conta;
            Valor = valor;
        }
        public double Valor {get;set; }
    }

}