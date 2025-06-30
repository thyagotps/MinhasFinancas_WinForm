using DAL;
using Microsoft.EntityFrameworkCore;

namespace Model.ModuloContaPadrao
{
    public class ContaPadraoRepository : BaseRepositoryEF<ContaPadrao>, IContaPadraoRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAdo _ado;

        public ContaPadraoRepository(AppDbContext appDbContext, IAdo ado) : base(appDbContext, ado)
        {
            _appDbContext = appDbContext;
            _ado = ado;
        }

        int IContaPadraoRepository.DeleteById(int id)
        {
            var objDelete = GetById(id);
            return base.Delete(objDelete);
        }

        List<ContaPadrao> IContaPadraoRepository.GetAll()
        {
            var source = base.GetAll();
            return source.ToList();
        }

        public List<ContaPadrao> GetAllWithIncludes()
        {
            var source = _appDbContext.ContaPadrao
                .Include(x => x.Cartao)
                .Include(x => x.Categoria)
                .OrderByDescending(x => x.DataMovimento);

            return source.ToList();
        }

        ContaPadrao IContaPadraoRepository.GetById(int id)
        {
            var source = _appDbContext.ContaPadrao
                .Include(x => x.Cartao)
                .Include(x => x.Categoria)
                .Where(x => x.Id == id).FirstOrDefault();
            return source;
        }

        int Insert(ContaPadrao contaPadrao)
        {
            _appDbContext.ChangeTracker.Clear();
            _appDbContext.ContaPadrao.Add(contaPadrao);
            return _appDbContext.SaveChanges();
        }

        int Update(ContaPadrao contaPadrao)
        {
            return base.Update(contaPadrao);
        }
    }
}
