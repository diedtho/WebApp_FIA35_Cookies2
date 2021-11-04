using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                string jsonString = JsonConvert.SerializeObject(person);
                HttpContext.Response.Cookies.Append("KeksPerson", jsonString, new CookieOptions { Expires = new DateTime(2021, 11, 11) });

                return RedirectToAction("Zweite");
            }

            return View(person);
        }


        [HttpGet]
        public IActionResult Zweite()
        {

            if (HttpContext.Request.Cookies["KeksPerson"] != null)
            {
                Person deserializedPerson = JsonConvert.DeserializeObject<Person>(HttpContext.Request.Cookies["KeksPerson"]);
                return View(deserializedPerson);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Zweite(Person person)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Request.Cookies["KeksPerson"] != null)
                {
                    Person deserializedPerson = JsonConvert.DeserializeObject<Person>(HttpContext.Request.Cookies["KeksPerson"]);
                    deserializedPerson.Vorname = person.Vorname;
                    deserializedPerson.Alter = person.Alter;

                    string jsonString = JsonConvert.SerializeObject(deserializedPerson);
                    HttpContext.Response.Cookies.Append("KeksPerson", jsonString, new CookieOptions { Expires = new DateTime(2021, 11, 11) });

                    return RedirectToAction("Ergebnis");
                }
            }

            return View(person);

        }

        [HttpGet]
        public IActionResult Ergebnis()
        {
           
            if (HttpContext.Request.Cookies["KeksPerson"] != null)
            {
                Person deserializedPerson = JsonConvert.DeserializeObject<Person>(HttpContext.Request.Cookies["KeksPerson"]);
                HttpContext.Response.Cookies.Append("KeksPerson", "", new CookieOptions { Expires = DateTime.Today.AddDays(-1) });

                return View(deserializedPerson);
            }

            return RedirectToAction("Index");

        }

    }
}
