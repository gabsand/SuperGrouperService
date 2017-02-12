using System;
using SuperGrouper.Models;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace SuperGrouper.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        Task<Group> SaveGroup(Group group);

        Task<Group> GetGroup(ObjectId groupObjectId);
    }
}