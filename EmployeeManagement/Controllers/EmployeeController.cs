using EmployeeManagement.Models;
using EmployeeManagement.repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {

            _employeeRepository = employeeRepository;
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetByIdAsync1(int id)
        {
            var emp = await _employeeRepository.GetByIdAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            await _employeeRepository.AddEmployeAsync(employee);
            //Console.WriteLine($"Created Employee ID: {employee.Id}");

            return CreatedAtAction(nameof(GetByIdAsync1), new { id = employee.Id }, employee);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllAsync()
        { 
           var allEmployee=await _employeeRepository.GetAllAssync();

            return Ok(allEmployee);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult>DeleteEmployeAsync(int id)
        {
            await _employeeRepository.DeleteEmployeAsync(id);
            return NoContent();
        }


        [HttpPut ("{id}")]
        public async Task<ActionResult<Employee>>UpdeteEmployee(int id, Employee employee )
        {
            if(id != employee.Id)
            {
                return BadRequest();
            }
            await _employeeRepository.UpdateEmployesync(employee);
            return CreatedAtAction(nameof(GetByIdAsync1), new { id = employee.Id }, employee);

        }


        //[HttpPost]
        //[Route("q")]
        //public async Task<ActionResult<Employee>> CreateAsync(Employee employe)
        //{
        //    if (employe == null) {
        //        return BadRequest();
        //    }
        //    if (employe.FirstName == string.Empty||employe.LastName== string.Empty || employe.Position== string.Empty)
        //    {
        //        return BadRequest("Please provide all neccesary information ");
        //    }
        //    await _employeeResository.AddEmployeAsync(employe);
            
        //    return Created();
        //}
    }
}
