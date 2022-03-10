using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using w3bank.Domain.BankContext.ValueObject;

namespace w3bank.Domain.BankContext.Entities
{
    public class ProdutoConta : Entity
    {
        public ProdutoConta(int agencia, int conta)
        {
            Agencia = agencia;
            Conta = conta;
            Saldo = 0;
            Extratos = new List<Extrato>();
        }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public double Saldo { get; set; }
        public List<Extrato> Extratos {get; set;}

        public void CreditarConta(double valor)
        {
            Saldo = Saldo + valor;
                RegistratExtrato(valor);
        }
        public void DebitarConta(double valor)
        {
            Saldo = Saldo - valor;
                RegistratExtrato((-1)*valor);
        }

        public void RegistratExtrato (double valor)
        {
            var registro = new Extrato(valor);
            Extratos.Add(registro);
        }

        
    }
}