using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPersonLib
{
    public interface IPersonVacation
    {
        public string Name { get; set; }
        public DateTime? StartDateVacation { get; set; }
        public DateTime? EndDateVacation { get; set; }
    }
}
