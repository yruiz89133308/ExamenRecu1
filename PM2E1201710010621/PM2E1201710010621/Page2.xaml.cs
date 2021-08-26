using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using PM2E1201710010621.Model;
using PM2E1201710010621;

namespace PM2E1201710010621
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
          
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conection = new SQLiteConnection(App.UbicacionDB))
            {
                conection.CreateTable<localizacionDB>();
                var Lista = conection.Table<localizacionDB>().ToList();
                ListaUbicaciones.ItemsSource = Lista;


            }
        }
    }
}