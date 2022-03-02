using w3bank.Domain.ValueObject;

namespace w3bank.Domain.Interfaces
{
    public interface ITransacaoBancariaRepository
    {
        public double ConsultarSaldo(ProdutoConta conta);
    }
}