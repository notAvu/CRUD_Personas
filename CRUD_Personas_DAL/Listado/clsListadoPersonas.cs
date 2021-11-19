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
<<<<<<< HEAD
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
=======
        List<clsPersona> listadoFiltrado;
        clsMyConnection conexion= new clsMyConnection();

        public List<clsPersona> ListadoCompleto { get => listadoCompleto; set => listadoCompleto = value; }

        private void RellenarListado() {
            LlenarListaElegida(listadoCompleto, "SELECT * FROM Personas");
        }
        private void FiltrarPorDepartamento(int idDep)
        {
            LlenarListaElegida(listadoFiltrado, $"SELECT * FROM Personas WHERE IDDepartamento={idDep}");
        }
        private void LlenarListaElegida(List<clsPersona> listadoElegido, string consultaSql) 
        {
            SqlConnection sqlConnection = conexion.getConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader reader;
            comando.CommandText = consultaSql;
            comando.Connection = sqlConnection;
            reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = (int)reader["IDPersona"];
                    string nombre = (string)reader["nombrePersona"];
                    string apellido = (string)reader["apellidosPersona"];
                    DateTime dateTime = (DateTime)reader["fechaNacimiento"];
                    string telefono = (string)reader["telefono"];
                    string direccion = (string)reader["direccion"];
                    string fotoUrl = (string)reader["foto"];
                    int idDepartamento = (int)reader["IDDepartamento"];
                    clsPersona oPersona = new clsPersona(id, nombre, apellido, dateTime, telefono, direccion, fotoUrl, idDepartamento);
                    listadoElegido.Add(oPersona);
                }
            }
            reader.Close();
            conexion.closeConnection(ref sqlConnection);
>>>>>>> 904bdc86411de0a41b15ab6b445868499d2347dc
        }

        #endregion
    }
    
}
