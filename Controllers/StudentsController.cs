using Microsoft.AspNetCore.Mvc;
using DSALab.Models;
using DSALab.Services;

namespace DSALab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentManager _mgr;

        public StudentsController(
            StudentManager mgr)
        {
            _mgr = mgr;
        }

        // Get all students
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_mgr.Snapshot());
        }

        // Add student
        [HttpPost]
        public IActionResult Add(
            AddStudentRequest req)
        {
            var result =
                _mgr.Add(req.RollNumber);

            if (!result.ok)
                return BadRequest(result.msg);

            return Ok(_mgr.Snapshot());
        }

        // Delete student
        [HttpDelete]
        public IActionResult Delete(
            DeleteStudentRequest req)
        {
            var result =
                _mgr.Delete(req.RollNumber);

            if (!result.ok)
                return NotFound(result.msg);

            return Ok(_mgr.Snapshot());
        }

        // Update student
        [HttpPut]
        public IActionResult Update(
            UpdateStudentRequest req)
        {
            var result =
                _mgr.Update(
                    req.OldRollNumber,
                    req.NewRollNumber
                );

            if (!result.ok)
                return NotFound(result.msg);

            return Ok(_mgr.Snapshot());
        }

        // Search student
        [HttpGet("search/{roll}")]
        public IActionResult Search(int roll)
        {
            var result =
                _mgr.Search(roll);

            if (!result.found)
                return NotFound(
                    $"Roll number {roll} NOT found."
                );

            return Ok(result.pos);
        }
    }
}