using LibrarieModele;

namespace NiveAccessDate_CodeFirst;

public interface ITopicsAccessor
{
    List<Topic> GetTopics();
    Topic? GetTopic(int id);
    void CreateTopic(Topic topic);
    void DeleteTopic(int id);
}
