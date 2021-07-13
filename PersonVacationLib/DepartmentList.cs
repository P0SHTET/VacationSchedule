using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPersonLib;

namespace PersonVacationLib
{
    public class DepartmentList : IDepartmentList
    {
        public DepartmentList()
        {
            _departments = new List<IDepartment>();
        }
        private List<IDepartment> _departments;
        public List<IDepartment> Departments
        {
            get => _departments;
            set
            {
                _departments = value;
            }
        }
    }
}
