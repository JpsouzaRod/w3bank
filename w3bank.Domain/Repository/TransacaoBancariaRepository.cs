using MongoDB.Driver;
using w3bank.Domain.Interfaces;
using w3bank.Domain.ValueObject;
using w3bank.Infra.Configurations;

namespace w3bank.Domain.Repository
{
    public class TransacaoBancariaRepository : ITransacaoBancariaRepository
    {
        private readonly IMongoCollection<ProdutoConta> _conta;

        public TransacaoBancariaRepository(IDatabaseConfig config)
        {
            var client = new MongoClient(config.ConectionString);
            _conta = client.GetDatabase("w3bank").GetCollection<ProdutoConta>("ProdutoConta");
        }

        public ProdutoConta BuscarConta(ProdutoConta conta)
        {
            var Conta = _conta.Find(x => x.Conta == conta.Conta && x.Agencia == conta.Agencia).FirstOrDefault();
            return Conta;        
        }

        public double ConsultarSaldo(ProdutoConta conta)
        {
            var Conta = BuscarConta(conta);
            
            if(Conta != null)
                return conta.Saldo;
            else
                return 0;     
        }

        public void CriarConta(ProdutoConta conta)
        {
            _conta.InsertOne(conta);
        }
    }
}