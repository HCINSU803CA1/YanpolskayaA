using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для Form5.xaml
    /// </summary>
    public partial class Form5 : Window
    {
        Entitie en = new Entitie();
        public Form5()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Basket b in en.Basket)
            {
                ListViewItem i = new ListViewItem();
                i.Content = b.Product.name_P + "";
                basketView.Items.Add(i);
            }
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Form3 f = new Form3(); f.Show();
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (basketView.SelectedItem != null)
                {
                    foreach (ListViewItem l in basketView.Items)
                    {
                        if (l.IsSelected)
                        {
                            foreach (Basket b in en.Basket)
                            {
                                if (l.Content.ToString() == b.Product.name_P)
                                {
                                    en.Basket.Remove(b);
                                }
                            }
                            en.SaveChanges();
                        }
                    }
                    basketView.Items.Remove(basketView.SelectedItem);
                }
            }
            catch { MessageBox.Show("error"); }
           
        }
    }
}
