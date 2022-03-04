using w3bank.Domain.ValueObject;

namespace w3bank.Domain.Interfaces
{
    public interface IOperacaoBancariaRepository
    {
        public ProdutoConta BuscarConta (InputData conta);
        public OutputData CriarConta (InputData conta);
        public OutputData ConsultarSaldo(InputData conta);
        public OutputData DepositarDinheiro (InputData conta);
        public OutputData SacarDinheiro(InputData conta);
    }
}