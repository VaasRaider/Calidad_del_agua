using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms.Maps;

namespace Calidad_del_agua
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class nueva_estacion : ContentPage
    {
        public nueva_estacion()
        {
            InitializeComponent();
        }
        private async void Guardar(object sender, EventArgs e)
        {
            var uri = new Uri("https://iotsmartp.azurewebsites.net/test_post");
            HttpClient myClient = new HttpClient();
            App.stations nuevoEstacion = new App.stations() { title = txttitle.Text, _id = App.tem_Id, description = txtdescription.Text };
            string json = JsonConvert.SerializeObject(nuevoEstacion);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            response = await myClient.PostAsync(uri, content);
            await Navigation.PopAsync();
        }

        private void Cancelar(object sender, EventArgs e)
        {

        }
        protected override void OnAppearing()
        {

            Get_points();


        }
        public void Get_points()
        {
            for (int i = 0; i < App.estacion.Count; i++)
            {
                var items = App.estacion[i].description.Split(',');
                double longitude = double.Parse(items[0]);
                double latitude = double.Parse(items[1]);
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(longitude, latitude),
                    Label = App.estacion[i].title,
                    Address = "aqui se encuentra usted",

                };
                map.Pins.Add(pin);
                Console.WriteLine(App.estacion[i].description);
            }
        }
    }
}