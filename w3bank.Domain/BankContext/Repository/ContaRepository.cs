using System;
using System.Collections.Generic;
using MongoDB.Driver;
using w3bank.Domain.BankContext.Entities;
using w3bank.Domain.BankContext.Interfaces;
using w3bank.Domain.BankContext.ValueObject;
using w3bank.Infra.Configurations;

namespace w3bank.Domain.BankContext.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly IMongoCollection<ProdutoConta> _conta;
        public ContaRepository(IDatabaseConfig config)
        {
            var client = new MongoClient(config.ConectionString);
            _conta = client.GetDatabase("w3bank").GetCollection<ProdutoConta>("ProdutoConta");
        }
        private ProdutoConta BuscarConta(int agencia, int conta)
        {
            var Conta = _conta.Find(x => x.Agencia == agencia && x.Conta == conta).FirstOrDefault();
            return Conta;
        }
        public Response ConsultarSaldo(Request conta)
        {
            var Conta = BuscarConta(conta.Agencia, conta.Conta);
            
            if(Conta != null)
                return new Response (true, "Operação feita com Sucesso", Conta);
            else
                return new Response (false, "Conta Inexistente", null); 
        }
        public Response CadastrarConta(Request conta)
        {
            var Conta = BuscarConta(conta.Agencia, conta.Conta);
            
            if(Conta != null)
                return new Response (false, "A conta já existe no Banco de Dados", Conta);
            else
            {
                var NovaConta = new ProdutoConta (conta.Agencia, conta.Conta);
                _conta.InsertOne(NovaConta);

                return new Response (true, "Conta criada com sucesso", NovaConta);
            }
        }

        public Response ConsultarExtrato(RequestExtrato conta)
        {
            var Conta = BuscarConta(conta.Agencia, conta.Conta);
            
            if(Conta != null)
            {
                var PeriodoExtrato = new List<Extrato>();

                if (conta.DataFinal >= conta.DataInicial)
                {
                    foreach (var extrato in Conta.Extratos)
                    {
                        if ((extrato.Data.Date >= conta.DataInicial) && (extrato.Data.Date <= conta.DataFinal))
                        {
                            PeriodoExtrato.Add(extrato);
                        }
                    }

                    if (PeriodoExtrato.Count>0)
                    {
                        Conta.Extratos = PeriodoExtrato;
                        return new Response(true, "Extrato da conta", Conta);
                    }
                    else
                    {
                        return new Response(true, "Extrato da conta", new { Message = "Extrato Vazio"});
                    }

                }
                else
                {
                    return new Response (false, "Periodo de pesquisa inválido", null);
                }
            }
            else
            {
                return new Response (false, "Conta Inexistente", null); 
            }
        }
    }
}