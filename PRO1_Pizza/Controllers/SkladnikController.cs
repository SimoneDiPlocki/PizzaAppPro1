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

    public class SkladnikController : ControllerBase
    {
        private s16695Context _context;
        public SkladnikController(s16695Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSkladnik()
        {
            return Ok(_context.Skladnik.ToList());
        }

        //api/Skladnik/4
        [HttpGet("{id:int}")]
        public IActionResult getSkladnik(int id)
        {
            var emp = _context.Skladnik.FirstOrDefault(d => d.IdSkladniku == id);
            if (emp == null)
            {
                return NotFound();
            }
            else
                return Ok(emp);
        }


        [HttpPut]
        public IActionResult Update(Skladnik upddost)
        {

            if (_context.Skladnik.Count(e => e.IdSkladniku == upddost.IdSkladniku) == 0)
            {
                return NotFound();
            }
            _context.Skladnik.Attach(upddost);
            _context.Entry(upddost).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(upddost);

        }


        [HttpDelete("{id:int}")]
        public IActionResult RemoveSkladnik(int id)
        {
            var dost = _context.Skladnik.FirstOrDefault((d => d.IdSkladniku == id));
            if (dost == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(dost);
                _context.SaveChanges();
                return Ok("usunieto");
            };

        }

        [HttpPost]
        public IActionResult AddSkladnik(Skladnik dost)
        {
            _context.Skladnik.Add(dost);
            _context.SaveChanges();
            return StatusCode(201, dost);

        }
    }
}