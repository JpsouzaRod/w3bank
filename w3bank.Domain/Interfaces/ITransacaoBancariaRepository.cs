using w3bank.Domain.ValueObject;

namespace w3bank.Domain.Interfaces
{
    public interface ITransacaoBancariaRepository
    {
        public void CriarConta (ProdutoConta conta);
        public ProdutoConta BuscarConta (ProdutoConta conta);
        public double ConsultarSaldo(ProdutoConta conta);
    }
}