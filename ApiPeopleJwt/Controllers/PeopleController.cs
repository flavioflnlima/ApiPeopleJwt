using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPeopleJwt.Models;
using System;

namespace ApiPeopleJwt.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/pessoas")]

    public class PeopleController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<PeopleViewModel>>> Get([FromServices] DataContext context)
        {
            var people = await context.People.ToListAsync();
            return people;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PeopleViewModel>> Get([FromServices] DataContext context, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var people = await context.People.FindAsync(id);

            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }


        [HttpPost]
        public async Task<ActionResult<PeopleViewModel>> Post([FromServices] DataContext context, [FromBody] PeopleViewModel people)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.People.Add(people);
            await context.SaveChangesAsync();
            return people;

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PeopleViewModel>> Put([FromServices] DataContext context, [FromRoute] int id, [FromBody] PeopleViewModel people)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != people.Id)
            {
                return BadRequest();
            }

            context.Entry(people).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeopleExists(context, id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PeopleViewModel>> Delete([FromServices] DataContext context, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var people = await context.People.FindAsync(id);
            if (people == null)
            {
                return NotFound();
            }

            context.People.Remove(people);
            await context.SaveChangesAsync();

            return Ok(people);
        }

        private bool PeopleExists([FromServices] DataContext context, int id)
        {
            return context.People.Any(e => e.Id == id);
        }
    }
}