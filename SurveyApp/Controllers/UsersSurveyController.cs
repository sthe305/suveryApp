using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using SurveyApp.Models;
using WebApplication3.Models;

namespace SurveyApp.Controllers
{
    public class UsersSurveyController : Controller
    {
        private readonly AppDataContext _context;

        public UsersSurveyController(AppDataContext context)
        {
            _context = context;
        }

        // GET: UsersSurvey/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UsersSurvey/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SurveyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Surname = model.Surname,
                    FirstNames = model.FirstNames,
                    ContactNumber = model.ContactNumber,
                    Date = model.Date,
                    Age = model.Age,
                    FavouriteFoods = new List<FavouriteFood>(),
                    SurveyQuestions = new List<Question>()
                };

                foreach (var foodName in model.FavouriteFoods.Split(','))
                {
                    var favouriteFood = new FavouriteFood
                    {
                        FoodName = foodName.Trim(),
                        User = user
                    };

                    user.FavouriteFoods.Add(favouriteFood);
                }

                var surveyQuestions = new List<Question>
            {
                new Question { SurveyQuestion = "I like to eat out", Rating = model.EatOutRating, User = user },
                new Question { SurveyQuestion = "I like to watch movies", Rating = model.WatchMoviesRating, User = user },
                new Question { SurveyQuestion = "I like to watch TV", Rating = model.WatchTVRating, User = user },
                new Question { SurveyQuestion = "I like to listen to the radio", Rating = model.ListenToRadioRating, User = user }
            };

                user.SurveyQuestions.AddRange(surveyQuestions);

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Index", "home");
            }

            return View(model);
        }

        public IActionResult SurveyResults()
        {
            // Fetch survey data from the database
            var surveys = _context.Users.Include(u => u.FavouriteFoods).Include(u => u.SurveyQuestions).ToList();

            // Calculate survey statistics
            var totalSurveys = surveys.Count;
            var averageAge = surveys.Average(u => u.Age);
            var maxAge = surveys.Max(u => u.Age);
            var minAge = surveys.Min(u => u.Age);
            var pizzaPercentage = CalculateFoodPercentage(surveys, "Pizza");
            var pastaPercentage = CalculateFoodPercentage(surveys, "Pasta");
            var papWorsPercentage = CalculateFoodPercentage(surveys, "Pap and Wors");
            var eatOutRatingAverage = surveys.Average(u => u.SurveyQuestions.FirstOrDefault(q => q.SurveyQuestion == "I like to eat out")?.Rating ?? 0);
            var watchMoviesRatingAverage = surveys.Average(u => u.SurveyQuestions.FirstOrDefault(q => q.SurveyQuestion == "I like to watch movies")?.Rating ?? 0);
            var watchTVRatingAverage = surveys.Average(u => u.SurveyQuestions.FirstOrDefault(q => q.SurveyQuestion == "I like to watch TV")?.Rating ?? 0);
            var listenToRadioRatingAverage = surveys.Average(u => u.SurveyQuestions.FirstOrDefault(q => q.SurveyQuestion == "I like to listen to the radio")?.Rating ?? 0);

            // Pass the statistics to the view
            var viewModel = new SurveyResultsViewModel
            {
                TotalSurveys = totalSurveys,
                AverageAge = averageAge,
                MaxAge = maxAge,
                MinAge = minAge,
                PizzaPercentage = pizzaPercentage,
                PastaPercentage = pastaPercentage,
                PapWorsPercentage = papWorsPercentage,
                EatOutRatingAverage = eatOutRatingAverage,
                WatchMoviesRatingAverage = watchMoviesRatingAverage,
                WatchTVRatingAverage = watchTVRatingAverage,
                ListenToRadioRatingAverage = listenToRadioRatingAverage
            };

            return View(viewModel);
        }

        private double CalculateFoodPercentage(List<User> surveys, string foodName)
        {
            var totalSurveys = surveys.Count;
            var surveysWithFood = surveys.Count(u => u.FavouriteFoods.Any(f => f.FoodName == foodName));
            var percentage = (double)surveysWithFood / totalSurveys * 100;
            return Math.Round(percentage, 2);
        }
    }
}
