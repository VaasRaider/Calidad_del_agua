using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace Calidad_del_agua
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Map : ContentPage
    {
        public Map()
        {
            InitializeComponent();
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