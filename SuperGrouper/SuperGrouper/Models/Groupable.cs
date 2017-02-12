using MongoDB.Bson;

namespace SuperGrouper.Models
{
    public class Groupable
    {
        public ObjectId Id { get; set; }
        public int? Value { get; set; }
        public GroupableFamily GroupableFamily { get; set; }
        public ObjectId MemberId { get; set; }
        public string MemberName { get; set; }
    }
}