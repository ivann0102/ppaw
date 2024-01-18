using LibrarieModele;

namespace NiveAccessDate_CodeFirst;

public interface IPostsAccessor
{
    Post? GetPostById(int id);
    List<Post> GetPostsByTopicId(int topicId);
    List<Post> GetPostsByUserId(int userId);
    List<Post> GetPosts();
    void CreatePost(Post post);
    void UpdatePost(int postId, Post newPost);
    void DeletePost(int postId);
    int CountPostImages(int postId);
    void AddImage(int postId, string imageLink);
    public List<Topic> GetTopics();
}
