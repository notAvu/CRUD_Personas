using _07_CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Gestora
{
    public class clsGestoraPersonas
    {
        #region constantes (sentencias genericas)
        private const string UpdatePersonaCompleta = "UPDATE Personas SET nombrePersona = @Nombre, apellidosPersona = @Apellido, fechaNacimiento = @fechaNacimiento, telefono = @telefono, direccion = @direccion, foto = @foto, IDDepartamento = @idDepartamento WHERE IDPersona=@id";
        private const string InsertPersonaCompleta = "INSERT INTO Personas VALUES (@Nombre, @Apellido, @fechaNacimiento, @telefono, @direccion, @foto, @idDepartamento)";
        #endregion
        #region propiedades privadas
        clsMyConnection connector;

        public clsGestoraPersonas()
        {
            this.connector = new clsMyConnection();
        }
        #endregion

        #region leerPersona
        public clsPersona leerPersonaPorID(int id)
        {
            clsPersona persona = null;
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@id",id);
            comando.CommandText = "SELECT * FROM Personas WHERE IDPersona=@id";
            comando.Connection = sqlConnection;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    persona = leerPersona(reader);
                }
            }
            reader.Close();
            connector.closeConnection(ref sqlConnection);
            return persona;
        }
        /// <summary>
        /// Metodo auxiliar para leer un registro de entidad persona en la base de datos
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
        #region agregarPersona
        /// <summary>
        /// registra la persona recibida por parametro en la bbdd
        /// </summary>
        /// <param name="persona"></param>
        public void AgergarPersonaDAL(clsPersona persona)
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = generarComandoPersona(persona, InsertPersonaCompleta);
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
            string sentenciaSql = comandoTipo;
            comando.Parameters.AddWithValue("@id", persona.Id);
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
        #region editarPersona
        public void EditarPersona(clsPersona persona)
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = generarComandoPersona(persona, UpdatePersonaCompleta);
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
