using SuperGrouper.Repositories.Interfaces;
using SuperGrouper.Models;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson;

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

        public async Task<Group> GetGroup(string groupId)
        {
            var filter = Builders<Group>.Filter.Eq("_id", ObjectId.Parse(groupId));
            var group = await _groupCollection.Find(filter).SingleOrDefaultAsync();

            return group;
        }
    }
}