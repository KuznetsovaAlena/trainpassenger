using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace train
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Passenger> Pass = new List<Passenger>();
        List<Passenger> Passengers = new List<Passenger>();
        private void show_Click(object sender, RoutedEventArgs e)
        {
           
            foreach (Passenger p in Passengers)
            {
                if ((p.Departure == departure.Text)&(p.Arrival == arrival.Text)&(p.Date == date.Text)&(p.Numtrain==number.Text))
                {
                    Pass.Add(p);
                }
            }

            info.ItemsSource = Pass;
            
            
        }


        private void conf_Click(object sender, RoutedEventArgs e)
        {

            
            using (StreamReader sr = new StreamReader("base.txt"))
                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine();

                    string surname = line.Split('/')[0];
                    string name = line.Split('/')[1];
                    string patro = line.Split('/')[2];
                    string date = line.Split('/')[3];
                    string numtrain = line.Split('/')[4];
                    uint numcar = uint.Parse(line.Split('/')[5]);
                    uint seat = uint.Parse(line.Split('/')[6]);
                    string departure = line.Split('/')[7];
                    string arrival = line.Split('/')[8];

                    Passengers.Add(new Passenger(surname, name, patro, date, numtrain, numcar, seat, departure, arrival));
                }
            
            List<string> Train_number = new List<string>();

            foreach (Passenger p in Passengers)
            {
                if (p.Departure == departure.Text)
                {
                    if (p.Arrival == arrival.Text)
                    {
                        if (p.Date == date.Text)
                        {
                            Train_number.Add(p.Numtrain);
                        }
                    }
                    }
                }
            if (Train_number.Count==0)

            {

                MessageBox.Show("Такого поезда нет!");
            }
            for (int i = 0; i < Train_number.Count; i++)
            {
                number.Items.Add(Train_number[i]);
            }
            
            }
        }
    }
    

