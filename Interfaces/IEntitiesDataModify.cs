using System.Threading.Tasks;
using EntityCodeFirst.Entities;

namespace EntityCodeFirst.Interfaces
{
    public interface IEntitiesDataModify
    {
        public void JoinTables(Employee employee, Title title, Office office);
        public bool DateGap();
        public bool EntityUpdate(Employee employee, Office office);
        public bool AddEmployeeEntity();
        public bool RemoveEmployeeEntity();
        public bool EmployeeGroupByTitle(Employee employee);
    }
}
