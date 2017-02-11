using SuperGrouper.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SuperGrouper.Models;

namespace SuperGrouper.Repositories
{
    public class GroupRepository: IGroupRepository
    {
        public Group SaveGroup(Group group)
        {
            // save to MongoDB
            return group;
        }

        public Group GetGroup(Guid groupId)
        {
            // get group from MongoDB
            return new Group();
        }
    }
}