using _07_CRUD_Personas_DAL.Conexion;
using CRUD_Personas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Gestora
{
    public class clsGestoraDepartamentos
    {

        #region propiedades privadas
        clsMyConnection connector;
        #region constantes (sentencias genericas)
        private const string UpdateDepartamentoSentencia = "UPDATE Departamentos SET nombreDepartamento = @Nombre WHERE IDDeparramento=@id";
        private const string InsertDepartamentoSentencia = "INSERT INTO Departamento VALUES (@Nombre)";
        private const string DeleteDepartamentoSentencia = "DELETE FROM Departamentos WHERE IDDepartamento=@id";
        private const string SelectDepartamentpoSentencia = "SELECT * FROM Departamentos WHERE IDDepartamento=@id";
        #endregion
        public clsGestoraDepartamentos()
        {
            this.connector = new clsMyConnection();
        }
        #endregion
        #region leerDepartamento
        /// <summary>
        /// Busca en la base de datos el departamento con el id recibido 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public clsDepartamento leerDepartamentoPorID(int id)
        {
            clsDepartamento departamento = null;
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@id", id);
            comando.CommandText = SelectDepartamentpoSentencia;
            comando.Connection = sqlConnection;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    departamento = leerDepartamento(reader);
                }
            }
            reader.Close();
            connector.closeConnection(ref sqlConnection);
            return departamento;
        }
        /// <summary>
        /// Metodo auxiliar para leer un registro de entidad departamento en la base de datos
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static clsDepartamento leerDepartamento(SqlDataReader reader)
        {
            int id = (int)reader["IDDepartamento"];
            string nombre = (string)reader["nombreDepartamento"];
            return new clsDepartamento(id, nombre);

        }
        #endregion
        #region agregarDepartamento
        /// <summary>
        /// registra el departamento recibido por parametro en la bbdd
        /// </summary>
        /// <param name="departamento"></param>
        public void AgregarDepartamentoDAL(clsDepartamento departamento)
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = generarComandoDepartamento(departamento, InsertDepartamentoSentencia);
            comando.Connection = sqlConnection;
            comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
        }

        /// <summary>
        /// Metodo auxiliar para generar el comando de insertar departamento en la bbdd 
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        private static SqlCommand generarComandoDepartamento(clsDepartamento departamento, string comandoTipo)
        {
            SqlCommand comando = new SqlCommand();
            string sentenciaSql = comandoTipo;
            comando.Parameters.AddWithValue("@id", departamento.Id);
            comando.Parameters.AddWithValue("@Nombre", departamento.Nombre);
            comando.CommandText = sentenciaSql;
            return comando;
        }
        #endregion
        #region editar Departamento
        /// <summary>
        /// Recibe un objeto departamento del cual, a partir del id, busca en la base de datos el departamento correspondiente a ese id 
        /// y actualiza los datos con los del objeto recibido por parametro
        /// </summary>
        /// <param name="departamento"></param>
        public void EditarDepartamento(clsDepartamento departamento)
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = generarComandoDepartamento(departamento, UpdateDepartamentoSentencia);
            comando.Connection = sqlConnection;

            comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
        }
        #endregion
        #region eliminarDepartamento
        /// <summary>
        /// Elimina de la base de datos el departamento con el id seleccionado
        /// </summary>
        /// <param name="id"></param>
        public void EliminarDepartamento(int id)
        {
            SqlConnection sqlConnection = connector.getConnection();
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@id", id);
            comando.CommandText = DeleteDepartamentoSentencia;
            comando.Connection = sqlConnection;
            comando.ExecuteNonQuery();
            connector.closeConnection(ref sqlConnection);
        }
        #endregion
    }
}
