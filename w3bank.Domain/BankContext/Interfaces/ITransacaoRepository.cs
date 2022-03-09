using w3bank.Domain.BankContext.Entities;

namespace w3bank.Domain.BankContext.Interfaces
{
    public interface ITransacaoRepository
    {
        public void RegistrarTransacao(Transacao transacao); 
    }
}