using System;
using System.Collections.Generic;

namespace Demo_Nikita.Models;

public partial class UserProd
{
    public int UserProductId { get; set; }

    public string? UserProductUser { get; set; }

    public string? UserProductProduct { get; set; }

    public float? UserProductPrice { get; set; }
}
