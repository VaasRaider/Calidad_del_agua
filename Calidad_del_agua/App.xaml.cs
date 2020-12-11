using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Calidad_del_agua
{
    public partial class App : Application
    {
        static public List<stations> estacion { get; set; }
        static public List<Pin> pin { get; set; }
        static public string tem_title, tem_description, tem_user, tem_Id;
        public static bool press = false;

        public App()
        {
            InitializeComponent();
            estacion = new List<stations>();
            pin = new List<Pin>();
            MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public class stations
        {

            public string _id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string user { get; set; }
            public string createdAt { get; set; }
            public string updateAt { get; set; }

        }
        public class Pin
        {
            public string Label { get; set; }
            public string Address { get; set; }
            public string Type { get; set; }
            public string Position { get; set; }

        }
    }
}
