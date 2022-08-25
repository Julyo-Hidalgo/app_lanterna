using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Xamarin.Essentials;

namespace lanterna
{
    public partial class MainPage : ContentPage
    {
        bool lanterna_ligada = false;

        public MainPage()
        {
            InitializeComponent();

            btn_img.Source = ImageSource.FromResource("lanterna.img.liga.png");
        }

        private async void btn_img_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!lanterna_ligada)
                {
                    lanterna_ligada = true;

                    btn_img.Source = ImageSource.FromResource("lanterna.img.desliga.png");

                    Vibration.Vibrate(TimeSpan.FromMilliseconds(250));

                    await Flashlight.TurnOnAsync();
                }
                else
                {
                    lanterna_ligada = false;

                    btn_img.Source = ImageSource.FromResource("lanterna.img.liga.png");

                    Vibration.Vibrate(TimeSpan.FromMilliseconds(250));

                    await Flashlight.TurnOffAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ocorreu um erro: \n", ex.Message, "OK");
            }
        }
    }
}