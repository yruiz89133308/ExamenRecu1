using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using PM2E1201710010621.Model;
using Xamarin.Essentials;

namespace PM2E1201710010621
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnSalvar_Clicked(object sender, EventArgs e)
        {
            if (!double.TryParse(txtLatitud.Text, out double lat))
                return;
            if (!double.TryParse(txtLongitud.Text, out double lng))
                return;

            if (txtdescripcion.Text == "")
            {
                await DisplayAlert("Alerta", "obligatoriamente debes de escribir la ubicacion", "ok");
            }
            if (txtNomUbicacion.Text == "")
            {
                await DisplayAlert("Alerta", "debes de escribir una ubicacion", "ok");
            }

            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = txtdescripcion.Text,
                NavigationMode = NavigationMode.None

            });
            {
                Int32 resultado = 0;

                using (SQLiteConnection conection = new SQLiteConnection(App.UbicacionDB))
                {
                    var persona = new localizacionDB()

                    {
                        Latitud = txtLatitud.Text,
                        Longitud = txtLongitud.Text,
                        Descripcion = txtdescripcion.Text,
                        NomUbicacion = txtNomUbicacion.Text,

                    };
                    var page = new Page2();
                    page.BindingContext = persona;
                    await Navigation.PushAsync(page);

                    conection.CreateTable<localizacionDB>();
                    resultado = conection.Insert(persona);

                    if (resultado > 0)

                        await DisplayAlert("Aviso", "Ingreso Correcto de Ubicación", "OK");

                    else

                        await DisplayAlert("Aviso", "Error al Ingresar Ubicación", "OK");

                }
            }

        }

   
        private async void toolbarmenu_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2());

        }

        private void BtnSalvadas_Clicked(object sender, EventArgs e)

        {
            NavigationPage MainPage = new NavigationPage(new Page2());

        }


        }
    }

