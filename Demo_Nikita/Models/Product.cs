using System;
using System.Collections.Generic;

namespace Demo_Nikita.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? ProductUnit { get; set; }

    public float? ProductQuantity { get; set; }

    public float? ProductPrice { get; set; }

    public virtual ProductsUnit? ProductUnitNavigation { get; set; }

    public virtual ICollection<UserProduct> UserProducts { get; set; } = new List<UserProduct>();
}
