using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;


namespace Calidad_del_agua
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class editar_estacion : ContentPage
    {
        public editar_estacion()
        {
            InitializeComponent();
        }
        private async void guardar_estacion(object sender, EventArgs e)
        {
            var uri = new Uri("https://iotsmartp.azurewebsites.net/test_put");
            HttpClient myClient = new HttpClient();

            App.stations guardarestacion = new App.stations() { _id = App.tem_Id, title = txttitle.Text, description = txtdescription.Text, user = App.tem_user };
            string json = JsonConvert.SerializeObject(guardarestacion);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await myClient.PutAsync(uri, content);
            await Navigation.PopAsync();
        }

        private void cancelar(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void eliminar_estacion(object sender, EventArgs e)
        {

            HttpClient myClient = new HttpClient();
            App.stations eliminarestacion = new App.stations() { _id = App.tem_Id };
            string json = JsonConvert.SerializeObject(eliminarestacion);

            //            HttpResponseMessage response = null;

            HttpRequestMessage request = new HttpRequestMessage
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://iotsmartp.azurewebsites.net/test_delete")
            };
            await myClient.SendAsync(request);
            await Navigation.PopAsync();
        }

    }
}