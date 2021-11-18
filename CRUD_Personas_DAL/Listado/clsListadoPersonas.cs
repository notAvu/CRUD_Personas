using _07_CRUD_Personas_DAL.Conexion;
using Entities_UWP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Listado
{
    class clsListadoPersonas
    {
        List<clsPersona> listadoCompleto;
        clsMyConnection conexion= new clsMyConnection();

        public List<clsPersona> ListadoCompleto { get => listadoCompleto; set => listadoCompleto = value; }

        private void executeConnection() {
            SqlConnection sqlConnection= conexion.getConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            comando.CommandText = "SELECT * FROM Personas";
            comando.Connection = sqlConnection;
            
        }
    }
}
