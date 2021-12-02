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
        public ActionResult Index(string funciono)
        {
            clsListadoPersonasBL listadoPersonasBL = new clsListadoPersonasBL();
            ActionResult result;
            List<clsPersona> listadoBase;
            List<clsDepartamento> listadoDptos;
            DepartamentosBL gestoraDpto;
            List<clsPersonaConNombreDepartamento> personasDepartamentos;
            try
            {
                ViewData["PersonaCreadaBorrada"] = funciono;
                listadoBase = listadoPersonasBL.ListadoCompleto();
                gestoraDpto = new DepartamentosBL();
                listadoDptos = gestoraDpto.ListadoCompleto();
                personasDepartamentos = (from oPersonaAux in listadoBase
                                         join oDptoAux in listadoDptos on oPersonaAux.IdDepartamento equals oDptoAux.Id
                                         select new clsPersonaConNombreDepartamento()
                                         {
                                             Id = oPersonaAux.Id,
                                             Nombre = oPersonaAux.Nombre,
                                             Apellido = oPersonaAux.Apellido,
                                             FechaNacimiento = oPersonaAux.FechaNacimiento,
                                             Telefono = oPersonaAux.Telefono,
                                             Direccion = oPersonaAux.Direccion,
                                             Foto = oPersonaAux.Foto,
                                             IdDepartamento = oPersonaAux.IdDepartamento,
                                             NombreDepartamento = oDptoAux.Nombre
                                         }).ToList();

                result = View("ListadoPersonas", personasDepartamentos);
            }
            catch
            {
                result = View("ErrorView");
            }
            return result;
        }

        private void findBucle(int idDpto)
        {

        }
        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            gestoraPersonasBL = new clsGestoraPersonasBL();
            clsPersona personaSeleccionada = gestoraPersonasBL.LeerPpersonaPorId(id);
            clsPersonaConNombreDepartamento personaConDptos = new clsPersonaConNombreDepartamento(personaSeleccionada.Id, personaSeleccionada.Nombre, personaSeleccionada.Apellido,
                personaSeleccionada.FechaNacimiento, personaSeleccionada.Telefono, personaSeleccionada.Direccion, personaSeleccionada.Foto, personaSeleccionada.IdDepartamento);

            return View("DetallesPersona", personaConDptos);
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
            try
            {
                //if (ModelState.IsValid)
                //{
                clsPersona p = persona;
                gestoraPersonasBL = new clsGestoraPersonasBL();
                gestoraPersonasBL.AgregarPersona(p);
                actionResult = RedirectToAction(nameof(Index), new { funciono = "Los cambios han sido realizados correctamente" });
                //}
                //else
                //{
                //    actionResult = View("CreatePersona");
                //}
            }
            catch
            {
                actionResult = View("ErrorView");
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
                if (ModelState.IsValid)
                {
                    gestoraPersonasBL.EditarPersona(persona);
                    //result = RedirectToAction(nameof(Index));
                    ViewBag.Error = "";
                    ViewBag.Exito = "Se han actualizado los datos correctamente";
                    result = View("EditPersona", persona);
                }
                else
                {
                    ViewBag.Exito = "";
                    ViewBag.Error = "Ha ocurrido un error, por favor intentelo de nuevo mas tarde";
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
                result = RedirectToAction(nameof(Index), new { funciono = "Los cambios han sido realizados correctamente" });
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
