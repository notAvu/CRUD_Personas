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
        #region atributos privados
        List<clsPersona> listadoCompleto;
        List<clsPersona> listadoFiltrado;
        clsMyConnection connector= new clsMyConnection();
        #endregion
        #region propiedades publicas
        public List<clsPersona> ListadoCompleto { get => listadoCompleto; set => listadoCompleto = value; }
        #endregion
        #region rellenarListados
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
        private void FiltrarPorDepartamento(int idDep)
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
        #endregion
        #region agregarPersona
        /// <summary>
        /// registra la persona recibida por parametro en la bbdd
        /// </summary>
        /// <param name="persona"></param>
        public void agergarPersona(clsPersona persona)
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = getComandoConValores(persona);
            comando.Connection = sqlConnection;
            comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
        }
        /// <summary>
        /// Metodo auxiliar para generar el comando de insertar persona en la bbdd 
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        private static SqlCommand getComandoConValores(clsPersona persona)
        {
            string sentenciaSql = "INSERT INTO Personas VALUES (@Nombre, @Apellido, @fechaNacimiento, @telefono, @direccion, @foto, @idDepartamento)";
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@Nombre", persona.Nombre);
            comando.Parameters.AddWithValue("@Apellido", persona.Apellido);
            comando.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
            comando.Parameters.AddWithValue("@telefono", persona.Telefono);
            comando.Parameters.AddWithValue("@direccion", persona.Direccion);
            comando.Parameters.AddWithValue("@foto", persona.Foto);
            comando.Parameters.AddWithValue("@idDepartamento", persona.IdDepartamento);
            comando.CommandText = sentenciaSql;
            return comando;
        }
        #endregion
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
    }
    
}
