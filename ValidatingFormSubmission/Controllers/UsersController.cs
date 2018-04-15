using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ValidatingFormSubmission.Models;

namespace ValidatingFormSubmission.Controllers
{
  
  public class UsersController: Controller
  {
      [HttpGet, Route("")]
      public IActionResult Index()
      {
        return View("Form");
      }

      [HttpPost, Route("users")]
      public IActionResult AddUser(string firstName, string lastName, int age, string email, string password)
      {
          User NewUser = new User
          {
              FirstName = firstName,
              LastName = lastName,
              Age = age,
              Email = email,
              Password = password
          };
        // Validates the specified model instance.
        TryValidateModel(NewUser);
        Console.WriteLine(ModelState.Keys);

        if (!TryValidateModel(NewUser))
        {
          TempData["validity"] = ModelState.IsValid;
          int keyNum = 0;
          
          foreach(var error in ModelState)
          {
              string tempKey = "key" + keyNum;
              if (error.Value.Errors.Count > 0)
              {
                TempData[error.Key] = error.Value.Errors[0].ErrorMessage;
              }
              keyNum++;
          }
        }
          return RedirectToAction("Index");
    }
  }
}