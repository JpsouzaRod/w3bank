namespace w3bank.Domain.BankContext.ValueObject
{
    public abstract class RequestBase
    {
        public int Agencia {get; set;}
        public int Conta  {get; set;}
    }
}