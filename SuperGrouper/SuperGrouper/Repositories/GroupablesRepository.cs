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
        protected static IMongoCollection<GroupableInstance> _groupablesCollection;

        public GroupablesRepository(): base()
        {
            _groupablesCollection = _database.GetCollection<GroupableInstance>("Groupables");
        }
        public async Task<GroupableInstance> GetGroupable(ObjectId groupableObjectId)
        {
            var filter = Builders<GroupableInstance>.Filter.Eq("_id", groupableObjectId);
            var groupable = await _groupablesCollection.Find(filter).SingleOrDefaultAsync();

            return groupable;
        }

        public async Task<GroupableInstance> SaveGroupable(GroupableInstance groupableInstance)
        {
            await _groupablesCollection.InsertOneAsync(groupableInstance);

            return groupableInstance;
        }
    }
}