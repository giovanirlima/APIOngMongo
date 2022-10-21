using APIOngMongo.Utils.Interface;

namespace APIOngMongo.Utils
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string PessoaCollectionName { get; set; } 
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
