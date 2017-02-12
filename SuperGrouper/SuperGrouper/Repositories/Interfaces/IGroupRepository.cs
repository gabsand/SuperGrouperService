using System;
using SuperGrouper.Models;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Collections.Generic;

namespace SuperGrouper.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        Task<Group> SaveGroup(Group group);
        Task<Group> GetGroup(ObjectId groupObjectId);
        Task<List<GroupableFamily>>GetGroupableFamilies(ObjectId groupObjectId);
        Task<GroupableFamily> AddGroupableFamily(ObjectId groupObjectId, GroupableFamily groupableFamily);
    }
}