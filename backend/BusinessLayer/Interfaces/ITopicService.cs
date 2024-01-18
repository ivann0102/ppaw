using LibrarieModele;
namespace BusinessLayer;
public interface ITopicService
{
    int Create(int userId, Topic topic);

    int Delete(int userId, int topicId);

    List<Topic> GetAll();

    Topic? Get(int id);
}