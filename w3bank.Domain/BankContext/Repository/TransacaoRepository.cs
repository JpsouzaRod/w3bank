using MongoDB.Driver;
using w3bank.Domain.BankContext.Entities;
using w3bank.Domain.BankContext.Interfaces;
using w3bank.Domain.BankContext.ValueObject;
using w3bank.Infra.Configurations;

namespace w3bank.Domain.BankContext.Repository
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly IMongoCollection<Transacao> _registro;

        public TransacaoRepository(IDatabaseConfig config)
        {
            var client = new MongoClient(config.ConectionString);
            _registro = client.GetDatabase("w3bank").GetCollection<Transacao>("Transacao");
        }
        public void RegistrarTransacao(Transacao transacao)
        {
            _registro.InsertOne(transacao);
        }
    }
}