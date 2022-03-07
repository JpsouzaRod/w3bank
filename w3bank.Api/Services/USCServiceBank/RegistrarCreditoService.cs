using w3bank.Api.Services.Interfaces;
using w3bank.Domain.Enums;
using w3bank.Domain.Interfaces;
using w3bank.Domain.ValueObject;

namespace w3bank.Api.Services.USCServiceBank
{
    public class RegistrarCreditoService : IRegistrarCreditoService
    {
        private readonly IServicoBancacarioRepository _credito;
        private readonly ITransacaoRepository _registro;
        private readonly ITransacaoLogRepository _log;
        public CodigoTransacao Codigo;
        public RegistrarCreditoService(IServicoBancacarioRepository credito, ITransacaoRepository registro, ITransacaoLogRepository log)
        {
            _credito = credito;
            _registro = registro;
            _log = log;
            Codigo = new CodigoTransacao();
        }

        public OutputData CreditarConta(InputData conta)
        {
            var transacao = new Transacao(CodigoTransacao.CREDITO, "Deposito", conta.Valor);
            RegistrarTransacaoCredito(transacao);

            var log = new LogTransacao(CodigoTransacao.CREDITO,conta.Agencia, conta.Conta, conta.Valor);
            RegistrarLogTransacaoCredito(log);

            return _credito.DepositarDinheiro(conta);
        }  
        public void RegistrarTransacaoCredito(Transacao transacao)
        {
           _registro.RegistrarTransacao(transacao);
        }
        public void RegistrarLogTransacaoCredito(LogTransacao log)
        {
             _log.RegistrarLog(log);
        }

        
    }
}