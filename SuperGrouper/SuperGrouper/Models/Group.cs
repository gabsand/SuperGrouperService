using System.Collections.Generic;

namespace SuperGrouper.Models
{
    public class Group
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Groupable> Members { get; set; }
        public List<Partition> Partitions { get; set; }
        public Partition ParentPartition { get; set; }
    }
}