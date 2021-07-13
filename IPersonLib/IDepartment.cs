using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPersonLib
{
    public interface IDepartment
    {
        public string Name { get; set; }
        public List<IPersonVacation> PersonVacations { get; set; }
    }
}
