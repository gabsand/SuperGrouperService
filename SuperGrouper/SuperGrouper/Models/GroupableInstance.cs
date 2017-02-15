using MongoDB.Bson;

namespace SuperGrouper.Models
{
    public class GroupableInstance
    {
        public ObjectId Id { get; set; }
        public int? Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ObjectId GroupId { get; set; }
        public ObjectId GroupableTemplateId { get; set; }
        public ObjectId MemberId { get; set; }
        public string MemberName { get; set; }
    }
}