using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonVacationLib
{
    public class DepartmentList
    {
        public DepartmentList()
        {
            _allDepartments = new List<Department>();
        }
        private List<Department> _allDepartments;
        public List<Department> AllDepartments
        {
            get => _allDepartments;
            set
            {
                _allDepartments = value;
            }
        }
    }
}
