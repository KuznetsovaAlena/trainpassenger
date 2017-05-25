using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace train
{
    /// <summary>
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();

            
        }

         List<Passenger> SearchPassengers = new List<Passenger>();

        List<Passenger> SearchList = new List<Passenger>();
        private void search_Click(object sender, RoutedEventArgs e)
        {
            SearchList.Clear();
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

                    SearchPassengers.Add(new Passenger(surname, name, patro, date, train, carriage, seat, departure, arrival));
                }
            searchinfo.ItemsSource = null;
            {

                for (int i = 0; i < SearchPassengers.Count; i++)
                {
                    if (SearchPassengers[i].Surname == quest.Text)

                    {
                        SearchList.Add(SearchPassengers[i]);

                    }


                    if (string.IsNullOrWhiteSpace(quest.Text))

                    {
                        MessageBox.Show("Введите фамилию!");
                        return;

                    }

                }
                searchinfo.ItemsSource = SearchList;
                if (SearchList.Count == 0)
                {
                    MessageBox.Show("Таких пассажиров нет! Попробуйте ещё раз!");
                    return;
                }
            }
        }

        private void sdeletion_Click(object sender, RoutedEventArgs e)
        {
            int ind = searchinfo.SelectedIndex + 1;

            if (ind == 0)
                MessageBox.Show("Выберите пассажира!");
            else
            {
                MessageBoxResult result;
                result = MessageBox.Show("Вы уверены, что хотите удалить пассажира " + SearchList[ind - 1].Surname + " " + SearchList[ind - 1].Name + " " + SearchList[ind - 1].Patronymic + "?", "Удаление элемента", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)


                    SearchList.RemoveAt(ind - 1);
                searchinfo.ItemsSource = null;
                searchinfo.Columns.Clear();
                searchinfo.ItemsSource = SearchList;
            }
        }

        private void seditor_Click(object sender, RoutedEventArgs e)
        {

            using (FileStream fs = new FileStream("../../base.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                {
                    for (int i = 0; i < SearchPassengers.Count; i++)
                    {
                        sw.Write(SearchPassengers[i].Surname.ToString() + "/" + SearchPassengers[i].Name.ToString() + "/" + SearchPassengers[i].Patronymic.ToString() + "/" + SearchPassengers[i].Date.ToString() + "/" + SearchPassengers[i].Train.ToString() + "/" + SearchPassengers[i].Carriage.ToString() + "/" + SearchPassengers[i].Seat.ToString() + "/" + SearchPassengers[i].Departure.ToString() + '/' + SearchPassengers[i].Arrival.ToString());
                        sw.WriteLine();
                    }
                }

            }
            MessageBox.Show("Изменения сохранены!");
        }
    }
}

