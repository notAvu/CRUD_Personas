using _07_CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Listado
{
    public class clsListadoPersonas
    {
        #region atributos privados
        List<clsPersona> listadoCompleto;
        List<clsPersona> listadoFiltrado;
        clsMyConnection connector= new clsMyConnection();
        #endregion
        #region propiedades publicas
        public List<clsPersona> ListadoCompleto { get => listadoCompleto; set => listadoCompleto = value; }
        public List<clsPersona> ListadoFiltrado { get => listadoFiltrado; set => listadoFiltrado = value; }
        #endregion
        #region costructor
        public clsListadoPersonas() {
            
            ListadoCompleto = new List<clsPersona>();
            ListadoFiltrado = new List<clsPersona>();
            connector = new clsMyConnection();
            RellenarListado();
        }
        #endregion
        #region lectura
        /// <summary>
        /// Rellena el listado completo de personas
        /// </summary>
        private void RellenarListado() {
            LlenarListaElegida(listadoCompleto, "SELECT * FROM Personas");
        }
        /// <summary>
        /// Rellena el listadoFiltrado en funcion del departamento 
        /// </summary>
        /// <param name="idDep"></param>
        public void FiltrarPorDepartamento(int idDep)
        {
            LlenarListaElegida(listadoFiltrado, $"SELECT * FROM Personas WHERE IDDepartamento={idDep}");
        }
        /// <summary>
        /// Metodo auxiliar para rellenar la lista que recibe por parametro con los datos de la bbdd segun la consulta indicada
        /// </summary>
        /// <param name="listadoElegido"></param>
        /// <param name="consultaSql"></param>
        private void LlenarListaElegida(List<clsPersona> listadoElegido, string consultaSql) {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = consultaSql;
            comando.Connection = sqlConnection;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    listadoElegido.Add(leerPersona(reader));
                }
            }
            reader.Close();
            connector.closeConnection(ref sqlConnection);
        }
        /// <summary>
        /// Metodo auxiliar para leer una persona de la base de datos
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static clsPersona leerPersona(SqlDataReader reader)
        {
            int id = (int)reader["IDPersona"];
            string nombre = (string)reader["nombrePersona"];
            string apellido = (string)reader["apellidosPersona"];
            DateTime dateTime = (DateTime)reader["fechaNacimiento"];
            string telefono = (string)reader["telefono"];
            string direccion = (string)reader["direccion"];
            string fotoUrl = (string)reader["foto"];
            int idDepartamento = (int)reader["IDDepartamento"];
            return new clsPersona(id, nombre, apellido, dateTime, telefono, direccion, fotoUrl, idDepartamento);

        }
        #endregion
    }

}
