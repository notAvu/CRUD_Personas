using _07_CRUD_Personas_DAL.Conexion;
using Entities_UWP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Listado
{
    public class clsListadoPersonas
    {
        #region constantes (sentencias)
        private const string UpdatePersona = "UPDATE Personas SET nombrePersona = @nombre, apellidosPersona = @apellido, fechaNacimiento = @fechaNac, telefono = @telefono, direccion = @idreccion, foto = @foto, IDDepartamento = @iddepartamento";
        private const string InsertPersona = "INSERT INTO Personas VALUES (@Nombre, @Apellido, @fechaNacimiento, @telefono, @direccion, @foto, @idDepartamento)";
        #endregion
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
        public clsPersona leerPersonaPorID(int id) 
        {
            clsPersona persona=null;
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = $"SELECT * FROM Personas WHERE IDPersona={id}";
            comando.Connection = sqlConnection;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    persona=(leerPersona(reader));
                }
            }
            reader.Close();
            connector.closeConnection(ref sqlConnection);
            return persona;
        }
        #endregion
        #region agregarPersona
        /// <summary>
        /// registra la persona recibida por parametro en la bbdd
        /// </summary>
        /// <param name="persona"></param>
        public void AgergarPersonaDAL(clsPersona persona)
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = generarComandoPersona(persona, InsertPersona);
            comando.Connection = sqlConnection;
            comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
        }

        /// <summary>
        /// Metodo auxiliar para generar el comando de insertar persona en la bbdd 
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        private static SqlCommand generarComandoPersona(clsPersona persona, string comandoTipo)
        {
            SqlCommand comando = new SqlCommand();
            string sentenciaSql=comandoTipo;
            comando.Parameters.AddWithValue("@Nombre", persona.Nombre);
            comando.Parameters.AddWithValue("@Apellido", persona.Apellido);
            comando.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
            comando.Parameters.AddWithValue("@telefono", persona.Telefono);
            comando.Parameters.AddWithValue("@direccion", persona.Direccion);
            comando.Parameters.AddWithValue("@foto", persona.Foto);
            comando.Parameters.AddWithValue("@idDepartamento", persona.IdDepartamento);
            comando.CommandText=sentenciaSql;
            return comando;
        }
        #endregion
        #region editarPersona
        public void EditarPersona(clsPersona persona)
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = generarComandoPersona(persona, UpdatePersona);
            comando.Connection = sqlConnection;
            
            comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
        }
        #endregion
        #region eliminarPersona
        /// <summary>
        /// Elimina de la base de datos la persona con el id seleccionado
        /// </summary>
        /// <param name="id"></param>
        public void EliminarPersona(int id)
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@id", id);
            comando.CommandText = "DELETE FROM Personas WHERE IDPersona=@id";
            comando.Connection = sqlConnection;
            comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
        }
        #endregion
    }

}
