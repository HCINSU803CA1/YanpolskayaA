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
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Form3.xaml
    /// </summary>
    public partial class Form3 : Window
    {
        Entitie en = new Entitie();
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-TL6ADIU\\SQLEXPRESS1;Initial Catalog=Job;Integrated Security=True");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        public Form3()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("select id_P, name_P, price_P, desc_P  from Product", con);
                cmd.ExecuteNonQuery();
                da = new SqlDataAdapter(cmd);
                dt = new DataTable("Product");

                da.Fill(dt);
                list.ItemsSource = dt.DefaultView;
                da.Update(dt);
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

      

        private void Add_Click(object sender, RoutedEventArgs e)
        {

            int id = 0;
            bool c = Int32.TryParse(textBox.Text, out id);

            
            en.Basket.Add(
                new Basket
                {
                    id_UB = U.user2,
                    id_PB =id,
                }
                );
            en.SaveChanges();
        }

        private void basket_Click(object sender, RoutedEventArgs e)
        {
            Form5 f = new Form5(); this.Hide();
            f.Show();

        }
    }
}
