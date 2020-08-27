using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FizzBuzz.Models;

namespace FizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        //GET index?i=
        public IActionResult Index(int[] i)
        {
            var result = new List<string>();

            foreach (var o in i)
            {
                if (o is int number)
                {
                    //check to see if the number is evenly divisible by 3 and 5 using modulus. 
                    var modThree = number % 3;
                    var modFive = number % 5;

                    //if the number is evenly divisble by 3 and 5, we want fizzbuzz
                    if (modThree + modFive == 0)
                    {
                        result.Add("FizzBuzz");
                    }
                    else
                    {
                        //Since the number is not divisible by 3 and 5, we need to check each case.
                        result.Add(modThree == 0 ? "Fizz" : $"Divided {number} by 3");
                        result.Add(modFive == 0 ? "Buzz" : $"Divided {number} by 5");
                    }
                }
                else
                {
                    result.Add("Invalid Item");
                }
            }

            return View(new FizzBuzzOutput() { Results = result });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
