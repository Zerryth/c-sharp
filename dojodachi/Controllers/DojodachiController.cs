using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
// using System.Linq;

namespace dojodachi.Controllers
{
    public class DojodachiController: Controller
    {
        Dictionary<string, object> res = new Dictionary<string, object>();
        private static Random rand = new Random();

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("feed/{fullness}/{meals}")]
        public JsonResult Feed(int fullness, int meals)
        {
            int fullnessIncrease = 0;
            res["message"] = "You need to have meals in order to feed your 'Dachi!";
            res["fullness"] = fullness;
            if (meals > 0)
            {
                res["meals"] = meals - 1;
                if (Likes())
                {
                    fullnessIncrease = rand.Next(5, 11);
                    res["fullness"] = fullness + fullnessIncrease;
                    res["message"] = $"You fed your Dojodachi (Fullness +{fullnessIncrease}, Meals -1)";
                }
                else
                {
                    res["message"] = "Dojodachi doesn't feel like eating. (Fullness +0, Meals -1)";
                }
            }
            return Json(res);
        }

        public bool Likes()
        {
            bool likes = true;
            if (rand.Next(1,101) <= 25)
            {
                likes = false;
            }
            return likes;
        }

        [HttpGet]
        [Route("play/{happiness}/{energy}")]
        public JsonResult Play(int happiness, int energy)
        {
            int happinessIncrease = rand.Next(5, 11);
            res["happiness"] = happiness;
            res["message"] = "Your Dojodachi needs energy in order to play.";
            if (energy >= 5)
            {
                res["energy"] = energy - 5;
                if (Likes())
                {
                    res["happiness"] = happiness + happinessIncrease;
                    res["message"] = $"You played with your Dojodachi! (Happiness +{happinessIncrease}, Energy -5)";
                }
                else
                {
                    res["message"] = "Your Dojodachi doesn't feel like playing. (Happiness +0, Energy -5)";
                }
            }
            return Json(res);
        }

        [HttpGet]
        [Route("sleep/{energy}/{fullness}/{happiness}")]
        public JsonResult Sleep(int energy, int fullness, int happiness)
        {
            res["energy"] = energy + 15;
            res["fullness"] = fullness - 5;
            res["happiness"] = happiness - 5;
            res["message"] = "Your Dojodachi slept. (Energy +15, Fullness -5, Happiness -5)";
            return Json(res);
        }

        [HttpGet]
        [Route("work/{meals}/{energy}")]
        public JsonResult Work(int meals, int energy)
        {
            int mealIncrease = rand.Next(1,4);
            res["meals"] = meals;
            res["message"] = "Your Dojodachi needs at least 5 energy in order to work.";
            if (energy >= 5)
            {
                res["energy"] = energy - 5;
                res["meals"] = meals + mealIncrease;
                res["message"] = $"You worked with 'Dachi! (Meals +{mealIncrease}, Energy: -5)";
            }
            return Json(res);
        }
    }
}