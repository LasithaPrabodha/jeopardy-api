using System;
using System.Collections.Generic;

namespace Jeopardy.Core.Models;

public partial class Clue
{
    public int Id { get; set; }

    public int Game { get; set; }

    public int Round { get; set; }

    public int Value { get; set; }

    public virtual Airdate? GameNavigation { get; set; }

    public virtual Document IdNavigation { get; set; } = null!;

    public ICollection<Category> Categories {get; set;}
}
