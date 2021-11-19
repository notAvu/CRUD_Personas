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
        #region propiedades privadas;
        List<clsPersona> listadoCompleto;
        clsMyConnection conexion;
        #endregion
        #region propiedades publicas
        public List<clsPersona> ListadoCompleto { get => listadoCompleto; set => listadoCompleto = value; }
        #endregion
        #region metodos
        private void executeConnection() {
            conexion = new clsMyConnection();
            SqlConnection sqlConnection= conexion.getConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            comando.CommandText = "SELECT * FROM Personas";
            comando.Connection = sqlConnection;    
        }

        #endregion
    }
}
