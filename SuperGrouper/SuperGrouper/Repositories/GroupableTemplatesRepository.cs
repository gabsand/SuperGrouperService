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
            _groupableTemplatesCollection = _database.GetCollection<GroupableTemplate>("GroupableTemplates");
        }

        public async Task<GroupableTemplate> GetGroupableTemplate(ObjectId groupableObjectId)
        {
            var filter = Builders<GroupableTemplate>.Filter.Eq("_id", groupableObjectId);
            var groupableTemplate = await _groupableTemplatesCollection.Find(filter).FirstOrDefaultAsync();

            return groupableTemplate;
        }

        public async Task<GroupableTemplate> SaveGroupableTemplate(GroupableTemplate groupableTemplate)
        {
            await _groupableTemplatesCollection.InsertOneAsync(groupableTemplate);

            return groupableTemplate;
        }

        public async Task<List<GroupableTemplate>> GetGroupableTemplatesByGroupId(ObjectId groupObjectId)
        {
            var filter = Builders<GroupableTemplate>.Filter.Eq("GroupId", groupObjectId);
            var groupableTemplates = await _groupableTemplatesCollection.Find(filter).ToListAsync();

            return groupableTemplates ?? new List<GroupableTemplate>();
        }
    }
}