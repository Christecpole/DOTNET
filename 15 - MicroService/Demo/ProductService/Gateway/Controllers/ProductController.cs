using Gateway.Dtos;
using Gateway.RestClient;
using Gateway.Filter;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [RequireValidToken]
    public class ProductController: ControllerBase
    {

        private readonly Client<ProductSend,ProductReceive> _client;

        public ProductController()
        {
            _client = new Client<ProductSend, ProductReceive>("http://localhost:5066/api");
        }

        [HttpGet]
        public async Task<List<ProductSend>> GetAllProduct()
        {
            return await _client.GetRequestList("/Product");
        }

        [HttpPost]
        public async Task<ProductSend> Create([FromBody] ProductReceive receive)
        {
            return await _client.PostRequest("/Product", receive);
        }

    }
}
