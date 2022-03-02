namespace w3bank.Domain.ValueObject
{
    public class ProdutoConta
    {
        public string Id { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public double Saldo { get; set; }
    }
}