using CRUD_Personas_ASP.Models;
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
        clsListadoPersonasBL listadoPersonasBL;
        clsGestoraPersonasBL gestoraPersonasBL;
        
        // GET: PersonasController
        public ActionResult Index()
        {
            clsListadoPersonasBL listadoPersonasBL = new clsListadoPersonasBL();
            ActionResult result;
            try
            {
                List<clsPersona>listadoBase = listadoPersonasBL.ListadoCompleto();
                DepartamentosBL gestoraDpto = new DepartamentosBL();
                List<clsDepartamento> listadoDptos=gestoraDpto.ListadoCompleto();
                List<clsPersonaConNombreDepartamento> personasDepartamentos = new();
                foreach (clsPersona personaAux in listadoBase)
                {
                    personasDepartamentos.Add(new clsPersonaConNombreDepartamento(personaAux.Id, personaAux.Nombre, personaAux.Apellido, personaAux.FechaNacimiento,
                        personaAux.Telefono, personaAux.Direccion, personaAux.Foto, personaAux.IdDepartamento /*,listadoDptos[personaAux.IdDepartamento].Nombre*/));
                }
                result= View("ListadoPersonas", personasDepartamentos);
            }
            catch
            {
                result=View("ErrorView");
            }
            return result;
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            clsGestoraPersonasBL gestoraPersonasBL = new clsGestoraPersonasBL();
            clsListadoPersonasBL listadoPersonasBL = new clsListadoPersonasBL();
            List<clsPersona>listadoBase = listadoPersonasBL.ListadoCompleto();
            List<clsDepartamento> listadoDptos = new DepartamentosBL().ListadoCompleto();
            clsPersona personaSeleccionada = gestoraPersonasBL.LeerPpersonaPorId(id);
            clsPersonaConNombreDepartamento personaConDptos = new clsPersonaConNombreDepartamento(personaSeleccionada.Id, personaSeleccionada.Nombre, personaSeleccionada.Apellido, 
                personaSeleccionada.FechaNacimiento, personaSeleccionada.Telefono, personaSeleccionada.Direccion, personaSeleccionada.Foto, personaSeleccionada.IdDepartamento
                /*,listadoDptos[personaSeleccionada.IdDepartamento].Nombre*/);

            return View("DetallesPersona",personaConDptos);
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            clsPersonaConListadoDepartamentos nuevaPersonaConDptos = new clsPersonaConListadoDepartamentos();
            return View("CreatePersona",nuevaPersonaConDptos);
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
            try
            {
                clsPersonaConListadoDepartamentos p = persona;
                clsGestoraPersonasBL gestoraPersonasBL = new clsGestoraPersonasBL();
                gestoraPersonasBL.AgregarPersona(p);
                ViewBag.Exito = "Se ha creado el registro con éxito";
                ViewBag.Error = "";

                actionResult = View("CreatePersona", persona);
            }
            catch
            {
                ViewBag.Exito = "";
                ViewBag.Error = "Se ha producido un error, por favor, intentelo de nuevo";
                actionResult = View("CreatePersona");
            }

            return actionResult;
        }
        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            clsGestoraPersonasBL gestoraPersonasBL = new clsGestoraPersonasBL();
            clsPersona personaSeleccionada = gestoraPersonasBL.LeerPpersonaPorId(id);
            clsPersonaConListadoDepartamentos personaConDptos = new clsPersonaConListadoDepartamentos(personaSeleccionada.Id, personaSeleccionada.Nombre, personaSeleccionada.Apellido, 
                personaSeleccionada.FechaNacimiento, personaSeleccionada.Telefono, personaSeleccionada.Direccion, personaSeleccionada.Foto, personaSeleccionada.IdDepartamento);

            return View("EditPersona", personaConDptos);
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
                gestoraPersonasBL.EditarPersona(persona);
                //result = RedirectToAction(nameof(Index));
                result = View("EditPersona", persona);
                ViewBag.Exito = "Se ha actializado los datos con éxito";
                ViewBag.Error = "";
            }
            catch
            {
                ViewBag.Exito = "";
                ViewBag.Error = "ha ocurrido un error, por favor intentelo de nuevo";
                result = View(persona);
            }
            return result;
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            clsGestoraPersonasBL gestoraPersonasBL = new clsGestoraPersonasBL();
            clsPersona personaSeleccionada = gestoraPersonasBL.LeerPpersonaPorId(id);
            clsPersonaConNombreDepartamento personaConDptos = new clsPersonaConNombreDepartamento(personaSeleccionada.Id, personaSeleccionada.Nombre, personaSeleccionada.Apellido,
                personaSeleccionada.FechaNacimiento, personaSeleccionada.Telefono, personaSeleccionada.Direccion, personaSeleccionada.Foto, personaSeleccionada.IdDepartamento);
            
            return View("Delete", personaConDptos);
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
                ViewBag.Error = "";
                result= RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Error = "ha ocurrido un error, por favor intentelo de nuevo";
                result = View();
            }
            return result;
        }
    }
}
