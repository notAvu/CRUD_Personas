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
            comando.Parameters.AddWithValue("@id", id);
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
            comando.CommandText = "DBCC CHECKIDENT ('[Personas]', RESEED, 0);";
            comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
            return persona;
        }
        /// <summary>
        /// Metodo auxiliar para leer un registro de entidad persona en la base de datos cubriendo los casos en los que los datos sean null
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static clsPersona leerPersona(SqlDataReader reader)
        {
            int id = (int)reader["IDPersona"];
            string nombre;
            if (reader["nombrePersona"] != DBNull.Value)
            {
                nombre = (string)reader["nombrePersona"]; ;
            }
            else
            {
                nombre = "";
            }
            string apellido;
            if (reader["apellidosPersona"] != DBNull.Value)
            {
                apellido = (string)reader["apellidosPersona"];
            }
            else
            {
                apellido = "";
            }
            DateTime dateTime = (DateTime)reader["fechaNacimiento"];
            string telefono;
            if (reader["telefono"] != DBNull.Value)
            {
                telefono = (string)reader["telefono"];
            }
            else
            {
                telefono = "";
            }
            string direccion;
            if (reader["direccion"] != DBNull.Value)
            {
                direccion = (string)reader["direccion"];
            }
            else
            {
                direccion = "";
            }
            string fotoUrl;
            if (reader["direccion"] != DBNull.Value)
            {
                fotoUrl = (string)reader["foto"];
            }
            else
            {
                fotoUrl = "";
            }
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
            SqlCommand comando = generarComandoPersona(persona, "INSERT INTO Personas VALUES (@Nombre, @Apellido, @fechaNacimiento, @telefono, @direccion, @foto, @idDepartamento)");
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
            if (!string.IsNullOrEmpty(persona.Nombre))
            {
                comando.Parameters.AddWithValue("@Nombre", persona.Nombre);
            }
            else
            {
                comando.Parameters.AddWithValue("@Nombre", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(persona.Apellido))
            {
                comando.Parameters.AddWithValue("@Apellido", persona.Apellido);
            }
            else
            {
                comando.Parameters.AddWithValue("@Apellido", DBNull.Value);
            }
            comando.Parameters.AddWithValue("@fechaNacimiento", persona.FechaNacimiento);
            if (!string.IsNullOrEmpty(persona.Telefono))
            {
                comando.Parameters.AddWithValue("@telefono", persona.Telefono);
            }
            else
            {
                comando.Parameters.AddWithValue("@telefono", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(persona.Direccion))
            {
                comando.Parameters.AddWithValue("@direccion", persona.Direccion);
            }
            else
            {
                comando.Parameters.AddWithValue("@direccion", DBNull.Value);
            }
            if (!string.IsNullOrEmpty(persona.Foto))
            {
                comando.Parameters.AddWithValue("@foto", persona.Foto);
            }
            else
            {
                comando.Parameters.AddWithValue("@foto", DBNull.Value);
            }
            comando.Parameters.AddWithValue("@idDepartamento", persona.IdDepartamento);
            comando.CommandText = sentenciaSql;
            return comando;
        }
        #endregion
        #region editarPersona
        /// <summary>
        /// Recibe por parametro un objeto de la clase persona y actualiza los datos del registro correspondiente 
        /// en la bdd (el que tiene el mismo ID) con los datos de dicho objeto
        /// </summary>
        /// <param name="persona"></param>
        public void EditarPersona(clsPersona persona)
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = generarComandoPersona(persona, "UPDATE Personas SET nombrePersona = @Nombre, apellidosPersona = @Apellido, fechaNacimiento = @fechaNacimiento, telefono = @telefono, direccion = @direccion, foto = @foto, IDDepartamento = @idDepartamento WHERE IDPersona=@id");
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
            comando.CommandText = " DELETE FROM Personas WHERE IDPersona=@id";
            comando.Connection = sqlConnection;
            comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
        }
        #endregion
    }
}
