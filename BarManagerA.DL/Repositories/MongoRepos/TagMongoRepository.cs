using BarManagerA.DL.Interfaces;
using BarManagerA.Models.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using Tag = BarManagerA.Models.DTO.Tag;

namespace BarManagerA.DL.Repositories.MongoRepos
{
    public class TagMongoRepository : ITagRepository
    {
        private readonly IMongoCollection<Tag> _tagCollection;


        public TagMongoRepository(IOptions<MongoDbConfiguration> config)
        {
            var client = new MongoClient(config.Value.ConnectionString);
            var database = client.GetDatabase(config.Value.DatabaseName);

            _tagCollection = database.GetCollection<Tag>("Tags");
        }

        public Tag Create(Tag userPosition)
        {
            _tagCollection.InsertOne(userPosition);
            return userPosition;
        }

        public void Delete(int id)
        {
            _tagCollection.DeleteOne(tag => tag.Id == id);
        }

        public IEnumerable<Tag> GetAll()
        {
            return _tagCollection.Find(tag => true).ToList();
        }

        public Tag GetById(int id) =>
            _tagCollection.Find(userPosition => userPosition.Id == id).FirstOrDefault();

        public Tag Update(Tag tag)
        {
            _tagCollection.ReplaceOne(tagToReplace => tagToReplace.Id == tag.Id, tag);
            return tag;
        }
    }
}
