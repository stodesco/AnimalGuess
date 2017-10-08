using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AnimalGuess.Models;
using AnimalGuess.Persistence;

namespace AnimalGuess.Controllers
{
    public class HomeController : Controller
    {
        private AnimalGuessDbContext _dbContext;

        public HomeController(AnimalGuessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index(string answer, int questionId)
        {
			//inital setup
			var animals = _dbContext.Animals.Select(a => a).ToList();
			if (animals.Count < 2)
			{
				var elephant = new Animal
				{
					AnimalId = 1,
					Description = "Elephant"
				};
				var lion = new Animal
				{
					AnimalId = 2,
					Description = "Lion"
				};
				_dbContext.Hints.AddRange(
					new Hint { Description = "has a trunk", HintId = 1, Animal = elephant },
					new Hint { Description = "trumpets", HintId = 2, Animal = elephant },
					new Hint { Description = "is grey", HintId = 3, Animal = elephant },
					new Hint { Description = "has a mane", HintId = 4, Animal = lion },
					new Hint { Description = "roars", HintId = 5, Animal = lion },
					new Hint { Description = "is yellow", HintId = 6, Animal = lion }
				);
				_dbContext.Animals.AddRange(elephant, lion);
				_dbContext.SaveChanges();
			}
            if (answer == "yes" && questionId > -1)
            {
                if (questionId > 0)
                {
                    var hint = _dbContext.Hints.Find(questionId);
                    ViewData["Question"] = $"is it a {hint.Animal.Description}?";
                    ViewData["QuestionId"] = 0;
                }
                else
                {
					ViewData["Question"] = $"Let's play another round!";
					ViewData["QuestionId"] = -1;
				}
            }
            else
            {
                var hints = _dbContext.Hints.Select(h => h).ToArray();
                var rand = new Random();
                var index = rand.Next(hints.Count());
                ViewData["Question"] = hints[index].Description;
                ViewData["QuestionId"] = hints[index].HintId;
            }
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

			
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
			return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
