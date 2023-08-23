using System;
using System.Collections.Generic;

namespace Vicosa_Entity;

public partial class Event
{
    public Guid EventId { get; set; }

    public string? EventName { get; set; }

    public DateOnly? EventDate { get; set; }
}
