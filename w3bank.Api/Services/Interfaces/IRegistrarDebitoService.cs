using w3bank.Domain.ValueObject;

namespace w3bank.Api.Services.Interfaces
{
    public interface IRegistrarDebitoService
    {
        public OutputData DebitarConta(InputData conta);
        public void RegistrarTransacaoDebito(Transacao transacao);
        public void RegistrarLogTransacaoDebito(LogTransacao log);
    }
}