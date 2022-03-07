using System;
using w3bank.Api.Services.Interfaces;
using w3bank.Domain.Enums;
using w3bank.Domain.Interfaces;
using w3bank.Domain.ValueObject;

namespace w3bank.Api.Services.USCServiceBank
{
    public class RegistrarDebitoService : IRegistrarDebitoService
    {
        private readonly IServicoBancacarioRepository _debito;
        private readonly ITransacaoRepository _registro;
        private readonly ITransacaoLogRepository _log;
        
        public RegistrarDebitoService(IServicoBancacarioRepository debito, ITransacaoRepository registro, ITransacaoLogRepository log)
        {
            _debito = debito;
            _registro = registro;
            _log = log;
        }
        public OutputData DebitarConta(InputData conta)
        { 
            if(conta.Valor <= 0)
                return new OutputData (false, "Error na operação", null);

            
            var result = _debito.SacarDinheiro(conta);

            if (result.Sucess)
            {
                var valor = (-1) * conta.Valor;

                var transacao = new Transacao(CodigoTransacao.DEBITO, "Saque", valor);
                RegistrarTransacaoDebito(transacao);

                var log = new LogTransacao(CodigoTransacao.DEBITO,conta.Agencia, conta.Conta, valor);
                RegistrarLogTransacaoDebito(log);
            }

            return result;
            
        }
        public void RegistrarTransacaoDebito(Transacao transacao)
        {
            _registro.RegistrarTransacao(transacao);
        }
        public void RegistrarLogTransacaoDebito(LogTransacao log)
        {
            _log.RegistrarLog(log);
        }

        
    }
}