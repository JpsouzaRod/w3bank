using w3bank.Domain.BankContext.Interfaces;

namespace w3bank.Domain.BankContext.ValueObject
{
    public class Request
    {
        public Request(int agencia, int conta)
        {
            Agencia = agencia;
            Conta = conta;
        }

        public int Agencia { get; set; }
        public int Conta {get; set;}
    }
}