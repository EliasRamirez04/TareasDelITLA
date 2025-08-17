using System.Data.SqlClient;

namespace BiblioSmart.DAL
{
    public class ConexionBD
    {
        private readonly SqlConnection connection;

        public ConexionBD()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=BiblioSmartDB;Integrated Security=True;";
            connection = new SqlConnection(connectionString);
        }

        public SqlConnection AbrirConexion()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
            return connection;
        }

        public void CerrarConexion()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
    }
}