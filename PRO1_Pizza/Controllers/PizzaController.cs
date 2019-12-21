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
    public class PizzaController : ControllerBase
    {
        private s16695Context _context;
        public PizzaController(s16695Context context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetPizza()
        {
            return Ok(_context.Pizza.ToList());
        }

        //api/Pizza/4
        [HttpGet("{id:int}")]
        public IActionResult getPizza(int id)
        {
            var piz = _context.Pizza.FirstOrDefault(d => d.IdPizza == id);
            if (piz == null)
            {
                return NotFound();
            }
            else
                return Ok(piz);
        }


        [HttpPut]
        public IActionResult Update(Pizza piz)
        {

            if (_context.Pizza.Count(e => e.IdPizza == piz.IdPizza) == 0)
            {
                return NotFound();
            }
            _context.Pizza.Attach(piz);
            _context.Entry(piz).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return Ok(piz);

        }


        [HttpDelete("{id:int}")]
        public IActionResult RemovePizza(int id)
        {
            var dost = _context.Pizza.FirstOrDefault((d => d.IdPizza == id));
            if (dost == null)
            {
                return NotFound();
            }
            else
            {
                _context.Remove(dost);
                _context.SaveChanges();
                return Ok("usunieto Pizze");
            };

        }

        [HttpPost]
        public IActionResult AddPizza(Pizza piz)
        {
            _context.Pizza.Add(piz);
            _context.SaveChanges();
            return StatusCode(201, piz);

        }
    }
}