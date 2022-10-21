using MongoDB.Bson.Serialization.Attributes;
using System;

namespace APIOngMongo.Models
{
    public class Pessoa
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
        public Animal Animal { get; set; }
    }
}
