using expensess.MODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace expensess.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage : ContentPage
    {
        private string email; // Almacena el correo electrónico del paso de validación
       
        public ChangePasswordPage(string email)
        {
            InitializeComponent();
            this.email = email; // Guarda el correo electrónico para usarlo en el cambio de contraseña
           
        }

        private async void ConfirmarCambioClicked(object sender, EventArgs e)
        {
            string newPassword = newPasswordEntry.Text;

            // Envía la solicitud a la API para cambiar la contraseña
            // Debes implementar la lógica para interactuar con tu API
            // y actualizar la contraseña del usuario

            UserProfile log = new UserProfile
            {
                email = email,
                password = newPassword,

            };

            Uri RequestUri = new Uri("https://expensestrackerbackend-production.up.railway.app/api/auth/actualizar-password"); //aqui deben colocar su url
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(RequestUri, contentJson);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OlvidePasswordResponse>(jsonResult);

                if (result.ok)
                {
                    // Autenticación exitosa
                    await DisplayAlert("Exito!!", result.message.ToString(), "OK");
                    await Navigation.PushAsync(new LoginUI());
                }
                else
                {
                    // Autenticación fallida, muestra un mensaje de error
                    await DisplayAlert("Error", result.ToString(), "OK");
                }
            }
            else
            {
                await DisplayAlert("Mensaje", "Datos invalidos", "OK");
            }

            // Si el cambio de contraseña es exitoso, puedes mostrar un mensaje de éxito
            //await DisplayAlert("Éxito", "La contraseña se ha cambiado exitosamente", "OK");
        }
    }
}