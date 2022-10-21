namespace APIOngMongo.Utils.Interface
{
    public interface IDatabaseSettings
    {
        string PessoaCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
