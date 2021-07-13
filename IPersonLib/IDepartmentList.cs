using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPersonLib
{
    public interface IDepartmentList
    {
        public List<IDepartment> Departments { get; set; }
    }
}
