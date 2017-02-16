
using MongoDB.Bson;
using SuperGrouper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperGrouper.Repositories.Interfaces
{
    public interface IGroupableTemplatesRepository
    {
        Task<GroupableTemplate> GetGroupableTemplate(ObjectId groupableObjectId);
        Task<GroupableTemplate> SaveGroupableTemplate(GroupableTemplate groupableTemplate);
        Task<List<GroupableTemplate>> GetGroupableTemplatesByGroupId(ObjectId groupObjectId);
    }
}