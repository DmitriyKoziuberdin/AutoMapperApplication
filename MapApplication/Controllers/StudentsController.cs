using AutoMapper;
using MapApplication.Data.Models;
using MapApplication.Data.Models.DTOs.Incoming;
using MapApplication.Data.Models.DTOs.Outcoming;
using Microsoft.AspNetCore.Mvc;

namespace MapApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static List<Students> students = new List<Students>();
        private readonly IMapper _mapper;

        public StudentsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var st = students.ToList();
            var driverList = _mapper.Map<IEnumerable<StudentDto>>(st);
            return Ok(driverList);
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentCreationDto studentDto)
        {
            var newStudent = _mapper.Map<Students>(studentDto);
            students.Add(newStudent);
            return Ok(newStudent);
        }

        [HttpGet("{id}")]
        public IActionResult GetSomeStudent(Guid id)
        {
            var someStudent = students.FirstOrDefault(x => x.Id == id);
            if (someStudent == null)
                return NotFound();

            return Ok(someStudent);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Guid id, Students someStudents)
        {
            if (id != someStudents.Id)
                return BadRequest();

            var existStudent = students.FirstOrDefault(studentId => studentId.Id == id);

            if (existStudent == null)
                return BadRequest();

            existStudent.FrstName = someStudents.FrstName;
            existStudent.LastName = someStudents.LastName;
            existStudent.StudentNumber = someStudents.StudentNumber;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(Guid id)
        {
            var existStudent = students.FirstOrDefault(studentId => studentId.Id == id);

            if (existStudent == null)
                return BadRequest();

            students.Remove(existStudent);
            return Ok();
        }
    }
}
