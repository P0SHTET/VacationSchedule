using System;
using System.Collections.Generic;
using IPersonLib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonVacationLib
{
    public class Department : IDepartment
    {
        public Department(string name)
        {
            _name = name;
            _personVacations = new List<IPersonVacation>();
        }

        public Department()
        {
            _name = "";
            _personVacations = new List<IPersonVacation>();
        }

        private string _name;
        private List<IPersonVacation> _personVacations;

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length > 0) _name = value;
                else new Exception("Пустое имя");
            }
        }
        public List<IPersonVacation> PersonVacations
        {
            get => _personVacations;
            set
            {
                _personVacations = value;
            }
        }
    }
}
