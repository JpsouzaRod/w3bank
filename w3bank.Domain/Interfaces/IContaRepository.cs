using w3bank.Domain.ValueObject;

namespace w3bank.Domain.Interfaces
{
    public interface IContaRepository
    {
        public OutputData CadastrarConta (InputData conta); 
        public OutputData ConsultarSaldo(InputData conta);
        public OutputData ConsultarExtrato (InputData conta);
    }
}