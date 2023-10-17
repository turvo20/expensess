using expensess.Viewmodel;
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
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            listView.ItemsSource = new TransactionModel().Get();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            dt.Focus();
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                listView.SelectedItem = null;
            }
        }

        private void dt_DateSelected(object sender, DateChangedEventArgs e)
        {
            lblDate.Text = dt.Date.ToString("dd MMM yyyy");
        }

        private async void btnNew_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NewTransaction");
        }
    }
}