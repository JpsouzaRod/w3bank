using w3bank.Domain.BankContext.Entities;
using w3bank.Domain.BankContext.ValueObject;

namespace w3bank.Api.Services.Interfaces
{
    public interface IRegistrarCreditoService
    {
        public Response CreditarConta(RequestTransacao conta);
        public void RegistrarTransacaoCredito(RequestTransacao conta);
    }
}