using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace I_Invoice_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtApePat.Text) || string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Capture campos obligatorios(marcados con *)");
            }else
            {
                string message = await InsertPerson();
                txtName.Text = "";
                txtApePat.Text = "";
                txtApeMat.Text = "";
                txtId.Text = "";
                MessageBox.Show(message);
            }
        }
        private async Task<string> InsertPerson()
        {
            string StatusInsert = string.Empty;
            var request = new Person
            {
                Id = "",
                Name = txtName.Text,
                LastName = txtApePat.Text,
                SecondLastName = txtApeMat.Text,
                IdCard = txtId.Text,
                Amount = "0.0"
            };

            var jsonRequest = JsonConvert.SerializeObject(request);
            var insertRequest = NewRequest(RestSharp.Method.Post, jsonRequest, "/api/Directory/store-person");
            var response = await new RestClient("https://localhost:7161").PostAsync(insertRequest);

            if (response.StatusCode.Equals(HttpStatusCode.OK))
            {
                StatusInsert = "Usuario registrado";
            }
            else
            {
                StatusInsert = "Error:" + response.ErrorMessage;
            }

            return StatusInsert;
                /*using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync("https://localhost:7161/api/Directory/store-person");
                    response.EnsureSuccessStatusCode();

                    if (response.IsSuccessStatusCode)
                    {
                        //Message.Content = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        //Message.Content = $"Error: {response.StatusCode}";
                    }
                }*/
            }

        public RestRequest NewRequest(RestSharp.Method method, string parameters, string resource)
        {
            var request = new RestRequest(resource, method);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            if (!string.IsNullOrEmpty(parameters))
            {
                request.AddParameter("application/json", parameters, ParameterType.RequestBody);
            }
            return request;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Capture el nombre");
                return;
            }
        }


        private void txtApePat_LostFocus_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtApePat.Text))
            {
                MessageBox.Show("Capture el apellido");
                return;
            }
        }

        private void txtId_LostFocus(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Capture el apellido");
                return;
            }
        }
    }
}
