using CRUD_Personas_ASP.Models;
using CRUD_Personas_BL;
using CRUD_Personas_Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            PersonasBL gestoraPersonas = new PersonasBL();
            List<clsPersona> listadoBase = gestoraPersonas.ListadoCompleto();
            List<clsPersonaConNombreDepartamento> personasDepartamentos = new();
            foreach (clsPersona personaAux in listadoBase)
            {
                personasDepartamentos.Add(new clsPersonaConNombreDepartamento(personaAux.Id, personaAux.Nombre, personaAux.Apellido, personaAux.FechaNacimiento, personaAux.Telefono, personaAux.Direccion, personaAux.Foto, personaAux.IdDepartamento));
            }
            return View("../Personas/ListadoPersonas", personasDepartamentos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
