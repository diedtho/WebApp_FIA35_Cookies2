using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_FIA35_Cookies2.Models;

namespace WebApp_FIA35_Cookies2.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Person person = new();


            return View(person);
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            if (ModelState.IsValid)
            {
                HttpContext.Response.Cookies.Append("KeksPersonNachname", person.Nachname, new CookieOptions { Expires = new DateTime(2021, 11, 11) });

                return RedirectToAction("Zweite");
            }                        

            return View(person);
        }


        [HttpGet]
        public IActionResult Zweite(Person person)
        {
            Person newPerson = new();

            if (HttpContext.Request.Cookies["KeksPersonNachname"] != null)
            {
                newPerson.Nachname = HttpContext.Request.Cookies["KeksPersonNachname"];
            }

            return View(newPerson);
        }

        [HttpPost]
        public IActionResult Zweite(Person person, int id)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Ergebnis");
            }

            return View(person);

        }

        [HttpGet]
        public IActionResult Ergebnis(Person person)
        {
            Person newPerson = new();

            newPerson.Nachname = person.Nachname;


            return View(newPerson);
        }
               

    }
}
