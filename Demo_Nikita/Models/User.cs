using System;
using System.Collections.Generic;

namespace Demo_Nikita.Models;

public partial class User
{
    public int UserId { get; set; }

    public int? UserType { get; set; }

    public string? UserLogin { get; set; }

    public string? UserPassword { get; set; }

    public string? UserAddress { get; set; }

    public string? UserInn { get; set; }

    public string UserPhone { get; set; } = null!;

    public string? UserName { get; set; }

    public virtual ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();

    public virtual UserType? UserTypeNavigation { get; set; }
}
