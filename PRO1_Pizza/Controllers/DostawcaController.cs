using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRO1_Pizza.Models;

namespace PRO1_Pizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DostawcaController : ControllerBase
    {
        private s16695Context _context;
        public DostawcaController(s16695Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDostawca()
        {
            return Ok(_context.Dostawca.ToList());
        }

        //api/dostawca/4
        [HttpGet("{id:int}")]
        public IActionResult getDostawca(int id)
        {
            var emp = _context.Dostawca.FirstOrDefault(d => d.IdDostawcy == id);
            if (emp == null)
            {
                return NotFound();
            }
            else
                return Ok(emp);
        }


        [HttpPut]
        public IActionResult Update(Dostawca upddost)
        {

            if (_context.Dostawca.Count(e => e.IdDostawcy == upddost.IdDostawcy) == 0)
            {
                return NotFound();
            }
            _context.Dostawca.Attach(upddost);
            _context.Entry(upddost).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(upddost);

        }


        [HttpDelete("{id:int}")]
        public IActionResult RemoveDostawca(int id)
        {
            var dost = _context.Dostawca.FirstOrDefault((d => d.IdDostawcy == id));
            if (dost == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(dost);
                _context.SaveChanges();
                return Ok("usunieto uzytkownika");
            };

        }

        [HttpPost]
        public IActionResult AddDostawca(Dostawca dost)
        {
            _context.Dostawca.Add(dost);
            _context.SaveChanges();
            return StatusCode(201, dost);

        }
    }
}