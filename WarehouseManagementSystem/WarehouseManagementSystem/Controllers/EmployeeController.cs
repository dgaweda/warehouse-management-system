using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace warehouse_management_system.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IRepository<Employee> employeeRepository;

        public EmployeeController(IRepository<Employee> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<Employee> GetAllEmployees() => employeeRepository.GetAll();

        [HttpGet]
        [Route("{employeeId}")]
        public Employee GetEmployeeById(int employeeId) => employeeRepository.GetById(employeeId);
    }
}
