namespace w3bank.Infra.Configurations
{
    public class DatabaseConfig : IDatabaseConfig
    {
        public string DatabaseName { get; set; }
        public string ConectionString { get; set; }
    }
}