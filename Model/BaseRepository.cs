using DAL;
using Dapper;
using Model.MovimentosAnaliticos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class BaseRepository
    {
        private readonly Ado _ado;

        public BaseRepository(Ado ado)
        {
            _ado = new Ado();
        }


        public IEnumerable<T> ExecutarQuery<T>(string query, DynamicParameters listaParametros)
        {
            using (var conn = _ado.Conectar())
            {
                var sources = conn.Query<T>(sql: query, param: listaParametros);
                return sources;
            }
        }
        
        public T ExecutarQueryFirstOrDefault<T>(string query, DynamicParameters listaParametros)
        {
            using (var conn = _ado.Conectar())
            {
                var source = conn.QueryFirstOrDefault<T>(sql: query, param: listaParametros);
                return source;
            }
        }

        public IEnumerable<T> ExecutarProcedure<T>(string nameProc, DynamicParameters listaParametros)
        {
            using (var conn = _ado.Conectar())
            {
                var sources = conn.Query<T>(sql: nameProc, param: listaParametros, commandType: CommandType.StoredProcedure);
                return sources;
            }
        }

        public int Executar(string query, DynamicParameters listaParametros)
        {
            using (var conn = _ado.Conectar())
            {
                var result = conn.Execute(sql: query, param: listaParametros);
                return result;
            }
        }
    }
}
