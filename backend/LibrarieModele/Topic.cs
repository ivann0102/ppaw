using System;
using System.Collections.Generic;

namespace LibrarieModele;

public class Topic
{
    public int TopicId { get; set; }

    public string TopicName { get; set; }

    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
