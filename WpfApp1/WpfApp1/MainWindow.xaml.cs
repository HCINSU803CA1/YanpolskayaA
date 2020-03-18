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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entitie en = new Entitie(); //подключили ентити
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {

            if (login.Text == "" || password.Text == "")
            {
                MessageBox.Show("Enter login or password!");
            }
            else {
                var user = en.Users.Where(c=>c.login_u == login.Text && c.pass_u == password.Text).SingleOrDefault(); //есть ли данный юзер в бд

                if (user != null)
                {
                    switch (user.id_r) //разные роли: юзер, админ
                        {
                        case 1:
                            Form2 admin = new Form2();
                            admin.Show();
                            this.Hide();
                            break;

                        case 2:
                            U.user2 = user.id_u;
                            Form3 user1 = new Form3();
                            user1.Show();
                            this.Hide();
                            break;
                    }
                }
            }
        }

      

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Form4 reg = new Form4();
            reg.Show();
            this.Hide();
        }
    }
}
