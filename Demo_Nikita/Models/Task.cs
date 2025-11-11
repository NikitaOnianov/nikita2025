using System;
using System.Collections.Generic;

namespace Demo_Nikita.Models;

public partial class Task
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime Createdat { get; set; }

    public DateTime? Duedate { get; set; }

    public bool Iscompleted { get; set; }

    public int Priority { get; set; }

    public int Userid { get; set; }

    public virtual User User { get; set; } = null!;
}
