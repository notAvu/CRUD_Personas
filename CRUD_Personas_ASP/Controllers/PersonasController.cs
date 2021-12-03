using CRUD_Personas_ASP.Models;
using CRUD_Personas_ASP.ViewModels;
using CRUD_Personas_BL;
using CRUD_Personas_Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_ASP.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController
        public ActionResult Index(string funciono)
        {
            ListadoVM vm = new ListadoVM();
            ActionResult result;
            List<clsPersonaSimple> personasDepartamentos;
            try
            {
                ViewData["PersonaCreadaBorrada"] = funciono;
                personasDepartamentos = vm.ListadoPersonasConNombreDepartamento();
                result = View("ListadoPersonasSimple", personasDepartamentos);
            }
            catch
            {
                result = View("ErrorView");
            }
            return result;
        }
        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            ActionResult result;
            try
            {
                result = View("DetallesPersona", PersonaConDptoPorId(id));
            }
            catch
            {
                result = View("ErrorView");
            }
            return result;
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            clsPersonaConListadoDepartamentos nuevaPersonaConDptos = new clsPersonaConListadoDepartamentos();
            return View("CreatePersona", nuevaPersonaConDptos);
        }

        // POST: PersonasController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    ActionResult actionResult;
        //        try
        //        {
        //            clsPersona p = new clsPersona(collection["Nombre"], collection["Apellido"], DateTimeOffset.Parse(collection["FechaNacimiento"]), collection["Telefono"], collection["Direccion"],
        //                collection["Foto"], int.Parse(collection["IdDepartamento"]));
        //            gestoraPersonas = new PersonasBL();
        //            gestoraPersonas.AgregarPersona(p);
        //            actionResult = RedirectToAction(nameof(Index));
        //        }
        //        catch
        //        {
        //            actionResult = View("CreatePersona");
        //        }
        //    return actionResult;
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsPersonaConListadoDepartamentos persona)
        {
            ActionResult actionResult;
            if (ModelState.IsValid)
            {
                try
                {
                    clsGestoraPersonasBL gestoraPersonasBL = new clsGestoraPersonasBL();
                    gestoraPersonasBL.AgregarPersona(persona);
                    actionResult = RedirectToAction(nameof(Index), new { funciono = "Los cambios han sido realizados correctamente" });
                }
                catch (Exception e)
                {
                    actionResult = View("ErrorView");
                }
            }
            else
            {
                actionResult = View(persona);
            }

            return actionResult;
        }
        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            ActionResult result;
            try
            {
                clsGestoraPersonasBL gestoraPersonasBL = new clsGestoraPersonasBL();
                clsPersona personaSeleccionada = gestoraPersonasBL.LeerPpersonaPorId(id);
                clsPersonaConListadoDepartamentos personaConDptos = new clsPersonaConListadoDepartamentos(personaSeleccionada.Id, personaSeleccionada.Nombre, personaSeleccionada.Apellido,
                    personaSeleccionada.FechaNacimiento, personaSeleccionada.Telefono, personaSeleccionada.Direccion, personaSeleccionada.Foto, personaSeleccionada.IdDepartamento);

                result = View("EditPersona", personaConDptos);
            }
            catch(Exception e)
            {
                result = View("ErrorView");
            }
            return result;
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, clsPersonaConListadoDepartamentos persona)
        {
            ActionResult result;
            clsGestoraPersonasBL gestoraPersonasBL = new clsGestoraPersonasBL();
            try
            {
                if (ModelState.IsValid)
                {
                    gestoraPersonasBL.EditarPersona(persona);
                    ViewBag.Exito = "Se han actualizado los datos correctamente";
                    result = View("EditPersona", persona);
                }
                else
                {
                    ViewBag.Exito = "";
                    result = View(persona);
                }
            }
            catch
            {
                result = View("ErrorView");
            }
            return result;
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            ActionResult result;
            try
            {
                result = View("Delete", PersonaConDptoPorId(id));
            }
            catch
            {
                result = View("ErrorView");
            }

            return result;
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, clsPersona persona)
        {
            ActionResult result;
            clsGestoraPersonasBL gestoraPersonasBL = new clsGestoraPersonasBL();
            try
            {
                clsPersona personaEditada = persona;
                gestoraPersonasBL.EliminarPersona(personaEditada);
                result = RedirectToAction(nameof(Index), new { funciono = "Los cambios han sido realizados correctamente" });
            }
            catch
            {
                ViewBag.Error = "ha ocurrido un error, por favor intentelo de nuevo";
                result = View();
            }
            return result;
        }
        private static clsPersonaConNombreDepartamento PersonaConDptoPorId(int id)
        {
            clsGestoraPersonasBL gestoraPersonasBL = new clsGestoraPersonasBL();
            clsPersona personaSeleccionada = gestoraPersonasBL.LeerPpersonaPorId(id);
            clsPersonaConNombreDepartamento personaConDptos = new clsPersonaConNombreDepartamento(personaSeleccionada.Id, personaSeleccionada.Nombre, personaSeleccionada.Apellido,
                personaSeleccionada.FechaNacimiento, personaSeleccionada.Telefono, personaSeleccionada.Direccion, personaSeleccionada.Foto, personaSeleccionada.IdDepartamento);
            return personaConDptos;
        }
    }
}
