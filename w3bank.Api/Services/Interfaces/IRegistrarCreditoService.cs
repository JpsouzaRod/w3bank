using w3bank.Domain.ValueObject;

namespace w3bank.Api.Services.Interfaces
{
    public interface IRegistrarCreditoService
    {
        public OutputData CreditarConta(InputData conta);
        public void RegistrarTransacaoCredito(Transacao transacao);
        public void RegistrarLogTransacaoCredito(LogTransacao log);
    }
}