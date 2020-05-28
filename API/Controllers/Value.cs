using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Db;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValueController : ControllerBase
    {
        private DataContext _context { get; }

        public ValueController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAll()
        {
            //some logic
            return await _context.People.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Details(int id)
        {
            return await _context.People.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Person person)
        {
            System.Console.WriteLine("requested");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.People.Add(person);

            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return Ok();

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, Person person)
        {
            var per = await _context.People.FindAsync(id);

            if (per == null)
                return NotFound();
            per.LastName = person.LastName ?? per.LastName;

            if (await _context.SaveChangesAsync() > 0)
                return Ok();

            return BadRequest();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var per = await _context.People.FindAsync(id);

            if (per == null)
                return NotFound();
            _context.People.Remove(per);
            if (await _context.SaveChangesAsync() > 0)
                return Ok();

            return BadRequest();
        }
    }
}