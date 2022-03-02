using MongoDB.Driver;
using w3bank.Domain.Interfaces;
using w3bank.Domain.ValueObject;
using w3bank.Infra.Configurations;

namespace w3bank.Domain.Repository
{
    public class TransacaoBancariaRepository : ITransacaoBancariaRepository
    {
        private readonly IMongoCollection<ProdutoConta> _saldo;

        TransacaoBancariaRepository(IDatabaseConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            var database = client.GetDatabase(config.DatabaseName);

            _saldo = database.GetCollection<ProdutoConta>("ProdutoConta");
        }
        public double ConsultarSaldo(ProdutoConta conta)
        {
            var result = _saldo.Find(x => x.Conta == conta.Conta && x.Agencia == conta.Agencia).FirstOrDefault();
            return result.Saldo;
        }
    }
}