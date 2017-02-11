using SuperGrouper.Models;

namespace SuperGrouper.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        Group SaveGroup(Group group);

        Group GetGroup(string groupId);
    }
}