using LibrarieModele;

namespace ApiForum;

public class PostViewModel
{
    public int PostId { get; set; }

    public string Heading { get; set; }

    public string PostText { get; set; }

    public DateTime PostDate { get; set; }

    public int TopicId { get; set; }

    public string? Topic { get; set; }

    public int UserId { get; set; }

    public string? User { get; set; }

    public int? ParentPostId { get; set; }

    public List<string>? PostImages { get; set; }

    public PostViewModel(Post post)
    {
        PostId = post.PostId;
        Heading = post.Heading;
        PostText = post.PostText;
        PostDate = DateTime.Now;
        TopicId = post.TopicId;
        UserId = post.UserId;
        ParentPostId = post.ParentPostId;
        PostImages = new List<string>();
        Topic = post.Topic.TopicName;
        User = post.User.UserName;
        if (post.PostImages.Count > 0)
        {
            foreach (PostImage image in post.PostImages)
            {
                PostImages.Add(image.Link);
            }
        }
    }
    public PostViewModel() { }
}
