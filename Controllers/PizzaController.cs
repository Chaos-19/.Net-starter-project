using DotnetWebApiWithEFCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}