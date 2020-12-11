using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Essentials;

namespace Calidad_del_agua
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    

        public async void Get_Data()
        {
            var uri = new Uri("https://iotsmartp.azurewebsites.net/test_get");
            HttpClient myClient = new HttpClient();
            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                App.estacion = JsonConvert.DeserializeObject<List<App.stations>>(content);
                //JsonConvert.DeserializeObject<Account>(json);
                lstEstaciones.ItemsSource = App.estacion.ToList();
                //await DisplayAlert(items{1});
                editar.IsVisible = false;
            }
            else
            {

            }


            //var conn = new SQLiteConnection(App.RUTABD);
            //conn.CreateTable<App.Persona>();
            //App.Personas = conn.Table<App.Persona>().OrderBy(n => n.Nombre).ToList();
            //lstPersonas.ItemsSource = conn.Table<App.Persona>().OrderBy(n => n.Nombre).ToList();
            //lstPersonas.ItemsSource = conn.Table<App.Persona>().OrderBy(n => n.Nombre).ToList();

            //conn.Close();
            //lstPersonas.ItemsSource = App.Personas.OrderBy(n => n.Nombre).ToList();

        }
        //editar
        private void button_modificar(object sender, EventArgs e)
        {
            Navigation.PushAsync(new editar_estacion()
            {
                BindingContext = new App.stations() { _id = App.tem_Id, title = App.tem_title, description = App.tem_description, user = App.tem_user }
            });


        }



        public void verificar()
        {
            if (App.estacion.Count() > 0)
            {
                if (App.press == true)
                {
                    editar.IsVisible = true;
                    //eliminar.IsVisible = true;
                }
                else
                {
                    editar.IsVisible = false;
                    //eliminar.IsVisible = false;
                }

            }
            else
            {
                editar.IsVisible = false;
                //eliminar.IsVisible = false;
            }
            App.press = false;
        }

       


        protected override void OnAppearing()
        {
            Get_Data();
            


        }

        private void estaciones_seleccionadas(object sender, SelectedItemChangedEventArgs e)
        {
            App.press = true;
            var estacionSeleccionada = e.SelectedItem as App.stations;
            verificar();
            App.tem_Id = estacionSeleccionada._id;
            App.tem_title = estacionSeleccionada.title;
            App.tem_description = estacionSeleccionada.description;
            App.tem_user = estacionSeleccionada.user;
            App.press = false;
        }

        private void nueva_estacion(object sender, EventArgs e)
        {
            Navigation.PushAsync(new nueva_estacion());
        }

        private void mapa(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Map());
        }
    }
}
