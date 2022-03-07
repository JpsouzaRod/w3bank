using w3bank.Domain.Enums;

namespace w3bank.Domain.ValueObject
{
    public class Transacao
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