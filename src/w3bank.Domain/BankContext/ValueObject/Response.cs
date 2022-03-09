namespace w3bank.Domain.BankContext.ValueObject
{
    public class Response
    {
        public Response(bool sucess, string message, object data)
        {
            Sucess = sucess;
            Message = message;
            Data = data;
        }

        public bool Sucess { get; set;}
        public string Message { get; set;}
        public object Data { get; set; }
    }
}