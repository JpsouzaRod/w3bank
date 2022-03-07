using w3bank.Domain.ValueObject;

namespace w3bank.Domain.ValueObject
{
    public class InputData : InputBase
    {
        public InputData (int agencia, int conta, double valor)
        {
            Agencia = agencia;
            Conta = conta;
            Valor = valor;
        }
        
        public double Valor {get;set; }
    }

}