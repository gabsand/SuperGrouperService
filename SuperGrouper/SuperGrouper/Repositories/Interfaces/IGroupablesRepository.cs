using MongoDB.Bson;
using SuperGrouper.Models;
using System.Threading.Tasks;

namespace SuperGrouper.Repositories.Interfaces
{
    public interface IGroupablesRepository
    {
        Task<GroupableInstance> SaveGroupableInstance(GroupableInstance groupableInstance);
        Task<GroupableInstance> GetGroupableInstance(ObjectId groupableObjectId);
    }
}