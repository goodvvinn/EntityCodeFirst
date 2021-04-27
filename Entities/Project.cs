using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }

        public virtual List<EmployeeProject> EmployeeProject { get; set; } = new List<EmployeeProject>();
    }
}
