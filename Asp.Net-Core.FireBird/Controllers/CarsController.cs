using FireBird.API.Data;
using FireBird.API.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FireBird.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly DataContext _context;

		public CarsController(DataContext context)
		{
			_context = context;
		}

		// POST: api/Cars
		[HttpPost]
		public async Task<ActionResult<CarModel>> CreateCardAsync([FromBody] CarModel carModel)
		{
			_context.Cars.Add(carModel);
			await _context.SaveChangesAsync();

			return Created("api/car", carModel);
		}

		// GET: api/Cars
		[HttpGet]
		public async Task<ActionResult<IEnumerable<CarModel>>> GetCarsAsync()
		{
			return await _context.Cars.ToListAsync();
		}

		// GET: api/Cars/5
		[HttpGet("{carId?}")]
		public async Task<ActionResult<CarModel>> GetCarAsync([Required] Guid? carId)
		{
			CarModel carModel = await _context.Cars.SingleOrDefaultAsync(car => car.CarId == carId);

			if (carModel is null)
				return NotFound();

			return Ok(carModel);
		}

		// PUT: api/Cars/5
		[HttpPut("{carId?}")]
		public async Task<IActionResult> UpdateCarAsync([Required] Guid? carId, [FromBody] CarModel newData)
		{
			if (carId != newData.CarId)
				return BadRequest();

			_context.Entry(newData).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException e)
			{
				return _context.Cars.Any(e => e.CarId == carId) ? throw e : NotFound();
			}

			return Ok(newData);
		}

		// DELETE: api/Cars/5
		[HttpDelete("{carId?}")]
		public async Task<ActionResult<CarModel>> DeleteCarAsync([Required] Guid? carId)
		{
			CarModel carModel = await _context.Cars.SingleOrDefaultAsync(car => car.CarId == carId);

			if (carModel is null)
				return NotFound();

			_context.Cars.Remove(carModel);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}