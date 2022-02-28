using BarManagerA.DL.Interfaces;
using BarManagerA.Models.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Tag> Create(Tag userPosition)
        {
            await _tagCollection.InsertOneAsync(userPosition);

            return userPosition;
        }

        public async Task Delete(int id)
        {
            await _tagCollection.DeleteOneAsync(tag => tag.Id == id);
        }

        public async Task<IEnumerable<Tag>> GetAll()
        {
            var result = await _tagCollection.FindAsync(tag => true);

            return result.ToEnumerable();
        }

        public async Task<Tag> GetById(int id)
        {
            var result = await _tagCollection.FindAsync(userPosition => userPosition.Id == id);

            return result.FirstOrDefault();
        }

        public async Task<Tag> Update(Tag tag)
        {
            await _tagCollection.ReplaceOneAsync(tagToReplace => tagToReplace.Id == tag.Id, tag);
            return tag;
        }
    }
}
