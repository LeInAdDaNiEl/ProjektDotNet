using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_MVVM.Models;
using WPF_MVVM.ViewModels;

namespace WPF_MVVM
{
    public partial class AddWindow : Window
    {
        public TicketsVM vm { get { return DataContext as TicketsVM; } }
        public AddWindow()
        {
            InitializeComponent();
        }

        public void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputTicketBeginning.SelectedDate != null && InputTicketName.Text.Length > 1)
            {
                vm.AddTicket(InputTicketName.Text, InputTicketPrice.Text, (DateTime)InputTicketBeginning.SelectedDate, TicketImage.Source);
                InputTicketName.Text = "";
                InputTicketPrice.Text = "";
                InputTicketBeginning.SelectedDate = DateTime.Now;
                this.Close(); 
            }

        }

        private void AddImageButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                string selectedFileName = dlg.FileName;
                FileNameLabel.Content = selectedFileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                TicketImage.Source = bitmap;
            }
        }

        private async void AddImageFromWebButton(object sender, RoutedEventArgs e)
        {
            string link = WebImageLink.Text;

            TicketImage.Source = await vm.AddImageFromWebAsync(link);
        }
    }
}
