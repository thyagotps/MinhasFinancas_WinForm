using System.Data;
using System.Data.SqlClient;

namespace Ado
{

    public interface IAdo
    {

    }

    public class Ado : IDisposable, IAdo
    {
        public IDbConnection Connection { get; private set; }

        private string ConnectionString => @"Data Source=.\SQLEXPRESS; Initial Catalog = DB_FINANCAS_DESV; Integrated Security=true; Trusted_Connection=Yes";

        public Ado()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();  
        }

        public IDbConnection Conectar()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
            return Connection;
        }


        public void Dispose() => Connection?.Dispose();

    }
}