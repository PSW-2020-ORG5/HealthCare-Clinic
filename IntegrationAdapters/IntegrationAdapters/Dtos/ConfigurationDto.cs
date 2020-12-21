namespace IntegrationAdapters.Dtos
{
    public class ConfigurationDto
    {
        public string myDbConnectionString { get; set; }

        private static ConfigurationDto instance = new ConfigurationDto();

        public static ConfigurationDto GetInstance()
        {
            return instance;
        }
    }
}
