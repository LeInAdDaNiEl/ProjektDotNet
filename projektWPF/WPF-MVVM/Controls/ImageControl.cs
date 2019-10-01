using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WPF_MVVM.Controls
{
    class ImageControl : ContentControl
    {
        public static readonly DependencyProperty MyImageSourceProperty = DependencyProperty.Register("MyImageSource",
                                                                          typeof(Uri), typeof(ImageControl),
                                                                          new FrameworkPropertyMetadata(new PropertyChangedCallback(OnImageSourceChanged)));

        public BitmapImage MyImageSource
        {
            get { return (BitmapImage)GetValue(MyImageSourceProperty); }
            set { SetValue(MyImageSourceProperty, value); }
        }
        private static void OnImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ImageControl userControl = (ImageControl)d;

            userControl.MyImageSource = new BitmapImage((Uri)e.NewValue);
        }


    }
}
