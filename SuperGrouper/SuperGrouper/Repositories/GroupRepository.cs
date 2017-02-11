using System;
using SuperGrouper.Repositories.Interfaces;
using SuperGrouper.Models;
using MongoDB;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace SuperGrouper.Repositories
{
    public class GroupRepository: BaseMongoRepository, IGroupRepository
    {
        protected static IMongoCollection<Group> _groupCollection;

        public GroupRepository(): base()
        {
            _groupCollection = _database.GetCollection<Group>("Groups");
        }
        public async Task<Group> SaveGroup(Group group)
        {
            await _groupCollection.InsertOneAsync(group);

            return group;
        }

        public async Task<Group> GetGroup(Guid groupId)
        {
            var filter = Builders<Group>.Filter.Eq("Id", groupId.ToString());
            var group = await _groupCollection.Find(filter).FirstAsync();

            return group;
        }
    }
}