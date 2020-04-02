using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public string GetStudents([FromQuery] string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski sortowanie={orderBy}";
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
            //return StatusCode((int)HttpStatusCode.Created);
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromRoute] int id)
        {
            int i = Response.StatusCode;
            if (id == 1)
            {
                return Ok(i + " Aktualizacja dokończona");
            }
            return NotFound("Nie znaleziono studenta");
        }
        

        [HttpDelete("{id}")]
        public IActionResult RemoveStudent([FromRoute] int id)
        {
            int i = Response.StatusCode;
            if (id == 1)
            {
                return Ok(i + " Usuwanie zakończone");
            }
            else if (id == 2)
            {
                return Ok(i + " Usuwanie zakończone");
            }
            return NotFound("Nie znaleziono studenta");
        }


        [HttpGet("{id}")]

        public IActionResult GetStudentsById([FromRoute] int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            }
            else if (id == 2)
            {
                return Ok("Malewski");
            }
            return NotFound("Nie znaleziono studenta");
        }

    }
}