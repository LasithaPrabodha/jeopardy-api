using System;
using System.Collections.Generic;

namespace Jeopardy.Core.Models;

public partial class Airdate
{
    public int Game { get; set; }

    public DateOnly? Date { get; set; }

    public virtual ICollection<Clue> Clues { get; set; } = new List<Clue>();
}
