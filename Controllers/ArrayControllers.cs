using Microsoft.AspNetCore.Mvc;
using DSALab.Models;
using DSALab.Services;

namespace DSALab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArrayController : ControllerBase
    {
        private readonly ArrayOperations _arr;

        public ArrayController(ArrayOperations arr)
        {
            _arr = arr;

            // Initial data for testing
            if (_arr.Size == 0)
            {
                _arr.Seed(10, 20, 30, 40, 50);
            }
        }

        // ================= TASK 01 =================

        // Traverse
        [HttpGet("traverse")]
        public IActionResult Traverse()
        {
            return Ok(_arr.Snapshot());
        }

        // Insert at End
        [HttpPost("insert-end")]
        public IActionResult InsertEnd(
            InsertEndRequest req)
        {
            if (!_arr.InsertAtEnd(req.Value))
            {
                return BadRequest("Array is full.");
            }

            return Ok(_arr.Snapshot());
        }

        // Insert at Beginning
        [HttpPost("insert-beginning")]
        public IActionResult InsertBeginning(
            InsertBeginningRequest req)
        {
            if (!_arr.InsertAtBeginning(req.Value))
            {
                return BadRequest("Array is full.");
            }

            return Ok(_arr.Snapshot());
        }

        // ================= TASK 02 =================

        // Insert at Position
        [HttpPost("insert-position")]
        public IActionResult InsertPosition(
            InsertPositionRequest req)
        {
            var result =
                _arr.InsertAtPosition(
                    req.Position,
                    req.Value
                );

            if (!result.ok)
                return BadRequest(result.msg);

            return Ok(_arr.Snapshot());
        }

        // Delete at Position
        [HttpDelete("delete-position")]
        public IActionResult DeletePosition(
            DeletePositionRequest req)
        {
            var result =
                _arr.DeleteAtPosition(
                    req.Position
                );

            if (!result.ok)
                return BadRequest(result.msg);

            return Ok(_arr.Snapshot());
        }

        // Delete from End
        [HttpDelete("delete-end")]
        public IActionResult DeleteEnd()
        {
            if (!_arr.DeleteFromEnd())
            {
                return BadRequest("Array is empty.");
            }

            return Ok(_arr.Snapshot());
        }

        // ================= TASK 03 =================

        // Update
        [HttpPut("update")]
        public IActionResult Update(
            UpdateRequest req)
        {
            if (!_arr.UpdateAtPosition(
                    req.Position,
                    req.NewValue))
            {
                return BadRequest("Invalid position.");
            }

            return Ok(_arr.Snapshot());
        }

        // Linear Search
        [HttpPost("search")]
        public IActionResult Search(
            SearchRequest req)
        {
            int index =
                _arr.LinearSearch(req.Key);

            if (index == -1)
            {
                return NotFound("Value not found.");
            }

            return Ok(index);
        }

        // ================= TASK 04 =================

        // Delete from Beginning
        [HttpDelete("delete-beginning")]
        public IActionResult DeleteBeginning()
        {
            if (!_arr.DeleteFromBeginning())
            {
                return BadRequest("Array is empty.");
            }

            return Ok(_arr.Snapshot());
        }

        // Search All - Bonus
        [HttpPost("search-all")]
        public IActionResult SearchAll(
            SearchRequest req)
        {
            return Ok(
                _arr.LinearSearchAll(req.Key)
            );
        }
    }
}