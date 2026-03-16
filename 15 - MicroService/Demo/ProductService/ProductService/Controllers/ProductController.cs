using Microsoft.AspNetCore.Mvc;
using ProductService.Dtos;
using ProductService.Services;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ServiceProduct _service;

        public ProductController(ServiceProduct service)
        {
            _service = service;
        }

        [HttpGet]
        public List<ProductSend> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ProductSend GetByID(int id) { 
            return _service.GetById(id);
        }

        [HttpPost]
        public ProductSend Create (ProductReceive entity)
        {
            return _service.Create(entity);
        }

    
    }
}
