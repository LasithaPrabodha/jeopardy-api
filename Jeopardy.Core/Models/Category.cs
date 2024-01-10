using System;
using System.Collections.Generic;

namespace Jeopardy.Core.Models;

public partial class Category
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = string.Empty;
    public ICollection<Clue> Clues {get; set;}
}
