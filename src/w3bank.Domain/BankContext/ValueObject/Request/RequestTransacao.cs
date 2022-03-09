using w3bank.Domain.BankContext.Interfaces;
using w3bank.Domain.BankContext.ValueObject;

namespace w3bank.Domain.BankContext.ValueObject
{
    public class RequestTransacao : Request
    {
        public RequestTransacao(int agencia, int conta, double valor) : base(agencia, conta)
        {
            Valor = valor;
        }

        public double Valor {get;set; }
    }

}