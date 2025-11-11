using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo_Nikita.Models;
using System.Collections.ObjectModel;

namespace Demo_Nikita.cabinets;

public partial class Administrator : Window
{
    public Administrator()
    {
        InitializeComponent();
        using (Db511Context db = new Db511Context())
        {
            ListUsers.ItemsSource = new ObservableCollection<User>(db.Users);
        }
    }

    private void add(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        new AddUser().Show();
    }

    private void up(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        using (Db511Context db = new Db511Context())
        {
            ListUsers.ItemsSource = new ObservableCollection<User>(db.Users);
        }
    }
}