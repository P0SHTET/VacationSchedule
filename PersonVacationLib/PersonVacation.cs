using System;

namespace PersonVacationLib
{
    public class PersonVacation
    {
        private string _name;
        private DateTime _startDateVacation;
        private DateTime _endDateVacation;
        public string Name 
        { 
            get => _name;            
            set 
            {
                if (value.Length > 0) _name = value;
                else new Exception("Пустое имя");
            }
        }
        public DateTime StartDateVacation
        {
            get => _startDateVacation;
            set 
            {
                _startDateVacation = value;
            }
        }
        public DateTime EndDateVacation
        {
            get => _endDateVacation;
            set
            {
                _endDateVacation = value;
            }
        }
    }
}
