using CatalogAPI.Entities;
using CatalogAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepositories _productRepositories;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(IProductRepositories productRepositories, ILogger<CatalogController> logger)
        {
            _productRepositories = productRepositories;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productRepositories.GetProducts();
            return Ok(products);
        }

        [HttpGet("{Id:length(24)}",Name ="GetProdct")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> GetProductById(string Id)
        {
            var product = await _productRepositories.GetProduct(Id);
            if(product == null)
            {
                _logger.LogError($"Product with id : {Id}, not found.");
                return NotFound(Id);
            }
            return Ok(product);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByName(string name)
        {
            var products = await _productRepositories.GetProductsByName(name);
            if(products == null)
            {
                _logger.LogError($"Product with Name : {name}, not found.");
                return NotFound(name);
            }
            return Ok(products);
        }

        [Route("[action]/{categoryName}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string categoryName)
        {
            var products = await _productRepositories.GetProductsByCategory(categoryName);
            if (products == null)
            {
                _logger.LogError($"Product with Name : {categoryName}, not found.");
                return NotFound(categoryName);
            }
            return Ok(products);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Create([FromBody]Product product)
        {
            await _productRepositories.Create(product);

            return CreatedAtRoute("GeProduct", new { id = product.ID }, product);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Update([FromBody] Product product)
        {
            return Ok(await _productRepositories.Update(product));
        }

        [HttpDelete("{Id:length(24)}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Delete(string Id)
        {
            return Ok(await _productRepositories.Delete(Id));
        }
    }
}
