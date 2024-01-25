using LibrarieModele;
using Microsoft.AspNetCore.Mvc;
using NiveAccessDate_CodeFirst;
using BusinessLayer;

namespace ApiForum;

[ApiController]
[Route("/api/[controller]")]
public class PostsController : Controller
{
    private readonly IUsersAccessor usersAccessor;
    private readonly IPostService postService;
    public PostsController(IPostService postService, IUsersAccessor usersAccessor)
    {
        this.usersAccessor = usersAccessor;
        this.postService = postService;
    }

    [HttpGet("count")]
    public int CountPostImages()
    {
        return postService.CountPostImages();
    }

    [HttpGet()]
    public IEnumerable<PostViewModel> Get()
    {
        List<Post> posts = postService.GetAll();
        var postsModels = posts.Select(p => new PostViewModel(p)).ToList();
        return postsModels;
    }

    [HttpGet("{id:int}")]
    public PostViewModel? Get(int id)
    {
        Post? post = postService.Get(id);
        if (post == null)
        {
            return null;
        }
        return new PostViewModel(post);
    }

    [HttpPost("{userId:int}")]
    public IActionResult CreatePost(int userId, PostViewModel post)
    {
        Post newPost;
        if (post.ParentPostId != null)
            newPost = new Post
            {
                Heading = post.Heading,
                PostText = post.PostText,
                PostDate = DateOnly.FromDateTime(DateTime.Now),
                TopicId = post.TopicId,
                UserId = userId,
                ParentPostId = post.ParentPostId,
            };
        else
            newPost = new Post
            {
                Heading = post.Heading,
                PostText = post.PostText,
                PostDate = DateOnly.FromDateTime(DateTime.Now),
                TopicId = post.TopicId,
                UserId = userId,
            };

        if (post.PostImages == null)
            post.PostImages = new List<string>();

        int result = postService.Create(
            userId,
            newPost,
            post.PostImages
        );
        if(result==0){
            return StatusCode(403);
        }
        return Ok();
    }

    [HttpPut("{id:int}/{userId:int}")]
    public IActionResult  EditPost(int id, int userId, PostViewModel post)
    {
        Console.WriteLine($"{id} {post.PostDate.ToString()}");
        int result = postService.Update(
            userId,
            id,
            new Post
            {
                Heading = post.Heading,
                PostText = post.PostText,
                PostDate = DateOnly.FromDateTime(post.PostDate),
                TopicId = post.TopicId,
                UserId = post.UserId,
                ParentPostId = post.ParentPostId
            }
        );
        if(result == 0){
            return StatusCode(403);
        }
        return Ok();
    }

    [HttpDelete("{id:int}/{userId:int}")]
    public void DeletePost(int id, int userId)
    {
        postService.Delete(userId, id);
    }
}
