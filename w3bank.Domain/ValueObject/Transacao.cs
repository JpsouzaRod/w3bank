using w3bank.Domain.Enums;

namespace w3bank.Domain.ValueObject
{
    public class Transacao
    {
        public Transacao(CodigoTransacao codigo, string descricao, double valor)
        {
            Codigo = codigo;
            Descricao = descricao;
            Valor = valor;
        }
        public CodigoTransacao Codigo;
        public string Descricao;
        public double Valor;

        
    }
}