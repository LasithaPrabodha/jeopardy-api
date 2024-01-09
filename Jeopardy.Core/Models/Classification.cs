using System;
using System.Collections.Generic;

namespace Jeopardy.Core.Models;

public partial class Classification
{
    public int ClueId { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = new();

    public virtual Clue Clue { get; set; } = new();
}
