using System;
using System.Collections.Generic;

namespace Demo_Nikita.Models;

public partial class UserProduct
{
    public int UserProductId { get; set; }

    public int? UserProductUser { get; set; }

    public int? UserProductProduct { get; set; }

    public int? UserProductQuantity { get; set; }

    public virtual Product? UserProductProductNavigation { get; set; }

    public virtual User? UserProductUserNavigation { get; set; }
}
