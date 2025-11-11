using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo_Nikita.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Demo_Nikita.cabinets;

public partial class Buyer : Window
{
    public Buyer()
    {
        InitializeComponent();
        using (Db511Context db = new Db511Context())
        {
            ListUsersProd.ItemsSource = allprod();
        }
    }
    ObservableCollection<UserProd> allprod()
    {
        try
        {
            using (Db511Context db = new Db511Context())
            {
                var w = db.UserProducts.Select(it => new UserProd()
                {
                    UserProductProduct = it.UserProductProductNavigation.ProductName,
                    UserProductUser = it.UserProductUserNavigation.UserName,
                    UserProductPrice = Price(it.UserProductQuantity,it.UserProductProductNavigation.ProductPrice)
                }).ToList();
                return new ObservableCollection<UserProd>(w);
            }
        }
        catch
        {
            return new ObservableCollection<UserProd>();
            
        }
    }

    float Price(int? i, float? q)
    {
        if (i != null && q != null)
        {
            return (float)(i * q);
        }
        else { return 0; }
    }
}