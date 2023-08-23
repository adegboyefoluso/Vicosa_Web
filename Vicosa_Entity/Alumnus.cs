using System;
using System.Collections.Generic;

namespace Vicosa_Entity;

public partial class Alumnus
{
    public Guid AlumniId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? EmailAddress { get; set; }

    public DateOnly? GraduationYear { get; set; }

    public DateOnly? EnrollmentYear { get; set; }

    public string? ImageUrl { get; set; }

    public int? PhoneNumber { get; set; }

    public Guid? ChapterId { get; set; }

    public virtual ICollection<Alumnichapter> Alumnichapters { get; set; } = new List<Alumnichapter>();

    public virtual Chapter? Chapter { get; set; }
}
