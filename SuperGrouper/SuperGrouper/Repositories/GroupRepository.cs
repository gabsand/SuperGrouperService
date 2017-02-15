using SuperGrouper.Repositories.Interfaces;
using SuperGrouper.Models;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

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

        public async Task<Group> GetGroup(ObjectId groupObjectId)
        {
            var filter = Builders<Group>.Filter.Eq("_id", groupObjectId);
            var group = await _groupCollection.Find(filter).SingleOrDefaultAsync();

            return group;
        }

        public async Task<List<Member>> AddMembers(ObjectId groupObjectId, List<Member> members)
        {
            var filter = Builders<Group>.Filter.Eq("_id", groupObjectId);
            var update = Builders<Group>.Update.AddToSetEach("Members", members);

            await _groupCollection.UpdateOneAsync(filter, update);

            return members;
        }
    }
}