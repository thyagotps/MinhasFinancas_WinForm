using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public interface IAdo
    {

    }

    public class Ado : IDisposable, IAdo
    {
        public IDbConnection Connection { get; private set; }

        private string ConnectionString => @"Data Source=THYAGO\SQLEXPRESS; Initial Catalog = DB_FINANCAS_DESV; Integrated Security=true; Trusted_Connection=Yes";
        //private string ConnectionString => @"Data Source=THYAGO\SQLEXPRESS; Initial Catalog = DB_FINANCAS; Integrated Security=true; Trusted_Connection=Yes";
        //private string ConnectionString => @"Data Source=THYAGO\SQLEXPRESS; Initial Catalog = DB_GERENCIADOR_FINANCEIRO; Integrated Security=true; Trusted_Connection=Yes";

        public Ado()
        {
            Connection = new SqlConnection(ConnectionString);
            Conectar();
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