using NiveAccessDate_CodeFirst;
using LibrarieModele;
using System.Text.RegularExpressions;


namespace BusinessLayer;

public class PostService : IPostService
{
    private readonly IPostsAccessor postsAccessor;
    private readonly IUserService userService;
    private readonly ICache cacheManager;
    public PostService(IPostsAccessor postsAccessor, IUserService userService, ICache cacheManager)
    {
        this.postsAccessor = postsAccessor;
        this.userService = userService;
        this.cacheManager = cacheManager;
    }

    private bool IsAlloweNumberOfPosts(int userId, int imageCount)
    {
        string authType = userService.GetUserAuthType(userId);

        int maxCount = 0;

        if (userId == -1)
            maxCount = 1;

        if (authType == "Registered")
            maxCount = 3;

        if (authType == "EmailVerified")
            maxCount = 5;

        return imageCount <= maxCount;
    }

    private bool HasBadWords(string text)
    {
        // List of discriminatory words
        string[] discriminatoryWords = { "word1", "word2", "word3" }; // Add your discriminatory words here

        // Create the regular expression pattern
        string pattern = @"\b(" + string.Join("|", discriminatoryWords) + @")\b";

        // Check if the input text contains any discriminatory words
        bool hasDiscriminatoryWords = Regex.IsMatch(text, pattern);

        return hasDiscriminatoryWords;
    }

    public int Create(int userId, Post post, List<string> images)
    {
        if (
            !IsAlloweNumberOfPosts(userId, postsAccessor.CountPostImages(post.PostId)) &&
            HasBadWords(post.PostText) &&
            HasBadWords(post.Heading))
        {
            return 0;
        }
        postsAccessor.CreatePost(post);
        foreach (string image in images)
        {
            postsAccessor.AddImage(post.PostId, image);
        }
        return 1;
    }

    public int CreateImages(int userId, int postId, List<string> imageLinks)
    {
        foreach (string image in imageLinks)
        {
            postsAccessor.AddImage(postId, image);
        }
        return 1;
    }

    public int Update(int userId, int postId, Post newPost)
    {
        if (!IsAlloweNumberOfPosts(userId, postsAccessor.CountPostImages(newPost.PostId)))
        {
            return 0;
        }

        var key = "post" + $"_{postId}";
        cacheManager.Remove(key);
        postsAccessor.UpdatePost(postId, newPost);
        return 1;
    }

    public int Delete(int userId, int postId)
    {
        var post = postsAccessor.GetPostById(postId);
        var userRole = userService.GetUserRole(userId);
        if (post != null && (post.UserId == userId || userRole == "admin"))
        {
            postsAccessor.DeletePost(postId);
            var key = "post" + $"_{postId}";
            cacheManager.Remove(key);

            return 1;
        }
        return 0;
    }

    public int CountPostImages()
    {
        return postsAccessor.CountPostImages(1);
    }

    public List<Post> GetAll()
    {
        List<Post>? posts;
        var key = "posts_all";
        if (cacheManager.IsSet(key))
        {
            posts = cacheManager.Get<List<Post>>(key);
        }
        else
        {
            posts = postsAccessor.GetPosts();
        }
        if (posts != null)
            return posts;
        else
            return new List<Post>();
    }

    public Post? Get(int id)
    {
        // Post? post = postsAccessor.GetPostById(id);
        Post? post;
        var key = "post" + $"_{id}";
        if (cacheManager.IsSet(key))
        {
            post = cacheManager.Get<Post>(key);
            if (post != null)
                Console.WriteLine(post.Heading);
        }
        else
        {
            post = postsAccessor.GetPostById(id);
            if (post != null)
                cacheManager.Set(key, post);
        }
        return post;
    }

    public List<Topic> GetTopics()
    {
        return postsAccessor.GetTopics();
    }

    public List<Post> GetPostsByTopic(int topicId)
    {
        return postsAccessor.GetPostsByTopicId(topicId);
    }
}
