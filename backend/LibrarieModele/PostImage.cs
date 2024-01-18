using System;
using System.Collections.Generic;

namespace LibrarieModele;

public class PostImage
{
    public int PostImageId { get; set; }

    public string Link { get; set; }

    public int PostId { get; set; }

    public virtual Post Post { get; set; }
}
