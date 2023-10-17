using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace expensess.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerificationPage : ContentPage
    {
        private string email; // Almacena el correo electrónico del paso anterior
        private int codigo;

        public VerificationPage(string email,int codigo)
        {
            InitializeComponent();
            this.email = email; // Guarda el correo electrónico para usarlo en la verificación
            this.codigo = codigo;
        }

        private async void ValidarCodigoClicked(object sender, EventArgs e)
        {
            int verificationCode = Convert.ToInt32(verificationCodeEntry.Text);

            // Envía la solicitud a la API para validar el código
            // Debes implementar la lógica para interactuar con tu API
            // y verificar si el código de recuperación es válido

            // Por ejemplo, puedes usar HttpClient para hacer la solicitud a la API
            if (verificationCode == codigo)
            {
                await Navigation.PushAsync(new ChangePasswordPage(email));
            }
            else
            {
                await DisplayAlert("Error", "Código de verificación no válido", "OK");
            }
            // Si la validación es exitosa, puedes navegar a la página de cambio de contraseña
            //await Navigation.PushAsync(new ChangePasswordPage(email));
            // Si la validación falla, muestra un mensaje de error
            //await DisplayAlert("Error", "Código de verificación no válido", "OK");
        }
    }
}