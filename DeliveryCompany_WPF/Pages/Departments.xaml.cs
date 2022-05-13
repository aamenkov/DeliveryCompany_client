using System;
using System.Collections.Generic;
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
using DeliveryCompany_Wpf.Models;
using Newtonsoft.Json;

namespace DeliveryCompany_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для Departments.xaml
    /// </summary>
    public partial class Departments : Page
    {
        private readonly HttpClient _client = new HttpClient();
        private static readonly string _url = "https://localhost:44365/api/v1/";
        public Departments()
        {
            _client.BaseAddress = new Uri("https://localhost:44365/api/v1");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            InitializeComponent();
        }

        private void btnLoadDepartments_Click(object sender, RoutedEventArgs e)
        {
            GetDepartments();
        }

        private async void GetDepartments()
        {
            var response = await _client.GetStringAsync(_url + "Department");
            var departments = JsonConvert.DeserializeObject<List<DeliveryCompany_Wpf.Models.Department>>(response);
            dgDepartments.DataContext = departments;

            //var list = new List<DeliveryCompany_Wpf.Models.Department>()
            //{
            //    new Department() {DepartmentId = 1, Name = "Apple", ApplicationList = null},
            //    new Department() {DepartmentId = 2, Name = "Orange", ApplicationList = null},
            //    new Department() {DepartmentId = 3, Name = "Water", ApplicationList = null},
            //    new Department() {DepartmentId = 4, Name = "Cook", ApplicationList = null}

            //};
            //dgDepartments.ItemsSource = new List<DeliveryCompany_Wpf.Models.Department>();
            //dgDepartments.DataContext = list;
        }

        private async void SaveDepartment(DeliveryCompany_Wpf.Models.Department department)
        {
            await _client.PostAsJsonAsync(_url + "Department", department);
        }

        private async void UpdateDepartment(DeliveryCompany_Wpf.Models.Department department)
        {
            await _client.PutAsJsonAsync(_url + "Department/" + department.DepartmentId, department);
        }

        private async void DeleteDepartment(int departmentId)
        {
            await _client.DeleteAsync(_url + "Department/" + departmentId);
        }

        private void btnSaveDepartment_Click(object sender, RoutedEventArgs e)
        {
            var department = new DeliveryCompany_Wpf.Models.Department()
            {
                DepartmentId = int.Parse(txtDepartmentId.Text),
                Name = txtName.Text
            };

            if (department.DepartmentId == 0)
            {
                lblResponseMessageResult.Visibility = Visibility.Visible;
                lblResponseMessageResult.Content = "Department saved";

                SaveDepartment(department);
            }
            else
            {
                lblResponseMessageResult.Visibility = Visibility.Visible;
                lblResponseMessageResult.Content = "Department updates";
            }

            txtDepartmentId.Text = 0.ToString();
            txtName.Text = "";
        }
    }
}
