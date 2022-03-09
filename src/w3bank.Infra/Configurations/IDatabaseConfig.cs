namespace w3bank.Infra.Configurations
{
    public interface IDatabaseConfig
    {
        public string DatabaseName { get; set; }
        public string ConectionString { get; set; }
    }
}