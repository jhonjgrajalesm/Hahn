using HahnTest.Server.Entities;
using HahnTest.Server.Helpers;
using HahnTest.Server.Interfaces;
using HahnTest.Server.Repositories;
using HahnTest.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace HahnTest.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;
        private IEmployeeService _employeeService;
        private UtilitiesHelper _utilitiesHelper;

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeService employeeService, UtilitiesHelper utilitiesHelper)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
            _utilitiesHelper = utilitiesHelper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(_employeeRepository.GetEmployees());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred.", Details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var employee = _employeeRepository.GetEmployeeById(id);

                if (employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred.", Details = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Employee employee)
        {
            try
            {
                employee.Id = _utilitiesHelper.NewId;
                _employeeRepository.Insert(employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred.", Details = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] Employee employee)
        {
            try
            {
                _employeeRepository.Update(employee);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred.", Details = ex.Message });
            }
        }

        [HttpGet("increment/{id}")]
        public IActionResult IncrementSalary(string id)
        {
            try
            {                
                return Ok(_employeeService.CalculareSalaryIncrement(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred.", Details = ex.Message });
            }
        }
    }
}
