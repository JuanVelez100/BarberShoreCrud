using BarberEntity.Entity;
using BarberShore.Models;
using BarberShoreLogic.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private PersonaLogic personaLogic = new PersonaLogic();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string name = "")
        {
            return View(personaLogic.GetAllPerson(name));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PersonaEntity personaEntity)
        {
            var person = personaLogic.AddPerson(personaEntity);

            ViewBag.Message = person.Message;
            ViewBag.Type = person.Type;

            return View(personaEntity);
        }

        public IActionResult Edit(string cedula)
        {
            var person = personaLogic.GetPersonForCedula(cedula);

            ViewBag.Message = person.Message;
            ViewBag.Type = person.Type;

            return View(person);
        }


        [HttpPost]
        public IActionResult Edit(PersonaEntity personaEntity)
        {
            var person = personaLogic.UpdatePerson(personaEntity);

            ViewBag.Message = person.Message;
            ViewBag.Type = person.Type;

            return View(personaEntity);
        }


        public IActionResult Delete(string cedula)
        {
            var person = personaLogic.GetPersonForCedula(cedula);

            ViewBag.Message = person.Message;
            ViewBag.Type = person.Type;

            return View(person);
        }

        [HttpGet]
        public IActionResult DeleteConfirm(string cedula)
        {

            var person = personaLogic.DeletePerson(cedula);

            ViewBag.Message = person.Message;
            ViewBag.Type = person.Type;

            return View(person);
        }




    }
}
