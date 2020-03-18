using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{

    /// <summary>
    /// Логика взаимодействия для Form4.xaml
    /// </summary>
    public partial class Form4 : Window
    {
        Entitie en = new Entitie();
        public Form4()
        {
            InitializeComponent();
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Text == "" || name.Text == "" || surname.Text == "" || phone.Text == "")
            {
                MessageBox.Show("Enter login or password!");
            }
            else
            {
                en.Users.Add(new Users
                {
                    login_u = login.Text,
                    pass_u = password.Text,
                    name_u = name.Text,
                    surname_u = surname.Text,
                    phone_u = phone.Text,
                    id_r = 2,
                }) ;
                en.SaveChangesAsync();
            }
        }
    }
}
