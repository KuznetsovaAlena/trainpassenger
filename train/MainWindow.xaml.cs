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
            Pass.Clear();
            foreach (Passenger p in Passengers)
            {
                if ((p.Departure == departure.Text) & (p.Arrival == arrival.Text) & (p.Date == date.Text) & (p.Train == number.Text))
                {
                    Pass.Add(p);
                }
            }
            info.ItemsSource = null;
            info.ItemsSource = Pass;

            departure.Text = null;
            arrival.Text = null;
            date.Text = null;
            number.ItemsSource = null;
            Train_number.Clear();
        }
        List<string> Train_number = new List<string>();

        private void conf_Click(object sender, RoutedEventArgs e)
        {
            List<string> Train_number = new List<string>();


            int k = 0;

            Passengers.Clear();
            using (StreamReader sr = new StreamReader("../../base.txt", Encoding.GetEncoding(1251)))
                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine();

                    string surname = line.Split('/')[0];
                    string name = line.Split('/')[1];
                    string patro = line.Split('/')[2];
                    string date = line.Split('/')[3];
                    string train = line.Split('/')[4];
                    uint carriage = uint.Parse(line.Split('/')[5]);
                    uint seat = uint.Parse(line.Split('/')[6]);
                    string departure = line.Split('/')[7];
                    string arrival = line.Split('/')[8];

                    Passengers.Add(new Passenger(surname, name, patro, date, train, carriage, seat, departure, arrival));
                }

            foreach (Passenger p in Passengers)
            {
                if ((p.Departure == departure.Text) & (p.Arrival == arrival.Text) & (p.Date == date.Text))
                { k = 0;
                    for (int i = 0; i < Train_number.Count; i++)
                    
                     

                        if (p.Train == Train_number[i])
                        {
                            k++;
                        }

                        if (k == 0)

                            Train_number.Add(p.Train);
                    

                }

            }
            if (Train_number.Count == 0)

            {

                MessageBox.Show("Такого поезда нет!");
            }



            number.ItemsSource = Train_number;


        }

        private void searchwindow_Click(object sender, RoutedEventArgs e)
        {

            Search Search = new Search();
            Search.Show();

        }

        private void editor_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = new FileStream("../../base.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                {
                    for (int i = 0; i < Passengers.Count; i++)
                    {
                        sw.Write(Passengers[i].Surname.ToString() + "/" + Passengers[i].Name.ToString() + "/" + Passengers[i].Patronymic.ToString() + "/" + Passengers[i].Date.ToString() + "/" + Passengers[i].Train.ToString() + "/" + Passengers[i].Carriage.ToString() + "/" + Passengers[i].Seat.ToString() + "/" + Passengers[i].Departure.ToString() + '/' + Passengers[i].Arrival.ToString());
                        sw.WriteLine();
                    }
                }

            }
            MessageBox.Show("Изменения сохранены!");
        }

        private void deletion_Click(object sender, RoutedEventArgs e)
        {
            int ind = info.SelectedIndex + 1;

            if (ind == 0)
                MessageBox.Show("Выберите пассажира!");
            else
            {
                MessageBoxResult result;
                result = MessageBox.Show("Вы уверены, что хотите удалить пассажира " + Pass[ind - 1].Surname + " " + Pass[ind - 1].Name + " " + Pass[ind - 1].Patronymic + "?", "Удаление элемента", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    
                            Pass.RemoveAt(ind - 1);
                    
                        info.ItemsSource = null;
                        info.Columns.Clear();
                        info.ItemsSource = Pass;
                    }
                }

            }

       
    }

    }

    
    

