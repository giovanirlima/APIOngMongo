using APIOngMongo.Models;
using APIOngMongo.Utils.Interface;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIOngMongo.Services
{
    public class PessoaServices
    {
        private readonly IMongoCollection<Pessoa> _pessoas;

        public PessoaServices(IDatabaseSettings settings)
        {
            var pessoa = new MongoClient(settings.ConnectionString);
            var database = pessoa.GetDatabase(settings.DatabaseName);
            _pessoas = database.GetCollection<Pessoa>(settings.PessoaCollectionName);
        }

        public async Task<List<Pessoa>> Get() => await _pessoas.Find(cliente => true).ToListAsync();

        public async Task<Pessoa> Get(string id) => await _pessoas.Find(pessoa => pessoa.Id == id).FirstOrDefaultAsync();

        public async Task Create(Pessoa pessoa) => await _pessoas.InsertOneAsync(pessoa);

        public async Task Put(string id, Pessoa pessoa) => await _pessoas.ReplaceOneAsync(pessoaIn => pessoaIn.Id == id, pessoa);

        public async Task Remove(string id) => await _pessoas.DeleteOneAsync(cliente => cliente.Id == id);     
    }
}
