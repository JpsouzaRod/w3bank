using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace w3bank.Domain.ValueObject
{
    public class ProdutoConta
    {
        public ProdutoConta(int agencia, int conta)
        {
            Agencia = agencia;
            Conta = conta;
            Saldo = 0;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public double Saldo { get; set; }
        public List<Transacao> Extrato { get; set; }

        public void CreditarConta(double valor)
        {
            Saldo = Saldo + valor;
        }
        public void DebitarConta(double valor)
        {
            Saldo = Saldo - valor;
        }

        
    }
}