using LibrarieModele;
using Microsoft.EntityFrameworkCore;
using Repository_CodeFirst;

namespace NiveAccessDate_CodeFirst;

public class PostsAccessor : IPostsAccessor
{
    private readonly ForumContext context;
    public PostsAccessor(ForumContext context)
    {
        this.context = context;
    }
    public Post? GetPostById(int id)
    {
        return context.Posts.FirstOrDefault(post => post.PostId == id);
    }

    public List<Post> GetPostsByTopicId(int topicId)
    {
        return context
            .Posts
            .Include(post => post.User)
            .Include(post => post.Topic)
            .Where(post => post.Topic.TopicId== topicId)
            .ToList();
    }

    public List<Post> GetPostsByUserId(int userId)
    {
        return context
            .Posts
            .Include(post => post.User)
            .Include(post => post.Topic)
            .Where(post => post.UserId == userId)
            .ToList();
    }

    public List<Post> GetPosts()
    {
        return context.Posts
          .Include(post => post.User)
          .Include(post => post.Topic)
          .Include(post => post.PostImages)
          .ToList();
    }

    public void CreatePost(Post post)
    {
        context.Posts.Add(post);
        context.SaveChanges();
    }

    public void UpdatePost(int postId, Post newPost)
    {
        var post = context.Posts.FirstOrDefault(p => p.PostId == postId);
        if (post != null)
        {
            post.Heading = newPost.Heading;
            post.PostText = newPost.PostText;
            post.PostDate = newPost.PostDate;
            post.TopicId = newPost.TopicId;
            post.UserId = newPost.UserId;
            post.ParentPostId = newPost.ParentPostId;
            context.SaveChanges();
        }
    }

    public void DeletePost(int postId)
    {
        var post = context.Posts.FirstOrDefault(p => p.PostId == postId);
        if (post != null)
        {
            context.Posts.Remove(post);
            context.SaveChanges();
        }
    }

    public int CountPostImages(int postId)
    {
        return context.PostImages.Count(pi => pi.PostId == postId);
    }

    public void AddImage(int postId, string imageLink)
    {
        context.PostImages.Add(
            new PostImage()
            {
                Link = imageLink,
                PostId = postId
            });
        context.SaveChanges();
    }

    public List<Topic> GetTopics()
    {
        return context.Topics.ToList();
    }
    

}
