using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using LoginReg.Models;

namespace LoginReg.Controllers
{
  
  public class UsersController: Controller
  {
    private readonly DbConnector _dbConnector;
    public UsersController(DbConnector connect)
    {
      _dbConnector = connect;
    }

      [HttpGet, Route("")]
      public IActionResult Register()
      {
        return View("Registration");
      }

      [HttpGet, Route("login")]
      public IActionResult Login()
      {
        return View ("Login");
      }

      [HttpPost, Route("Login")]
      public IActionResult Login(LoginViewModel user)
      {
        if (ModelState.IsValid)
        {
          var existingUser = _dbConnector.Query($"SELECT * FROM Users WHERE Email = '{user.Email}' ");
          if (existingUser.Count > 0)
          {
            if((string)existingUser[0]["UserPassword"] == user.Password)
            {
              return RedirectToAction("GoToSuccess");
            }
            else 
            {
              user.PasswordError = 1; // out of Range(0,0) => pw match is false
              return View("Login");
            }
          }
          else 
          {
            user.EmailIsInDB = 1;
            TryValidateModel(user);
            return View("Login");
          }
        }
        return View("Login");
      }


      [HttpPost, Route("users")]
      public IActionResult Register(RegisterViewModel NewUser)
      {
          if (ModelState.IsValid)
          {
            var existingUsers = _dbConnector.Query($"SELECT Email FROM Users WHERE Email = '{NewUser.Email}'");
            if (existingUsers.Count == 0)
            {
              _dbConnector.Execute($"INSERT INTO Users (FirstName, LastName, Email, UserPassword, CreatedAt, UpdatedAt) VALUES ('{NewUser.FirstName}', '{NewUser.LastName}', '{NewUser.Email}', '{NewUser.Password}', NOW(), NOW())");
            }
            else {
              NewUser.IsUnique = 1;
              TryValidateModel(NewUser);
              return View("Registration", NewUser);
            }
            return RedirectToAction("GoToSuccess");
          }
          return View("Registration", NewUser);
    }

    [HttpGet, Route("/success")]
    public IActionResult GoToSuccess()
    {
      return View("Success");
    }
  }
}