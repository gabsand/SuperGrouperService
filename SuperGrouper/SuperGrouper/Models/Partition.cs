using MongoDB.Bson;
using System.Collections.Generic;

namespace SuperGrouper.Models
{
    public class Partition
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Group> Subgroups { get; set; }
        public ObjectId GroupableTemplateId { get; set; }
        public ObjectId GroupId { get; set; }
    }
}