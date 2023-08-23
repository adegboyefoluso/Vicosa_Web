using System;
using System.Collections.Generic;

namespace Vicosa_Entity;

public partial class Alumnichapter
{
    public int AlumniChapterId { get; set; }

    public Guid ChapterId { get; set; }

    public Guid AlumniId { get; set; }

    public DateOnly CreatedDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public bool? AlumniStatus { get; set; }

    public virtual Alumnus Alumni { get; set; } = null!;

    public virtual Chapter Chapter { get; set; } = null!;
}
