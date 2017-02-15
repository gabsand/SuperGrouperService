using SuperGrouper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using SuperGrouper.Repositories.Interfaces;

namespace SuperGrouper.Repositories
{
    public class GroupableTemplatesRepository: BaseMongoRepository, IGroupableTemplatesRepository
    {
        protected static IMongoCollection<GroupableTemplate> _groupableTemplatesCollection;

        public GroupableTemplatesRepository(): base()
        {
            _groupableTemplatesCollection = _database.GetCollection<GroupableTemplate>("Groups");
        }
        public async Task<List<GroupableTemplate>> GetGroupableTemplates(ObjectId groupObjectId)
        {
            var filter = Builders<GroupableTemplate>.Filter.Eq("GroupId", groupObjectId);
            var groupableTemplates = await _groupableTemplatesCollection.Find(filter).ToListAsync();

            return groupableTemplates ?? new List<GroupableTemplate>();
        }
    }
}