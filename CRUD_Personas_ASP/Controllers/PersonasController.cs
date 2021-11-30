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
        PersonasBL gestoraPersonas;
        List<clsPersona> listadoBase;
        // GET: PersonasController
        public ActionResult Index()
        {
            gestoraPersonas = new PersonasBL();
            ActionResult result;
            try
            {
                listadoBase = gestoraPersonas.ListadoCompleto();
                List<clsDepartamento> listadoDptos=new DepartamentosBL().ListadoCompleto();
                List<clsPersonaConNombreDepartamento> personasDepartamentos = new();
                foreach (clsPersona personaAux in listadoBase)
                {
                    personasDepartamentos.Add(new clsPersonaConNombreDepartamento(personaAux.Id, personaAux.Nombre, personaAux.Apellido, personaAux.FechaNacimiento,
                        personaAux.Telefono, personaAux.Direccion, personaAux.Foto, personaAux.IdDepartamento, listadoDptos[personaAux.IdDepartamento].Nombre));
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
            gestoraPersonas = new PersonasBL();
            listadoBase = gestoraPersonas.ListadoCompleto();
            List<clsDepartamento> listadoDptos = new DepartamentosBL().ListadoCompleto();
            clsPersona personaSeleccionada = gestoraPersonas.LeerPpersonaPorId(id);
            clsPersonaConNombreDepartamento personaConDptos = new clsPersonaConNombreDepartamento(personaSeleccionada.Id, personaSeleccionada.Nombre, personaSeleccionada.Apellido, 
                personaSeleccionada.FechaNacimiento, personaSeleccionada.Telefono, personaSeleccionada.Direccion, personaSeleccionada.Foto, personaSeleccionada.IdDepartamento, 
                listadoDptos[personaSeleccionada.IdDepartamento].Nombre);

            return View("DetallesPersona",personaConDptos);
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            clsPersonaConListadoDepartamentos nuevaPersonaConDptos = new clsPersonaConListadoDepartamentos();
            return View("CreatePersona",nuevaPersonaConDptos);
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            ActionResult actionResult;
            try
            {
                clsPersona p = new clsPersona(collection["Nombre"], collection["Apellido"], DateTimeOffset.Parse(collection["FechaNacimiento"]), collection["Telefono"], collection["Direccion"],
                    collection["Foto"], int.Parse(collection["IdDepartamento"]));
                gestoraPersonas = new PersonasBL();
                gestoraPersonas.AgregarPersona(p);
                actionResult = RedirectToAction(nameof(Index));
            }
            catch
            {
                actionResult=View("CreatePersona");
            }
            return actionResult;
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            gestoraPersonas = new PersonasBL();
            clsPersona personaSeleccionada = gestoraPersonas.LeerPpersonaPorId(id);
            clsPersonaConListadoDepartamentos personaConDptos = new clsPersonaConListadoDepartamentos(personaSeleccionada.Id, personaSeleccionada.Nombre, personaSeleccionada.Apellido, 
                personaSeleccionada.FechaNacimiento, personaSeleccionada.Telefono, personaSeleccionada.Direccion, personaSeleccionada.Foto, personaSeleccionada.IdDepartamento);

            return View("EditPersona", personaConDptos);
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            ActionResult result;
            gestoraPersonas = new PersonasBL();
            try
            {
                clsPersona personaEditada = new clsPersona(int.Parse(collection["Id"]),collection["Nombre"], collection["Apellido"], DateTimeOffset.Parse(collection["FechaNacimiento"]), 
                    collection["Telefono"], collection["Direccion"], collection["Foto"], int.Parse(collection["IdDepartamento"]));
                gestoraPersonas.EditarPersona(personaEditada);
                result= RedirectToAction(nameof(Index));
            }
            catch
            {
                result= View("EditPersona");
            }
            return result;
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            gestoraPersonas = new PersonasBL();
            clsPersona personaSeleccionada = gestoraPersonas.LeerPpersonaPorId(id);
            clsPersonaConNombreDepartamento personaConDptos = new clsPersonaConNombreDepartamento(personaSeleccionada.Id, personaSeleccionada.Nombre, personaSeleccionada.Apellido,
                personaSeleccionada.FechaNacimiento, personaSeleccionada.Telefono, personaSeleccionada.Direccion, personaSeleccionada.Foto, personaSeleccionada.IdDepartamento);

            return View("Delete", personaConDptos);
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ActionResult result;
            gestoraPersonas = new PersonasBL();
            try
            {
                clsPersona personaEditada = gestoraPersonas.LeerPpersonaPorId(id);
                gestoraPersonas.EliminarPersona(personaEditada);
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
