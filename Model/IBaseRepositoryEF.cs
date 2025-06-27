using Dapper;
using System.Linq.Expressions;

namespace Model
{
    public interface IBaseRepositoryEF<T> where T : class
    {
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        IEnumerable<T> GetAll();
        T GetById(int? id);
        //IEnumerable<T> GetWithFilter(
        //    Expression<Func<T, bool>> filter = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //    string includeProperties = "");

        IEnumerable<T> ExecutarQuery<T>(string query, DynamicParameters listaParametros);
        T ExecutarQueryFirstOrDefault<T>(string query, DynamicParameters listaParametros);
        IEnumerable<T> ExecutarProcedure<T>(string nameProc, DynamicParameters listaParametros);
        int Executar(string query, DynamicParameters listaParametros);
    }
}
