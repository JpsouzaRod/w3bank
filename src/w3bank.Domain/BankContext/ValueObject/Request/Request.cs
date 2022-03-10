using w3bank.Domain.BankContext.Interfaces;

namespace w3bank.Domain.BankContext.ValueObject
{
    public class Request : RequestBase
    {
        public Request(int agencia, int conta)
        {
            Agencia = agencia;
            Conta = conta;
        }
    }
}