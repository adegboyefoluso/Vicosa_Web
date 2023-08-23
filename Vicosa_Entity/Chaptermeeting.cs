using System;
using System.Collections.Generic;

namespace Vicosa_Entity;

public partial class Chaptermeeting
{
    public Guid MeetingId { get; set; }

    public DateOnly? MeetingDate { get; set; }

    public Guid? ChapterId { get; set; }

    public string? Filename { get; set; }

    public string? FileDirectory { get; set; }

    public virtual Chapter? Chapter { get; set; }
}
