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
using System.IO;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace MyClient
{

    public partial class MainWindow : Window
    {
        
        int pageIndex = 0;
        int countOfRecords = 5;
        static readonly HttpClient client = new HttpClient();
        string resultString = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void DataRequest()
        {
            RequestData requestData = new RequestData() { Command = "GetData", CountOfRecords = countOfRecords, PageIndex = pageIndex };
            Uri url = new Uri ("http://127.0.0.1:8888/");
            var json = JsonConvert.SerializeObject(requestData);
            HttpContent data = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, data).ConfigureAwait(false);
            resultString = response.Content.ReadAsStringAsync().Result;
        }
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageIndex + countOfRecords;
            DataRequest();
            EmpGrid.ItemsSource = null;
            try
            {
                EmpGrid.ItemsSource = JsonConvert.DeserializeObject<List<Employee>>(resultString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            EmpGrid.Items.Refresh();

        }

        private void PrevPage_Click(object sender, RoutedEventArgs e)
        {
            if (pageIndex >= countOfRecords)
            {
                pageIndex = pageIndex - countOfRecords;
                DataRequest();
                EmpGrid.ItemsSource = null;
                EmpGrid.ItemsSource = JsonConvert.DeserializeObject<List<Employee>>(resultString);
                EmpGrid.Items.Refresh();
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGrid_Initialized(object sender, EventArgs e)
        {
            DataRequest();
            var result = JsonConvert.DeserializeObject<List<Employee>>(resultString);

            EmpGrid.ItemsSource = JsonConvert.DeserializeObject<List<Employee>>(resultString);
        }
    }
}
