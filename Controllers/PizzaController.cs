using System.Diagnostics;
using DotnetWebApiWithEFCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotnetWebApiWithEFCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly SampleDBContext _context;

        public PizzaController(SampleDBContext context)
        {
            _context = context;
        }

        // GET: api/Pizz
        [HttpGet]
        public ActionResult<IEnumerable<Pizza>> GetPizzas()
        {
            return _context.Pizza.ToList();
        }

        // GET: api/Pizza/1
        [HttpGet("{id}")]
        public ActionResult<Pizza> GetPizza(int id)
        {
            var pizza = _context.Pizza.Find(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return pizza;
        }

        // POST: api/Pizza
        [HttpPost]
        public ActionResult<Pizza> CreatePizza(Pizza pizza)
        {
            if (pizza == null)
            {
                return BadRequest();
            }
            _context.Pizza.Add(pizza);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetPizza), new { id = pizza.Id }, pizza);
        }

        //PUT: api/Pizza
        [HttpPut("{id}")]
        public IActionResult UpdatePizza(int id, Pizza pizza)
        {
            try
            {
                if (pizza.Id != id)
                {
                    return BadRequest();
                }

                var existingPizza = _context.Pizza.Find(id);

                if (existingPizza == null)
                    return NotFound();

                // Attach the existing pizza to the context for tracking
                _context.Pizza.Attach(existingPizza);

                existingPizza.Name = pizza.Name;
                existingPizza.IsGlutenFree = pizza.IsGlutenFree;

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            var pizza = _context.Pizza.Find(id);

            if (pizza == null)
                return NotFound();

            _context.Pizza.Remove(pizza);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
