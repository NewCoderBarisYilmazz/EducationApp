using App.Business.Services.ProductServices.ProductDTO;
using EducationApp.DataAccess.Repositories.ProductRepository;
using EducationApp.DataAccess.Repositories.RepositoryPattern;
using EducationApp.Entities.Concrete;

namespace App.Business.Services.ProductServices
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

       

        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(ProductAddDTO productAddDto)
        {
       
            Product pr = new();
            pr.Name=productAddDto.Name;
           _repository.AddAsync(pr);
           await  _unitOfWork.SaveChangesAsync();

        }

        public  IQueryable<Product> GetAll()
        {
           
            return _repository.GetAll(); 
        }
    }
}
