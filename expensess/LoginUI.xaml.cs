using expensess.MODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net;
using expensess.view;
using expensess.Page;

namespace expensess
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginUI : ContentPage
    {
        public LoginUI()
        {
            InitializeComponent();
        }
        private bool isPasswordVisible = false;

        private void OnShowPasswordTapped(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            PasswordEntry.IsPassword = !isPasswordVisible;
            ShowPasswordImage.Source = ImageSource.FromFile(isPasswordVisible ? "eye_off.png" : "eye.png");
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            
            // Realiza una solicitud HTTP a la API para autenticar al usuario
            // Debes implementar la lógica de la API de autenticación aquí
            UserProfile log = new UserProfile
            {
                email = UsernameEntry.Text,
                password = PasswordEntry.Text
            };
            Uri RequestUri = new Uri("https://expensestrackerbackend-production.up.railway.app/api/auth/sing-in"); //aqui deben colocar su url
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(log);
            var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(RequestUri, contentJson);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                string jsonResult = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<AuthenticationResponse>(jsonResult);

                if (result.ok)
                {
                    // Autenticación exitosa
                  UserProfile  perfil = new UserProfile
                    {
                        Id = result.id,
                        fullname = result.nombre,
                        email = result.email,
                        password = PasswordEntry.Text,
                        telefono = result.telefono,
                        token = result.token
                    };
                    await Application.Current.MainPage.Navigation.PushAsync(new ProfilePage(perfil));
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

        private async void ForgetPasswordLabel_Tapped(object sender, EventArgs e)
        {
            // Navegar a la página de restablecimiento de contraseña aquí
            // Por ejemplo:
            await Navigation.PushAsync(new ForgotPasswordPage());
        }
    }

   
}