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
        List<clsPersona> listadoBase;
        // GET: PersonasController
        public ActionResult Index()
        {
            listadoPersonasBL = new clsListadoPersonasBL();
            ActionResult result;
            try
            {
                listadoBase = listadoPersonasBL.ListadoCompleto();
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
            gestoraPersonasBL = new clsGestoraPersonasBL();
            listadoPersonasBL = new clsListadoPersonasBL();
            listadoBase = listadoPersonasBL.ListadoCompleto();
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
        public ActionResult Create(clsPersona persona)
        {
            ActionResult actionResult;
            try
            {
                clsPersona p = persona;
                gestoraPersonasBL = new clsGestoraPersonasBL();
                gestoraPersonasBL.AgregarPersona(p);
                actionResult = RedirectToAction(nameof(Index));
            }
            catch
            {
                actionResult = View("CreatePersona");
            }

            return actionResult;
        }
        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            gestoraPersonasBL = new clsGestoraPersonasBL();
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
            gestoraPersonasBL = new clsGestoraPersonasBL();
            try
            {
                gestoraPersonasBL.EditarPersona(persona);
                ViewBag.Error = "Error";
                //result = RedirectToAction(nameof(Index));
                result = View("EditPersona", persona);
            }
            catch
            {
                result= View(persona);
            }
            return result;
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            gestoraPersonasBL = new clsGestoraPersonasBL();
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
            gestoraPersonasBL = new clsGestoraPersonasBL();
            try
            {
                clsPersona personaEditada = persona;
                gestoraPersonasBL.EliminarPersona(personaEditada);
                result= RedirectToAction(nameof(Index));
            }
            catch
            {
                result = View();
            }
            return result;
        }
    }
}
