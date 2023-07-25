// MainPage.xaml.cs
using proyectoaplicaciones.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xamarin.Forms;

namespace proyectoaplicaciones
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateButtonClicked(object sender, EventArgs e)

        {
            if (string.IsNullOrWhiteSpace(ipAddressEntry.Text) || string.IsNullOrWhiteSpace(hostsNeededEntry.Text))
            {
                DisplayAlert("Error", "Por favor, complete todos los campos antes de calcular.", "OK");
                return;
            }
            string ipAddressString = ipAddressEntry.Text;

            List<int> hostsNeededList = hostsNeededEntry.Text.Split(',').Select(int.Parse).ToList();

            List<SubnetResult> subnetResults = SubnetCalculator.CalculateVLSM(ipAddressString, hostsNeededList);

            if (subnetResults != null)
            {
                resultListView.ItemsSource = subnetResults;
            }
            else
            {
                DisplayAlert("Error", "Dirección IP inválida. Por favor, ingrese una dirección IP válida.", "OK");
            }
        }
    }
}

