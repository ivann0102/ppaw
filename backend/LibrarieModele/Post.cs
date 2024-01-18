using System;
using System.Collections.Generic;

namespace LibrarieModele;

public class Post
{
    public int PostId { get; set; }

    public string Heading { get; set; }

    public string PostText { get; set; }

    public DateOnly PostDate { get; set; }

    public int TopicId { get; set; }

    public int UserId { get; set; }

    public int? ParentPostId { get; set; }

    public ICollection<Post>? ChildPosts { get; set; }

    public ICollection<PostImage> PostImages { get; set; } = new List<PostImage>();

    public Post ParentPost { get; set; }

    public Topic Topic { get; set; }

    public User User { get; set; }
}
