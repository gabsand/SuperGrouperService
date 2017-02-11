using System;
using SuperGrouper.Repositories.Interfaces;
using SuperGrouper.Models;
using MongoDB;
using MongoDB.Driver;

namespace SuperGrouper.Repositories
{
    public class GroupRepository: BaseMongoRepository, IGroupRepository
    {
        protected static IMongoCollection<Group> _groupCollection;

        public GroupRepository(): base()
        {
            _groupCollection = _database.GetCollection<Group>("Groups");
        }
        public Group SaveGroup(Group group)
        {
            _groupCollection.InsertOne(group);

            return group;
        }

        public Group GetGroup(Guid groupId)
        {
            var filter = Builders<Group>.Filter.Eq("Id", groupId.ToString());
            var group = _groupCollection.Find(filter).FirstOrDefault();

            return group;
        }
    }
}