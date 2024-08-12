using FireBird.API.Models;

using System;
using System.Linq;

namespace FireBird.API.Data
{
	public class DataSeeder
	{
		private readonly DataContext _context;

		public DataSeeder(DataContext context)
		{
			_context = context;
		}

		public void Init()
		{
			InitPersons();
			InitCars();
		}

		private void InitCars()
		{
			if (_context.Cars.Count() <= 0)
			{
				_context.Cars.Add(new CarModel
				{
					CarId = Guid.Parse("657DC28E-1800-4F46-BBB2-BDD469C6C973"),
					Brand = "Gol",
					Model = "1.0"
				});

				_context.SaveChanges();
			}
		}

		private void InitPersons()
		{
			if (_context.Persons.Count() <= 0)
			{
				_context.Persons.Add(new PersonModel
				{
					PersonId = Guid.Parse("094089BE-E47F-4A51-AE6F-2F292BC6B955"),
					Name = "Maria Joana da Silva Santos",
					CPF = "28629001097",
					BirthDate = DateTime.Parse("2001-02-15"),
					Heigth = 1.87
				});

				_context.SaveChanges();
			}
		}
	}
}