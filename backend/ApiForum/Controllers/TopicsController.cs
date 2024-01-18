using BusinessLayer;
using LibrarieModele;
using Microsoft.AspNetCore.Mvc;
using NiveAccessDate_CodeFirst;

namespace ApiForum;

[ApiController]
[Route("/api/[controller]")]
public class TopicsController : Controller
{
  private IPostService postService;
  private ITopicService topicService;
  public TopicsController(IPostService postService, ITopicService topicService)
  {
    this.postService = postService;
    this.topicService = topicService;
  }

  [HttpGet()]
  public IEnumerable<TopicViewModel> Get()
  {
    List<Topic> topics = postService.GetTopics();
    Console.WriteLine(topics.Count);
    var topicModels = topics.Select(t => new TopicViewModel
    {
      TopicId = t.TopicId,
      TopicName = t.TopicName
    }).ToList();
    return topicModels;
  }

  [HttpGet("{topicId}")]
  public IEnumerable<PostViewModel> GetPosts(int topicId)
  {
    List<Post> posts = postService.GetPostsByTopic(topicId);
    var postModels = posts.Select(p => new PostViewModel(p)).ToList();
    return postModels;
  }
}
