using EducationApp.DataAccess.Context;
using EducationApp.DataAccess.Repositories.RepositoryPattern;
using EducationApp.Entities.Concrete;

namespace EducationApp.DataAccess.Repositories.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
