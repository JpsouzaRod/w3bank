using w3bank.Domain.BankContext.Entities;

namespace w3bank.Domain.BankContext.Interfaces
{
    public interface ITransacaoLogRepository
    {
        public void RegistrarLog(LogTransacao log); 

    }
}