using MongoDB.Driver;
using w3bank.Domain.Interfaces;
using w3bank.Domain.ValueObject;
using w3bank.Infra.Configurations;

namespace w3bank.Domain.Repository
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