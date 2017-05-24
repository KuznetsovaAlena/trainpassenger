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
            using (StreamReader sr = new StreamReader("../../base.txt",Encoding.GetEncoding(1251)))
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
        }

        List<Passenger> Pass = new List<Passenger>();
        List<Passenger> Passengers = new List<Passenger>();

        private void show_Click(object sender, RoutedEventArgs e)
        {

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




            foreach (Passenger p in Passengers)
            {
                if (p.Departure == departure.Text)
                {
                    if (p.Arrival == arrival.Text)
                    {
                        if (p.Date == date.Text)
                        {
                            Train_number.Add(p.Train);

                        }
                    }
                }
            }
            if (Train_number.Count == 0)

            {

                MessageBox.Show("Такого поезда нет!");
            }



            number.ItemsSource = Train_number;


        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            {

                List<Passenger> Search = new List<Passenger>();
                for (int i = 0; i < Pass.Count; i++)
                {
                    if (Pass[i].Surname == quest.Text)

                    {
                        MessageBox.Show("Информация о пассажире: " + quest.Text + " " + Pass[i].Name + " " + Pass[i].Patronymic + "\nДата отправления: " + Pass[i].Date + "\nНомер поезда: " + Pass[i].Train + "\nВагон: " + Pass[i].Carriage.ToString() + "\nМесто: " + Pass[i].Seat.ToString() + "\nОтправка: " + Pass[i].Departure + "\nПрибытие: " + Pass[i].Arrival);
                        Search.Add(Pass[i]);
                        return;

                    }

                    if (string.IsNullOrWhiteSpace(quest.Text))

                    {
                        MessageBox.Show("Введите фамилию!");
                        return;

                    }

                }
                if (Search.Count == 0)
                {
                    MessageBox.Show("Такого пассажира нет! Попробуйте ещё раз!");
                    return;
                }
            }
        }

        private void editor_Click(object sender, RoutedEventArgs e)
        { using (FileStream fs = new FileStream("../../base.txt", FileMode.Create))
            { using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                {
                    for (int i = 0; i < Passengers.Count; i++)
                    {
                        sw.Write(Passengers[i].Surname.ToString() + "/" + Passengers[i].Name.ToString() + "/" + Passengers[i].Patronymic.ToString() + "/" + Passengers[i].Date.ToString() + "/" + Passengers[i].Train.ToString() + "/" + Passengers[i].Carriage.ToString() + "/" + Passengers[i].Seat.ToString() + "/" + Passengers[i].Departure.ToString() + '/' + Passengers[i].Arrival.ToString());
                        sw.WriteLine();
                    }
                }

        }
    }

        }
    }
    
    

