using CRUD_Personas_ASP.Models;
using CRUD_Personas_BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Personas_ASP.ViewModels
{
    public class ListadoVM
    {
        List<clsPersonaConNombreDepartamento> personasConDepartamento;

        public ListadoVM()
        {
            //personasConDepartamento=new PersonasBL().ListadoCompleto();
        }
    }
}
