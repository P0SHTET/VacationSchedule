using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using IPersonLib;

namespace PersonVacationLib
{
    [Serializable]
    [KnownType(typeof(Department))]
    public class DepartmentList : IDepartmentList
    {
        public DepartmentList()
        {
            _departments = new List<IDepartment>();
        }
        public DepartmentList(string nameFirstDepartment)
        {
            _departments = new List<IDepartment>();
            _departments.Add(new Department(nameFirstDepartment));
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
