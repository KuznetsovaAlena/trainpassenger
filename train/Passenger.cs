using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace train
{
    class Passenger
    {
        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string patro;

        public string Patronymic
        {
            get { return patro; }
            set { patro = value; }
        }

        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        private string train;

        public string Train
        {
            get { return train; }
            set { train = value; }
        }

        private uint carriage;

        public uint Carriage
        {
            get { return carriage; }
            set { carriage = value; }
        }

        private uint seat;

        public uint Seat
        {
            get { return seat; }
            set { seat = value; }
        }

        private string departure;

        public string Departure
        {
            get { return departure; }
            set { departure = value; }
        }

        private string arrival;

        public string Arrival
        {
            get { return arrival; }
            set { arrival = value; }
        }

        public Passenger(string _surname, string _name, string _patro, string _date, string _train, uint _carriage, uint _seat, string _departure, string _arrival)
        {
            surname = _surname;
            name = _name;
            patro = _patro;
            date = _date;
            train = _train;
            carriage = _carriage;
            seat = _seat;
            departure = _departure;
            arrival = _arrival;
        }
    }
}
