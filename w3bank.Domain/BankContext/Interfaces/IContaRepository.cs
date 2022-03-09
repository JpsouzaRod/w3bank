using w3bank.Domain.BankContext.ValueObject;

namespace w3bank.Domain.BankContext.Interfaces
{
    public interface IContaRepository
    {
        public Response CadastrarConta (Request conta); 
        public Response ConsultarSaldo(Request conta);
        public Response ConsultarExtrato (RequestExtrato conta);
    }
}