using w3bank.Domain.ValueObject;

namespace w3bank.Domain.Interfaces
{
    public interface ITransacaoRepository
    {
        public void RegistrarTransacao(Transacao transacao); 
    }
}