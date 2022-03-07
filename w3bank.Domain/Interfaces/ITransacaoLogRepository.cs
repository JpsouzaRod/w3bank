using w3bank.Domain.ValueObject;

namespace w3bank.Domain.Interfaces
{
    public interface ITransacaoLogRepository
    {
        public void RegistrarLog(LogTransacao log); 

    }
}