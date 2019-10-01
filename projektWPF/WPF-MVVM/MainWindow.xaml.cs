using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_MVVM.Models;
using WPF_MVVM.ViewModels;

namespace WPF_MVVM
{
  
    public partial class MainWindow : Window
    {
       public TicketsVM vm { get { return DataContext as TicketsVM; }}
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddTicket(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.Show();
        }

        private void AddOneParticipantButton_Click(object sender, RoutedEventArgs e)
        {
            vm.AddParticipantToTodo((Tickets)(TicketsListView.SelectedItem));
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            vm.DeleteTodo((Tickets)(TicketsListView.SelectedItem));
        }



        private async void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            await vm.SaveToFileJson();
        }

        private async void LoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            await vm.LoadFromFileJson();

        }
    }
}
