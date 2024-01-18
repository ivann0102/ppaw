using LibrarieModele;
namespace BusinessLayer;
public interface IPostService
{
  int Create(int userId, Post post, List<string> images);
  int CreateImages(int userId, int postId, List<string> imageLinks);
  int Update(int userId, int postId, Post newPost);
  int Delete(int userId, int postId);
  int CountPostImages();
  List<Post> GetAll();
  List<Topic> GetTopics();
  List<Post> GetPostsByTopic(int topicId);
  Post? Get(int id);
}
