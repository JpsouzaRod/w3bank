using MongoDB.Driver;
using w3bank.Domain.BankContext.Interfaces;
using w3bank.Domain.BankContext.Entities;
using w3bank.Infra.Configurations;

namespace w3bank.Domain.BankContext.Repository
{
    public class TransacaoLogRepository : ITransacaoLogRepository
    {
        private readonly IMongoCollection<LogTransacao> _logRegistro;

        public TransacaoLogRepository(IDatabaseConfig config)
        {
            var client = new MongoClient(config.ConectionString);
            _logRegistro = client.GetDatabase("w3bank").GetCollection<LogTransacao>("LogTransacao");
        }

        public void RegistrarLog(LogTransacao log)
        {
            _logRegistro.InsertOne(log);
        }
    }
}