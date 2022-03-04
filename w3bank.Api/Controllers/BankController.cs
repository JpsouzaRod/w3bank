using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using w3bank.Domain.Interfaces;
using w3bank.Domain.ValueObject;

namespace w3bank.Api.Controllers
{
    [ApiController]
    [Route("w3bank")]
    public class BankController : ControllerBase
    {
        private readonly IOperacaoBancariaRepository _operacao;
        private readonly ILogger<BankController> _logger;

        public BankController(IOperacaoBancariaRepository operacao, ILogger<BankController> logger)
        {
            _operacao = operacao;
            _logger = logger;
        }

        [HttpPost]
        [Route("Conta")]
        public IActionResult CriarConta([FromBody] InputData conta)
        {
            var result = _operacao.CriarConta(conta);
            if(result.Sucess)    
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPut]
        [Route("Deposito")]
        public IActionResult DepositarDinheiro(InputData conta)
        {
            var result = _operacao.DepositarDinheiro(conta);
            if(result.Sucess)    
                return Ok(result);
            else
                return BadRequest(result);        
        }

        [HttpPut]
        [Route("Saque")]
        public IActionResult SacarDinheiro(InputData conta)
        {
            var result = _operacao.SacarDinheiro(conta);

            if(result.Sucess)    
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
