
using MongoDB.Bson;
using SuperGrouper.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperGrouper.Repositories.Interfaces
{
    public interface IGroupableTemplatesRepository
    {
        Task<List<GroupableTemplate>> GetGroupableTemplates(ObjectId groupObjectId);
    }
}