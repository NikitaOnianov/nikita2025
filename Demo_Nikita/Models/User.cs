using System;
using System.Collections.Generic;

namespace Demo_Nikita.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Passwordhash { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime Createdat { get; set; }

    public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();
}
