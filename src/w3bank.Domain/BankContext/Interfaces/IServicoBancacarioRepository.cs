using w3bank.Domain.BankContext.ValueObject;

namespace w3bank.Domain.BankContext.Interfaces
{
    public interface IServicoBancacarioRepository
    {
        public Response DepositarDinheiro (RequestTransacao conta);
        public Response SacarDinheiro(RequestTransacao conta);
    }
}