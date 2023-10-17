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

namespace expensess.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private UserProfile perfil;
        public ProfilePage(UserProfile profile)
        {
            InitializeComponent();
            BindingContext = profile;
            perfil = profile;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
        

            // Realiza una solicitud HTTP a la API para autenticar al usuario
            // Debes implementar la lógica de la API de autenticación aquí
            UserProfile log = new UserProfile
            {
                fullname = nombretxt.Text,
                email = emailtxt.Text,
                telefono = telefonotxt.Text,
                password = PasswordEntry.Text
            };
            Uri RequestUri = new Uri($"https://expensestrackerbackend-production.up.railway.app/api/auth/perfil/{perfil.Id}"); //aqui deben colocar su url
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            // Agregar el encabezado de autorización
            client.DefaultRequestHeaders.Add("authorization", $"{perfil.token}");
            var response = await client.PutAsync(RequestUri, contentJson);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AuthenticationResponse>(jsonResult);

                if (result.ok)
                {
                    // Autenticación exitosa

                    await DisplayAlert("Exito","Usuario Modificado Correctamente", "OK");
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
        }
        private bool isPasswordVisible = false;

        private void OnShowPasswordTapped(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            PasswordEntry.IsPassword = !isPasswordVisible;
            ShowPasswordImage.Source = ImageSource.FromFile(isPasswordVisible ? "eye_off.png" : "eye.png");
        }

        private async void logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginUI());
        }
    }
}