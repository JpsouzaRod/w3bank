using w3bank.Domain.ValueObject;

namespace w3bank.Domain.Interfaces
{
    public interface IServicoBancacarioRepository
    {
        public OutputData DepositarDinheiro (InputData conta);
        public OutputData SacarDinheiro(InputData conta);
    }
}