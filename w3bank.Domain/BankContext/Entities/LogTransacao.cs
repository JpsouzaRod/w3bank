using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using w3bank.Domain.BankContext.Enums;

namespace w3bank.Domain.BankContext.Entities
{
    public class LogTransacao
    {
        public LogTransacao(CodigoTransacao codigo, int agencia, int conta, double valor)
        {
            Data = DateTime.Now;
            Codigo = codigo;
            Agencia = agencia;
            Conta = conta;
            Valor = valor;
        }

        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime Data {get; set;}
        public CodigoTransacao Codigo {get; set;}
        public int Agencia {get; set;}
        public int Conta  {get; set;}
        public double Valor {get; set;}
    }
}