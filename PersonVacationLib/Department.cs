using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonVacationLib
{
    public class Department
    {
        public Department(string name)
        {
            _name = name;
            _personVacations = new List<PersonVacation>();
        }

        public Department()
        {
            _name = "";
            _personVacations = new List<PersonVacation>();
        }

        private string _name;
        private List<PersonVacation> _personVacations;

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length > 0) _name = value;
                else new Exception("Пустое имя");
            }
        }
        public List<PersonVacation> PersonVacations
        {
            get => _personVacations;
            set
            {
                _personVacations = value;
            }
        }
    }
}
