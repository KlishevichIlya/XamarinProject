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
	public partial class Page3 : ContentPage
	{
		public Page3 (Contact test)
		{
			InitializeComponent ();
            Title = test.name;
            Label lbel = new Label
            {
                
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = test.infa,
                //FontSize="Micro"
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            lbel.FontSize = 15;
            Content = lbel;
        }

        public Page3(Regessery test)
        {
            InitializeComponent();
            Title = test.name;
            Label lbel = new Label
            {

                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Text = test.infa,
                //FontSize="Micro"
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            lbel.FontSize = 15;
            Content = lbel;
        }

        public Page3()
        {
            InitializeComponent();
        }
    }
}