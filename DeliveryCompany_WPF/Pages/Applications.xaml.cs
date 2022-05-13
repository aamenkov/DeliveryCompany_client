using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace DeliveryCompany_WPF.Pages
{
    public partial class Applications : Page
    {
        private readonly HttpClient _client = new HttpClient();
        private static readonly string _url = "https://localhost:44365/api/v1/"; 
        public Applications()
        {
            _client.BaseAddress = new Uri("https://localhost:44365/api/v1");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            InitializeComponent();
        }

        private void btnLoadApplications_Click(object sender, RoutedEventArgs e)
        {
            GetApplications();
        }

        private async void GetApplications()
        {
            var response = await _client.GetStringAsync(_url + "Application");
            var applications = JsonConvert.DeserializeObject<List<DeliveryCompany_Wpf.Models.Application>>(response);
            dgApplications.DataContext = applications;
            
        }

        private async void UpdateApplication(DeliveryCompany_Wpf.Models.Application application)
        {
            await _client.PutAsJsonAsync(_url + "Application/" + application.ApplicationId, application);
        }

        private async void DeleteApplication(int applicationId)
        {
            await _client.DeleteAsync(_url + "Application/" + applicationId);
        }

        private async void SaveApplication(DeliveryCompany_Wpf.Models.Application application)
        {
            await _client.PostAsJsonAsync(_url + "Application", application);
        }

        private void btnSaveApplication_Click(object sender, RoutedEventArgs e)
        {
            var application = new DeliveryCompany_Wpf.Models.Application()
            {
                ReceivingAddress = txtReceivingAddress.Text,
                ReceivingTown = txtReceivingTown.Text,
                DeliveryTown = txtDeliveryTown.Text,
                Weight = int.Parse(txtWeight.Text),
                Length = int.Parse(txtLength.Text),
                Width = int.Parse(txtWidth.Text),
                Height = int.Parse(txtHeight.Text),
                DepartmentId = int.Parse(txtDepartmentId.Text)
            };
            lblResponseMessageResult.Visibility = Visibility.Visible;
            lblResponseMessageResult.Content = "Application saved";

            this.SaveApplication(application);
        }

    }

}