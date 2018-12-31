using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_Example.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST_API_Example.Controllers
{
    [Route("api/[controller]")]
    public class ColorsController : Controller
    {
        private readonly ColorContext _context;

        public ColorsController(ColorContext context)
        {
            _context = context;

            if (_context.ColorItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.ColorItems.Add(new Color {Hex = "#fffff"});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> GetColors()
        {
            return await _context.ColorItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColor(long id)
        {
            var colorItem = await _context.FindAsync<Color>(id);

            if (colorItem == null) return NotFound();

            return colorItem;
        }

        [HttpPost]
        public async Task<ActionResult<Color>> PostTodoItem([FromBody] Color inColor)
        {
            Console.WriteLine(inColor.Hex);
            _context.ColorItems.Add(inColor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColor", new { id = inColor.Id }, inColor);
        }

    }
}