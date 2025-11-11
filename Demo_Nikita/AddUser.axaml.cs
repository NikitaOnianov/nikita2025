using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo_Nikita.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Demo_Nikita;

public partial class AddUser : Window
{
    public AddUser()
    {
        InitializeComponent();
        using (Db511Context db = new Db511Context())
        {
            ListType.ItemsSource = new ObservableCollection<UserType>(db.UserTypes);
        }
    }

    private void add(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        
        try
        {
            using (Db511Context db = new Db511Context())
            {
                User? u = db.Users.Where(it=>it.UserInn == inn.Text && it.UserPassword == pas.Text && it.UserLogin == log.Text).FirstOrDefault();
                if (u == null)
                {
                    User user = new User()
                    {
                        UserAddress = adres.Text,
                        UserInn = inn.Text,
                        UserLogin = log.Text,
                        UserName = adres.Text,
                        UserPassword = pas.Text,
                        UserType = (ListType.SelectedItem as UserType).UserTypeId,
                        UserPhone = phone.Text,
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                    Mess.Text = "Пользователь добавлен";
                }
                else
                {
                    Mess.Text = "Пользователь существует в системе";
                }
            }
        }
        catch
        {
            Mess.Text = "Ошибка. проверьте данные";
        }
    }
}