using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF_MVVM.Controls
{
    class MyCustomPanel : ContentControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MyCustomPanel), new PropertyMetadata("Name of item to be deleted", titleUpdatedCallback));

        private static void titleUpdatedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var myPanel = (d as MyCustomPanel);
            if (myPanel != null)
            {
                myPanel.MethodUpdateOtherDependecies();
            }
        }


        public void MethodUpdateOtherDependecies()
        {
            
        }
    }
}
