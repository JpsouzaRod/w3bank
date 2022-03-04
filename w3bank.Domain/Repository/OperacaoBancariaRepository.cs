using System;
using MongoDB.Driver;
using w3bank.Domain.Interfaces;
using w3bank.Domain.ValueObject;
using w3bank.Infra.Configurations;

namespace w3bank.Domain.Repository
{
    public class OperacaoBancariaRepository : IOperacaoBancariaRepository
    {
        private readonly IMongoCollection<ProdutoConta> _conta;

        public OperacaoBancariaRepository(IDatabaseConfig config)
        {
            var client = new MongoClient(config.ConectionString);
            _conta = client.GetDatabase("w3bank").GetCollection<ProdutoConta>("ProdutoConta");
        }

        public ProdutoConta BuscarConta(InputData conta)
        {
            var Conta = _conta.Find(x => x.Conta == conta.Conta && x.Agencia == conta.Agencia).FirstOrDefault();
            return Conta;
        }

        public OutputData CriarConta(InputData conta)
        {
            var Conta = BuscarConta(conta);
            
            if(Conta != null)
                return new OutputData (false, "A conta já existe no Banco de Dados", Conta);
            else
            {
                var NovaConta = new ProdutoConta (conta.Agencia, conta.Conta);
                _conta.InsertOne(NovaConta);

                return new OutputData (true, "Conta criada com sucesso", NovaConta);
            }
        }
        public OutputData ConsultarSaldo(InputData conta)
        {
            var Conta = BuscarConta(conta);
            
            if(Conta != null)
                return new OutputData (true, "Operação feita com Sucesso", Conta.Saldo);
            else
                return new OutputData (false, "Conta Inexistente", null); 
        }

        public OutputData DepositarDinheiro(InputData conta)
        {   
            var Conta = BuscarConta(conta);
            
            if(Conta != null)
            {
                Conta.CreditarConta(conta.Valor);

                _conta.ReplaceOne(conta => conta.Id == Conta.Id, Conta);
                
                return new OutputData (true, "Operação feita com Sucesso", Conta);
            }
            else
                return new OutputData (false, "Conta Inexistente", null);
        }

        public OutputData SacarDinheiro(InputData conta)
        {
            var Conta = BuscarConta(conta);
            
            if(Conta != null)
            {
                if(Conta.Saldo < conta.Valor)
                {
                    return new OutputData (false, "Saldo insuficiente para saque", Conta); 
                }
                else
                {
                    Conta.DebitarConta(conta.Valor);
                    _conta.ReplaceOne(conta => conta.Id == Conta.Id, Conta);
                    
                    return new OutputData (true, "Operação feita com Sucesso", Conta);
                }
            }
            else
                return new OutputData (false, "Conta Inexistente", null);        
        }
    }
}