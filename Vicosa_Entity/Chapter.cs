using System;
using System.Collections.Generic;

namespace Vicosa_Entity;

public partial class Chapter
{
    public Guid ChapterId { get; set; }

    public string? ChapterName { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Alumnus> Alumni { get; set; } = new List<Alumnus>();

    public virtual ICollection<Alumnichapter> Alumnichapters { get; set; } = new List<Alumnichapter>();

    public virtual ICollection<Chapterevent> Chapterevents { get; set; } = new List<Chapterevent>();

    public virtual ICollection<Chaptermeeting> Chaptermeetings { get; set; } = new List<Chaptermeeting>();
}
