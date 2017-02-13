using MongoDB.Bson;
using System.Collections.Generic;

namespace SuperGrouper.Models
{
    public class Partition
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public GroupableTemplate GroupableTemplate { get; set; }
        public List<ObjectId> GroupIds { get; set; }
        public ObjectId ParentGroupId { get; set; }
    }
}