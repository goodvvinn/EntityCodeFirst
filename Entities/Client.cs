using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCodeFirst.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime ContractDate { get; set; }
        public string CooperationType { get; set; }
        public virtual List<Project> Project { get; set; } = new List<Project>();
    }
}
