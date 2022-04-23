using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiitIPService.ViewModels
{
    public class HomeIndexViewModel
    {
        //mer kod
        public class Employee
        {
            public int EmployeeId { get; set; }
            public string EmployeeFirstName { get; set; }
            public string EmployeeLastName { get; set; }
        }
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
