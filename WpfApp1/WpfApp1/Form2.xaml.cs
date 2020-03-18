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
    /// Логика взаимодействия для Form2.xaml
    /// </summary>
    public partial class Form2 : Window
    {
        Entitie en = new Entitie();
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TL6ADIU\\SQLEXPRESS1;Initial Catalog=Job;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        public Form2()
        {
            InitializeComponent();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ProductView.SelectedItem != null)
                {
                    foreach (ListViewItem l in ProductView.Items)
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
                           // en.SaveChanges();
                        }
                    }
                    ProductView.Items.Remove(ProductView.SelectedItem);
                }
            }
            catch { MessageBox.Show("error"); }

        }
        
        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text!="" && PriceBox.Text!="")
            {
                int i;
                bool b = Int32.TryParse(PriceBox.Text, out i);
                if (b)
                {
                    en.Product.Add(
                        new Product
                        {
                            name_P = NameBox.Text,
                            price_P = PriceBox.Text,
                            desc_P = DescBox.Text
                        }
                    );
                }
                else MessageBox.Show("error");
                try
                {
                    con.Open();
                    cmd = new SqlCommand("select id_P, name_P, price_P, desc_P  from Product", con);
                    cmd.ExecuteNonQuery();
                    da = new SqlDataAdapter(cmd);
                    dt = new DataTable("Product");
                    da.Fill(dt);
                    ProductView.ItemsSource = dt.DefaultView;
                    da.Update(dt);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               // ListViewItem ii = new ListViewItem();
               // ProductView.Items.Add(ii);
            }
        }
        private void win_load(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select id_P, name_P, price_P, desc_P  from Product", con);
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter(cmd);
                dt = new DataTable("Product");
                da.Fill(dt);
                ProductView.ItemsSource = dt.DefaultView;
                da.Update(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
