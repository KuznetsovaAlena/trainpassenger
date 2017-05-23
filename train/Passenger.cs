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

        public string Patro
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

        private string numtrain;

        public string Numtrain
        {
            get { return numtrain; }
            set { numtrain = value; }
        }

        private uint numcar;

        public uint Numcar
        {
            get { return numcar; }
            set { numcar = value; }
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

        public Passenger(string _surname, string _name, string _patro, string _date, string _numtrain, uint _numcar, uint _seat, string _departure, string _arrival)
        {
            surname = _surname;
            name = _name;
            patro = _patro;
            date = _date;
            numtrain = _numtrain;
            numcar = _numcar;
            seat = _seat;
            departure = _departure;
            arrival = _arrival;
        }
    }
}
