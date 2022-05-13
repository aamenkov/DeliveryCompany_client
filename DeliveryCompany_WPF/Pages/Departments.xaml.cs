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
using Newtonsoft.Json;

namespace DeliveryCompany_WPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для Departments.xaml
    /// </summary>
    public partial class Departments : Page
    {
        private readonly HttpClient _client = new HttpClient();
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
            var response = await _client.GetStringAsync("https://localhost:44365/api/v1/Department");
            var departments = JsonConvert.DeserializeObject<List<DeliveryCompany_Wpf.Models.Department>>(response);
            MessageBox.Show(departments.ToString());
            dgDepartments.DataContext = departments;

        }

        private async void SaveDepartment(DeliveryCompany_Wpf.Models.Department department)
        {
            await _client.PostAsJsonAsync("https://localhost:44365/api/v1/Department", department);
        }

        private async void UpdateDepartment(DeliveryCompany_Wpf.Models.Department department)
        {
            await _client.PutAsJsonAsync("https://localhost:44365/api/v1/Department/" + department.DepartmentId, department);
        }

        private async void DeleteDepartment(int departmentId)
        {
            await _client.DeleteAsync("https://localhost:44365/api/v1/Department/" + departmentId);
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

                this.SaveDepartment(department);
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
