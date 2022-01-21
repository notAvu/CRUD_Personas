using CRUD_Personas_BL;
using CRUD_Personas_Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUD_Personas_ASP.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Personas : ControllerBase
    {
        // GET: api/<Personas>
        [HttpGet]
        public IEnumerable<clsPersona> Get()
        {
            clsListadoPersonasBL listado = new clsListadoPersonasBL();
            return listado.ListadoCompleto();
        }

        // GET api/<Personas>/5
        [HttpGet("{id}")]
        public clsPersona Get(int id)
        {
            return new clsGestoraPersonasBL().LeerPpersonaPorId(id);
        }

        // POST api/<Personas>
        [HttpPost]
        public void Post([FromBody] clsPersona persona)
        {
            new clsGestoraPersonasBL().AgregarPersona(persona);
        }

        // PUT api/<Personas>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] clsPersona persona)
        {

            new clsGestoraPersonasBL().EditarPersona(persona);

        }

        // DELETE api/<Personas>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IActionResult statuscode;
            try
            {
                new clsGestoraPersonasBL().EliminarPersona(id);
                statuscode =Ok();
            }/*
              if(filasAfectadas=0)
            {
            statuscode=X;
            }
              */
            catch (Exception e)
            {
                statuscode = BadRequest();
            }
            return statuscode;
        }
    }
}
