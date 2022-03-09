using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using w3bank.Domain.BankContext.Enums;

namespace w3bank.Domain.BankContext.Entities
{
    public class Transacao
    {
        public Transacao(CodigoTransacao codigo, string descricao, double natureza)
        {
            Codigo = codigo;
            Descricao = descricao;
            Natureza = natureza;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public CodigoTransacao Codigo {get; set;}
        public string Descricao {get; set;}
        public double Natureza {get; set;}
    }
}