using FireBird.API.Data;
using FireBird.API.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireBird.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonsController : ControllerBase
	{
		private readonly DataContext _context;

		public PersonsController(DataContext context)
		{
			_context = context;
		}

		// POST: api/Persons
		[HttpPost]
		public async Task<ActionResult<PersonModel>> AddPersonAsync([FromBody] PersonModel newData)
		{
			_context.Persons.Add(newData);
			await _context.SaveChangesAsync();

			return Created("api/persons", newData);
		}

		// GET: api/Persons
		[HttpGet]
		public async Task<ActionResult<IEnumerable<PersonModel>>> GetAllPersonsAsync()
		{
			return Ok(await _context.Persons.ToListAsync());
		}

		// GET: api/Persons/5
		[HttpGet("{personId?}")]
		public async Task<ActionResult<PersonModel>> GetPersonAsync(Guid? personId)
		{
			var personModel = await _context.Persons.SingleOrDefaultAsync(person => person.PersonId == personId);

			if (personModel is null)
				return NotFound();

			return Ok(personModel);
		}

		// PUT: api/Persons/5
		[HttpPut("{personId?}")]
		public async Task<IActionResult> UpdatePersonAsync(Guid? personId, [FromBody] PersonModel newData)
		{
			if (personId != newData.PersonId)
				return BadRequest();

			_context.Entry(newData).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException e)
			{
				return _context.Persons.Any(e => e.PersonId == personId) ? throw e : NotFound();
			}

			return Ok(newData);
		}

		// DELETE: api/Persons/5
		[HttpDelete("{personId?}")]
		public async Task<ActionResult<PersonModel>> DeletePersonAsync(Guid? personId)
		{
			var personModel = await _context.Persons.SingleOrDefaultAsync(person => person.PersonId == personId);

			if (personModel == null)
			{
				return NotFound();
			}

			_context.Persons.Remove(personModel);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}