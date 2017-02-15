using MongoDB.Bson;
using SuperGrouper.Models;
using System.Threading.Tasks;

namespace SuperGrouper.Repositories.Interfaces
{
    public interface IGroupablesRepository
    {
        Task<GroupableInstance> SaveGroupable(GroupableInstance groupableInstance);
        Task<GroupableInstance> GetGroupable(ObjectId groupableObjectId);
    }
}