using App.Business.Services.ProductServices;
using App.Business.Services.ProductServices.ProductDTO;
using App.Core.Security;
using EducationApp.DataAccess.Repositories.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRepository;

        private readonly IJwtHandler _jwtHandler;

        public HomeController(IProductService productService, IJwtHandler jwtHandler)
        {
            _productService = productService;
            _jwtHandler = jwtHandler;
        }

        [HttpGet]
        public IActionResult GetProductAll()
        {
            return Ok(_productService.GetAll());
        }
        [HttpPost]
       public async Task<IActionResult>AddProduct(ProductAddDTO dto)
        {
            await _productService.AddAsync(dto);
            return Ok(new { Message = "Kayıt İşlemi başarıyla tamamlandı" });

        }

        [HttpGet("[action]")]
        public IActionResult CreateToken()
        {
            return Ok(_jwtHandler.CreateToken());
        }
        [HttpGet]

        public IActionResult GetAllProducts()
        {
            return Ok(_productService.GetAll());
        }
    }
}
