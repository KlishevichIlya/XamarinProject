using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page4 : ContentPage
	{
		public Page4 ()
		{
			InitializeComponent ();
		}
        private void Button4_Clicked(object sender, EventArgs e)
        {
         
            LongitudeLabel.Text = "53.9000000";
            LatitudeLabel.Text = "27.5666700";
            Cinema.Text = "Мир";
            img.Source = ImageSource.FromResource("App1.Images.Cinema.png");


            //Image image = new Image();
            //image.Source = ImageSource.FromResource("App1.Images.Cinema.png");
            //Content = image;
            /*   var locator = Plugin.Geolocator.CrossGeolocator.Current;
             locator.DesiredAccuracy = 50;
             var position = await locator.GetPositionAsync(timeoutMilliseconds:10000);
             LongitudeLabel.Text = position.Longitude.ToString();
             LatitudeLabel.Text = position.Latitude.ToString();
             */
        }
    }
}