using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_MVVM.Models
{
    public class Tickets : INotifyPropertyChanged
    {
       
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; PropertyChange(nameof(Name)); }
        }

        private DateTime beginning;

        public DateTime Beginning
        {
            get { return beginning; }
            set { beginning = value; PropertyChange(nameof(Beginning)); }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; PropertyChange(nameof(Price)); }
        }

        private ImageSource image;

        public ImageSource Image
        {
            get { return image; }
            set { image = value; PropertyChange(nameof(Image)); }
        }


        public Tickets(string name, double price, DateTime beg, ImageSource image)
        {
            Name = name;
            Beginning = beg;
            Price = price;
            Image = image;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void PropertyChange(string propertyName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
