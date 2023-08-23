using System;
using System.Collections.Generic;

namespace Vicosa_Entity;

public partial class Chapterevent
{
    public Guid ChapterEventId { get; set; }

    public string? ChapterEventName { get; set; }

    public DateOnly? ChapterEventDate { get; set; }

    public Guid? ChapterId { get; set; }

    public virtual Chapter? Chapter { get; set; }
}
