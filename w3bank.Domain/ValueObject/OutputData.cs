namespace w3bank.Domain.ValueObject
{
    public class OutputData
    {
        public OutputData(bool sucess, string message, object data)
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