using _07_CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Listado
{
    public class clsListadoDepartamentos
    {
        #region atributos privados
        List<clsDepartamento> listadoCompleto;
        List<clsDepartamento> listadoFiltrado;
        clsMyConnection connector = new clsMyConnection();
        #endregion
        #region propiedades publicas
        public List<clsDepartamento> ListadoCompleto { get => listadoCompleto; set => listadoCompleto = value; }
        #endregion
        #region costructor
        public clsListadoDepartamentos()
        {

            ListadoCompleto = new List<clsDepartamento>();
            connector = new clsMyConnection();
            RellenarListado();
        }
        #endregion
        #region lectura
        /// <summary>
        /// Rellena el listado completo de departamentos
        /// </summary>
        private void RellenarListado()
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Departamentos";
            comando.Connection = sqlConnection;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listadoCompleto.Add(leerDepartamento(reader));
                }
            }
            reader.Close();
            connector.closeConnection(ref sqlConnection);
        }
        /// <summary>
        /// Metodo auxiliar para leer un departamento de la base de datos
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private clsDepartamento leerDepartamento(SqlDataReader reader)
        {
            string nombre = (string)reader["nombreDepartamento"];
            int idDepartamento = (int)reader["IDDepartamento"];
            return new clsDepartamento(idDepartamento, nombre);

        }
        /// <summary>
        /// Lee los nombres de todos los Departamentos y los devuelve en un List de String
        /// </summary>
        /// <returns></returns>
        public List<string> ListadoNombres() 
        {
            List<string> nombres= new List<string>();
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT Nombre FROM Departamentos";
            comando.Connection = sqlConnection;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    nombres.Add(leerDepartamento(reader).Nombre);
                }
            }
            reader.Close();
            connector.closeConnection(ref sqlConnection);
            return nombres;
        }
        #endregion
    }
}
