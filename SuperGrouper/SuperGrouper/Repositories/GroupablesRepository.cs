using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using SuperGrouper.Models;
using SuperGrouper.Repositories.Interfaces;
using MongoDB.Driver;

namespace SuperGrouper.Repositories
{
    public class GroupablesRepository : BaseMongoRepository, IGroupablesRepository
    {
        protected static IMongoCollection<Groupable> _groupablesCollection;

        public GroupablesRepository(): base()
        {
            _groupablesCollection = _database.GetCollection<Groupable>("Groupables");
        }
        public async Task<Groupable> GetGroupable(ObjectId groupableObjectId)
        {
            var filter = Builders<Groupable>.Filter.Eq("_id", groupableObjectId);
            var groupable = await _groupablesCollection.Find(filter).SingleOrDefaultAsync();

            return groupable;
        }

        public async Task<Groupable> SaveGroupable(Groupable groupable)
        {
            await _groupablesCollection.InsertOneAsync(groupable);

            return groupable;
        }
    }
}