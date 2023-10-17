using expensess.MODEL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace expensess.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }
        private async void EnviarSolicitudClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;

            // Valida que el correo sea válido (puedes usar una expresión regular u otra validación)
            if (IsValidEmail(email))
            {
                // Envía la solicitud a la API para generar el código y enviarlo por correo
                // Aquí deberías implementar la lógica para interactuar con tu API
                // y generar el código de recuperación basado en el correo proporcionado
                UserProfile log = new UserProfile
                {
                    email = email
                   
                };

                Uri RequestUri = new Uri("https://expensestrackerbackend-production.up.railway.app/api/auth/olvide-password"); //aqui deben colocar su url
                var client = new HttpClient();
                var json = JsonConvert.SerializeObject(log);
                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(RequestUri, contentJson);


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<OlvidePasswordResponse>(jsonResult);

                    if (result.ok)
                    {
                        // Autenticación exitosa
                        await DisplayAlert("Exito!!", result.message.ToString(), "OK");
                        await Navigation.PushAsync(new VerificationPage(email,result.codigo));
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

                // Después de enviar la solicitud, puedes navegar a la página de validación de código
                //await Navigation.PushAsync(new VerificationPage(email));
            }
            else
            {
                await DisplayAlert("Error", "Correo electrónico no válido", "OK");
            }
        }

        private bool IsValidEmail(string email)
        {
            // Implementa una validación de correo electrónico adecuada según tus necesidades
            // Esto es solo un ejemplo simple
            return !string.IsNullOrEmpty(email) && email.Contains("@") && email.Contains(".");
        }
    }
}