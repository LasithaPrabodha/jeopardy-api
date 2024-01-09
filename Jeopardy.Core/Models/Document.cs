using System;
using System.Collections.Generic;

namespace Jeopardy.Core.Models;

public partial class Document
{
    public int Id { get; set; }

    public string? Clue { get; set; }

    public string? Answer { get; set; }

    public virtual Clue? ClueNavigation { get; set; }
}
