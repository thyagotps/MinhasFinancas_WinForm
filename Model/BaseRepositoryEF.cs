using DAL;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Dapper.SqlMapper;

namespace Model
{

    public class BaseRepositoryEF<T>  : IBaseRepositoryEF<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly IAdo _ado;

        public BaseRepositoryEF(AppDbContext context, IAdo ado)
        {
            _context = context;
            _dbSet = context.Set<T>();
            _ado = ado;
        }

        /// <summary>
        /// EF: Insere um registro na tabela.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Insert(T entity)
        {
            _context.ChangeTracker.Clear();
            _dbSet.Add(entity);
            var result = _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// EF: Atualiza um registro da tabela.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Update(T entity)
        {
            _context.ChangeTracker.Clear();
            _context.Update(entity);
            var result = _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// EF: Deleta um registro da tabela.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Delete(T entity)
        {
            _context.ChangeTracker.Clear();
            _dbSet.Remove(entity);
            var result = _context.SaveChanges();
            return result;
        }

        /// <summary>
        /// EF: Retorna todos os dados da tabela.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking().Select(a => a);
        }

        /// <summary>
        /// EF: Obtém um registro da tabela.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// EF: Obtém dados da tabela.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        //public virtual IEnumerable<T> GetWithFilter(
        //    Expression<Func<T, bool>> filter = null,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //    string includeProperties = "")
        //{
        //    _context.ChangeTracker.Clear();
        //    //IQueryable<T> query = _dbSet;
        //    IQueryable<T> query = null;

        //    if (filter != null)
        //    {
        //        query = _dbSet.Where(filter);
        //    }

        //    if (!string.IsNullOrEmpty(includeProperties))
        //    {
        //        foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = _dbSet.Include(includeProperty);
        //        }
        //    }

        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

        /// <summary>
        /// Dapper: Executa query e retorna um IEnumerable<T>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="listaParametros"></param>
        /// <returns></returns>
        public IEnumerable<T> ExecutarQuery<T>(string query, DynamicParameters listaParametros)
        {
            using (var conn = _ado.Conectar())
            {
                var sources = conn.Query<T>(sql: query, param: listaParametros);
                return sources;
            }
        }

        /// <summary>
        /// Dapper: Executa query e retorna objeto FirstOrDefault
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="listaParametros"></param>
        /// <returns></returns>
        public T ExecutarQueryFirstOrDefault<T>(string query, DynamicParameters listaParametros)
        {
            using (var conn = _ado.Conectar())
            {
                var source = conn.QueryFirstOrDefault<T>(sql: query, param: listaParametros);
                return source;
            }
        }

        /// <summary>
        /// Dapper: Executa stored procedure e retorna um IEnumerable<T>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameProc"></param>
        /// <param name="listaParametros"></param>
        /// <returns></returns>
        public IEnumerable<T> ExecutarProcedure<T>(string nameProc, DynamicParameters listaParametros)
        {
            using (var conn = _ado.Conectar())
            {
                var sources = conn.Query<T>(sql: nameProc, param: listaParametros, commandType: CommandType.StoredProcedure);
                return sources;
            }
        }

        /// <summary>
        /// Dapper: Executa query DML (insert, update, delete) sql, e retorna a quantidade de registros afetados.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="listaParametros"></param>
        /// <returns></returns>
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
