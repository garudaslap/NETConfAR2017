using Xamarin.Forms;

namespace DemoTwitterAuth
{
    public partial class DemoTwitterAuthPage : ContentPage
    {
        bool autenticado = false;

        public DemoTwitterAuthPage()
        {
            InitializeComponent();
        }

		protected override async void OnAppearing()
		{
			base.OnAppearing();

			if (autenticado == true)
			{
				// Si quisieramos actualizar la pagina
			}
		}

		async void loginButton_Clicked(object sender, System.EventArgs e)
		{
			if (App.Authenticator != null)
				autenticado = await App.Authenticator.Authenticate();
            
			if (autenticado == true)
				await DisplayAlert("Twitter", "Autenticado Correctamente con " + App.userId, "ok");

		}
    }
}
