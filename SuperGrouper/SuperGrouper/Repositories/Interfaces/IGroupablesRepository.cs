using MongoDB.Bson;
using SuperGrouper.Models;
using System.Threading.Tasks;

namespace SuperGrouper.Repositories.Interfaces
{
    public interface IGroupablesRepository
    {
        Task<Groupable> SaveGroupable(Groupable groupable);
        Task<Groupable> GetGroupable(ObjectId groupableObjectId);
    }
}