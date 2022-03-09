using System;
using MongoDB.Driver;
using w3bank.Domain.BankContext.Entities;
using w3bank.Domain.BankContext.Interfaces;
using w3bank.Domain.BankContext.ValueObject;
using w3bank.Infra.Configurations;

namespace w3bank.Domain.BankContext.Repository
{
    public class ServicoBancacarioRepository : IServicoBancacarioRepository
    {
        private readonly IMongoCollection<ProdutoConta> _conta;
        public ServicoBancacarioRepository(IDatabaseConfig config)
        {
            var client = new MongoClient(config.ConectionString);
            _conta = client.GetDatabase("w3bank").GetCollection<ProdutoConta>("ProdutoConta");
        }

        private ProdutoConta BuscarConta(int agencia, int conta)
        {
            var Conta = _conta.Find(x => x.Agencia == agencia && x.Conta == conta).FirstOrDefault();
            return Conta;
        }
        public Response DepositarDinheiro(RequestTransacao conta)
        {   
            var Conta = BuscarConta(conta.Agencia, conta.Conta);
            
            if(Conta != null)
            {
                Conta.CreditarConta(conta.Valor);

                _conta.ReplaceOne(conta => conta.Id == Conta.Id, Conta);
                
                return new Response (true, "Operação feita com Sucesso", Conta);
            }
            else
                return new Response (false, "Conta Inexistente", null);
        }

        public Response SacarDinheiro(RequestTransacao conta)
        {
            var Conta = BuscarConta(conta.Agencia, conta.Conta);
            
            if(Conta != null)
            {
                if(Conta.Saldo < conta.Valor)
                {
                    return new Response (false, "Saldo insuficiente para saque", Conta); 
                }
                else
                {
                    Conta.DebitarConta(conta.Valor);
                    _conta.ReplaceOne(conta => conta.Id == Conta.Id, Conta);
                    
                    return new Response (true, "Operação feita com Sucesso", Conta);
                }
            }
            else
                return new Response (false, "Conta Inexistente", null);        
        }
    }
}