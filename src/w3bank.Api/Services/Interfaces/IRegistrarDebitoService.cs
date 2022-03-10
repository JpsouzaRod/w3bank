using w3bank.Domain.BankContext.Entities;
using w3bank.Domain.BankContext.ValueObject;

namespace w3bank.Api.Services.Interfaces
{
    public interface IRegistrarDebitoService
    {
        public Response DebitarConta(RequestTransacao conta);
        public void RegistrarTransacaoDebito(RequestTransacao conta);
        public void RegistrarLog(RequestTransacao conta);
    }
}