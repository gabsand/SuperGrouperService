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
        Task<List<Member>> AddMembers(ObjectId groupObjectId, List<Member> members);
    }
}