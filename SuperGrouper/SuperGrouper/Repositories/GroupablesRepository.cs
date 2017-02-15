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
        public async Task<GroupableInstance> GetGroupableInstance(ObjectId groupableInstanceObjectId)
        {
            var filter = Builders<GroupableInstance>.Filter.Eq("_id", groupableInstanceObjectId);
            var groupableInstance = await _groupablesCollection.Find(filter).SingleOrDefaultAsync();

            return groupableInstance;
        }

        public async Task<GroupableInstance> SaveGroupableInstance(GroupableInstance groupableInstance)
        {
            await _groupablesCollection.InsertOneAsync(groupableInstance);

            return groupableInstance;
        }
    }
}