using App.Business.Services.ProductServices.ProductDTO;
using EducationApp.Entities.Concrete;

namespace App.Business.Services.ProductServices
{
    public interface IProductService
    {
        IQueryable<Product> GetAll();

        Task AddAsync(ProductAddDTO productAddDto);

    }
}
