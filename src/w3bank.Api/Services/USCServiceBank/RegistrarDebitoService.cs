using System;
using w3bank.Api.Services.Interfaces;
using w3bank.Domain.BankContext.Entities;
using w3bank.Domain.BankContext.Enums;
using w3bank.Domain.BankContext.Interfaces;
using w3bank.Domain.BankContext.ValueObject;

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
        public Response DebitarConta(RequestTransacao conta)
        { 
            if(conta.Valor <= 0)
                return new Response (false, "Error na operação", null);

            
            var result = _debito.SacarDinheiro(conta);

            if (result.Sucess)
            {
                conta.Valor = (-1) * conta.Valor;
                
                RegistrarTransacaoDebito(conta);
            }

            return result;
            
        }
        public void RegistrarTransacaoDebito(RequestTransacao conta)
        {
             var transacao = new Transacao(CodigoTransacao.DEBITO, "Saque", conta.Valor);
            _registro.RegistrarTransacao(transacao);
            
            var log = new LogTransacao (CodigoTransacao.DEBITO, conta.Agencia, conta.Conta, conta.Valor);
            _log.RegistrarLog(log);
        }
    }
}