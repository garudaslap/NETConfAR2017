using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using demonetconfar2017;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace DemoEasyTables
{
    public partial class DemoEasyTablesPage : ContentPage
    {
        IMobileServiceTable<Presente> presentesTable = App.MobileService.GetTable<Presente>();

        public async void agregarPresente(object sender, System.EventArgs args) {
			Presente presentesItem = new Presente()
			{
				Nombre = entryNombre.Text,
				Apellido = entryApellido.Text
			};

            try
            {
                await presentesTable.InsertAsync(presentesItem);

				await DisplayAlert("Demo", "Se agrego correctamente el presente.", "Ok");
				entryNombre.Text = string.Empty;
				entryApellido.Text = string.Empty;

				IEnumerable<Presente> items = await presentesTable.ToEnumerableAsync();

				lvPresentes.ItemsSource = new List<Presente>(items);
            }
            catch (Exception exc) {
                await DisplayAlert("Error",exc.Message,"Ok");
            }
        }

        public DemoEasyTablesPage()
        {
            InitializeComponent();
        }
    }
}

namespace demonetconfar2017 {
	public class Presente
	{
        public string Id { get; set; }
		public string Nombre { get; set; }
		public string Apellido { get; set; }
        public string Version { get; set; }
	}
}
