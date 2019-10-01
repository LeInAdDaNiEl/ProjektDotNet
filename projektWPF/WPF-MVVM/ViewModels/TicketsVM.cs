using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WPF_MVVM.Models;

namespace WPF_MVVM.ViewModels
{
    public class TicketsVM
    {
        public ObservableCollection<Tickets> Tickets { get; set; }
        public TicketsVM()
        {
            Tickets = new ObservableCollection<Tickets>();
        }

        public void AddTicket(string name, string numberString, DateTime beginning, ImageSource image)
        {
            double number;
            if (!Double.TryParse(numberString, out number))
            {
                return;
            }
            Tickets.Add(new Tickets(name, number, beginning, image));
        }

        internal void AddParticipantToTodo(Tickets selectedTicket)
        {
            selectedTicket.Price++;
        }

        internal void DeleteTodo(Tickets selectedTicket)
        {
            if (Tickets.Contains(selectedTicket))
            {
                Tickets.Remove(selectedTicket);
            }
        }

        public async Task<BitmapImage> AddImageFromWebAsync(string link)
        {
            BitmapImage image = new BitmapImage();
            using (HttpClient client = new HttpClient())
            {
                // Call asynchronous network methods in a try/catch block to handle exceptions
                try
                {
                    HttpResponseMessage response = await client.GetAsync(link);
                    response.EnsureSuccessStatusCode();
                    image = new BitmapImage(new Uri(link));
                    

                }
                catch(InvalidOperationException e)
                {
                    return image;
                }
                catch (HttpRequestException e)
                {
                }
            }
            return image;
        }

        public async Task SaveToFileJson()
        {
            var json = JsonConvert.SerializeObject(Tickets);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "json files (*.json)|*.json";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == true)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());
                writer.Write(json);
                writer.Dispose();
                writer.Close();
            }

        }

        public async Task LoadFromFileJson()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Json files (*.json)|*.json";
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == true)
            {
                string filePath = dlg.FileName;
                StreamReader r = new StreamReader(filePath);

                string data = r.ReadToEnd();
                List<Tickets> jsonTickets = JsonConvert.DeserializeObject<List<Tickets>>(data);
                foreach (Tickets Ticket in jsonTickets)
                {
                    Tickets.Add(Ticket);
                }
                r.Close();
            }



            
        }
    }
}
