using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using w3bank.Domain.Interfaces;
using w3bank.Domain.ValueObject;

namespace w3bank.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class BankController : ControllerBase
    {
        private readonly ITransacaoBancariaRepository _operacao;
        private readonly ILogger<BankController> _logger;

        public BankController(ITransacaoBancariaRepository operacao, ILogger<BankController> logger)
        {
            _operacao = operacao;
            _logger = logger;
        }

        [HttpPost]
        [Route("NovaConta")]
        public IActionResult CriarConta(ProdutoConta conta)
        {
            _operacao.CriarConta(conta);    
            return Ok();
        }
        [HttpGet]
        [Route("BuscarConta")]
        public IActionResult ConsultarConta(ProdutoConta conta)
        {
            var result = _operacao.BuscarConta(conta);
            
            if (result == null)
                return NotFound();            
            return Ok(result);
        }
    }
}
