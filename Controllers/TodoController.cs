using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using simple_todoapi.Models;

namespace simple_todoapi.Controllers
{
    [Route("api/todo/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoDBContext _context;

        public TodoController(TodoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            return await _context.Todo.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodoById(int id)
        {
            try
            {
                var todo = await _context.Todo.FirstAsync(id);

                if (todo == null)
                    return NotFound();

                return todo;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo(Todo todo)
        {
        
           if(todo ==null)
            return BadRequest();

            _context.Todo.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodos),new {id= todo.Id},todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(int id,Todo todo)
        {
            if(id != todo.Id)
              return BadRequest();

            var existingTodo = await _context.Todo.FirstAsync(t=> t.Id == id);

            if(existingTodo ==null)
            return NotFound();

            _context.Todo.Attach(existingTodo);
           
           existingTodo.Name = todo.Name;
           existingTodo.Status = todo.Status;

           await _context.SaveChangesAsync();

           return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var todo = await _context.Todo.FindAsync(id);

            if(todo == null)
            return NotFound();
           
           _context.Todo.Remove(todo);
           await _context.SaveChangesAsync();

           return NoContent();
        }
    }
}
