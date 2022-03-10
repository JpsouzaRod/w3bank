using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using w3bank.Domain.BankContext.Enums;

namespace w3bank.Domain.BankContext.Entities
{
    public class Transacao : Entity
    {
        public Transacao(CodigoTransacao codigo, string descricao, double natureza)
        {
            Codigo = codigo;
            Descricao = descricao;
            Natureza = natureza;
        }
        public CodigoTransacao Codigo {get; set;}
        public string Descricao {get; set;}
        public double Natureza {get; set;}
    }
}