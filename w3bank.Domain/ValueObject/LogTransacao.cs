using System;
using w3bank.Domain.Enums;

namespace w3bank.Domain.ValueObject
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
        public DateTime Data {get; set;}
        public CodigoTransacao Codigo {get; set;}
        public int Agencia {get; set;}
        public int Conta  {get; set;}
        public double Valor {get; set;}
    }
}