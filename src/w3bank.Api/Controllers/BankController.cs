using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using w3bank.Api.Services.Interfaces;
using w3bank.Domain.BankContext.Interfaces;
using w3bank.Domain.BankContext.    ValueObject;

namespace w3bank.Api.Controllers
{
    [ApiController]
    [Route("w3bank")]
    public class BankController : ControllerBase
    {
        private readonly IContaRepository _conta;
        private readonly IRegistrarCreditoService _credito;
        private readonly IRegistrarDebitoService _debito;
        private readonly ILogger<BankController> _logger;

        public BankController(ILogger<BankController> logger, IRegistrarCreditoService credito, IRegistrarDebitoService debito, IContaRepository conta)
        {
            _logger = logger;
            _credito = credito;
            _debito = debito;
            _conta = conta;
        }

        [HttpPost]
        [Route("Conta")]
        public IActionResult CriarConta([FromBody] Request conta)
        {
            var result = _conta.CadastrarConta(conta);
            if(result.Sucess)    
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        [Route("Saldo")]
        public IActionResult ConsultarSaldo([FromBody] Request conta)
        {
            var result = _conta.ConsultarSaldo(conta);
            if(result.Sucess)    
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpGet]
        [Route("Extrato")]
        public IActionResult ConsultarExtrato([FromBody] RequestExtrato conta)
        {
            var result = _conta.ConsultarExtrato(conta);
            if(result.Sucess)    
                return Ok(result);
            else
                return BadRequest(result);
        }


        [HttpPut]
        [Route("Deposito")]
        public IActionResult DepositarDinheiro(RequestTransacao conta)
        {
            var result = _credito.CreditarConta(conta);
            if(result.Sucess)    
                return Ok(result);
            else
                return BadRequest(result);        
        }

        [HttpPut]
        [Route("Saque")]
        public IActionResult SacarDinheiro(RequestTransacao conta)
        {
            var result = _debito.DebitarConta(conta);

            if(result.Sucess)    
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
