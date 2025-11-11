using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Demo_Nikita.cabinets;
using Demo_Nikita.Models;
using System.Linq;

namespace Demo_Nikita;

public partial class Authorization : Window
{
    public Authorization()
    {
        InitializeComponent();
    }

    private void auth(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        try
        {
            string? login = Login.Text;
            string? pass = Password.Text;
            if (login == null || pass == null)
            {
                Mess.Text = "Введите логин и пароль";
            }
            else
            {
                using (Db511Context db = new Db511Context())
                {
                    User? user = db.Users.Where(it=>it.UserPassword == pass && it.UserLogin == login).FirstOrDefault();
                    if (user != null)
                    {
                        if (user.UserType == 1)
                        {
                            new Administrator().Show();
                            Close();
                        }
                        else if (user.UserType == 2)
                        {
                            new Seller().Show();
                            Close();
                        }
                        else
                        {
                            
                        }
                    }
                    else
                    {
                        Mess.Text = "пользователь не найден. Обратитесь к администратору";
                    }
                }
            }
        }
        catch
        {
            Mess.Text = "Ошибка входа. Обратитесь к администратору";
        }
    }
}