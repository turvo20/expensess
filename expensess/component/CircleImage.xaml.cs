using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace expensess.component
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CircleImage : ContentView
    {
        public CircleImage()
        {
            InitializeComponent();
        }
        public float CornerRadius
        {
            get
            {
                return frame.CornerRadius;
            }
            set
            {
                frame.CornerRadius = value;
            }
        }

        public double FrameHeight
        {
            get
            {
                return frame.HeightRequest;
            }
            set
            {
                frame.HeightRequest = value;
            }
        }

        public double FrameWidth
        {
            get
            {
                return frame.WidthRequest;
            }
            set
            {
                frame.WidthRequest = value;
            }
        }

        public ImageSource Image
        {
            get
            {
                return img.Source;
            }
            set
            {
                img.Source = value;
            }

        }

        public Color BorderColor
        {
            get
            {
                return frame.BorderColor;
            }
            set
            {
                frame.BorderColor = value;
            }
        }
    }
}