using EducationApp.DataAccess.Context;

namespace EducationApp.DataAccess.Repositories.RepositoryPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbcontext;

       

        public UnitOfWork(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task SaveChangesAsync()
        {
           await _dbcontext.SaveChangesAsync();
        }
    }
}
