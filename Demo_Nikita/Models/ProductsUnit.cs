using System;
using System.Collections.Generic;

namespace Demo_Nikita.Models;

public partial class ProductsUnit
{
    public int ProductsUnitId { get; set; }

    public string ProductsUnitName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
