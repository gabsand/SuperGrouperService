using System.Collections.Generic;

namespace SuperGrouper.Models
{
    public class Partition
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> GroupIds { get; set; }
    }
}