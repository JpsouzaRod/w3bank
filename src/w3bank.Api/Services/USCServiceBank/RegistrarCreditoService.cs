using w3bank.Api.Services.Interfaces;
using w3bank.Domain.BankContext.Entities;
using w3bank.Domain.BankContext.Enums;
using w3bank.Domain.BankContext.Interfaces;
using w3bank.Domain.BankContext.ValueObject;

namespace w3bank.Api.Services.USCServiceBank
{
    public class RegistrarCreditoService : IRegistrarCreditoService
    {
        private readonly IServicoBancacarioRepository _credito;
        private readonly ITransacaoRepository _registro;
        private readonly ITransacaoLogRepository _log;
        public RegistrarCreditoService(IServicoBancacarioRepository credito, ITransacaoRepository registro, ITransacaoLogRepository log)
        {
            _credito = credito;
            _registro = registro;
            _log = log;
        }
        public Response CreditarConta(RequestTransacao conta)
        {
            if(conta.Valor <= 0)
                return new Response (false, "Error na operação", null);

            var result = _credito.DepositarDinheiro(conta);

            if (result.Sucess)
            {
                RegistrarTransacaoCredito(conta);
            }

            return result;
        }
        public void RegistrarTransacaoCredito(RequestTransacao conta)
        {
            var transacao = new Transacao(CodigoTransacao.CREDITO, "Deposito", conta.Valor);
            _registro.RegistrarTransacao(transacao);
            
             RegistrarLog(conta);
        }
        public void RegistrarLog(RequestTransacao conta)
        {
            var log = new LogTransacao (CodigoTransacao.CREDITO, conta.Agencia, conta.Conta, conta.Valor);
            _log.RegistrarLog(log);
        }
    }
}