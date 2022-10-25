using Company.Products.Entities;
using Company.Products.Infrastructure.Repositories;
using Company.Products.Model.InputModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Company.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todos os dados dos produtos
        /// </summary>
        /// <returns>Objeto de detalhes dos produtos</returns>
        /// <response code="200">Produtos encontrado</response>
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAll();

            return Ok(products);
        }

        /// <summary>
        /// Retorna todos os dados do produto
        /// </summary>
        /// <returns>Objeto de detalhes do produto</returns>
        /// <response code="404">Produto não encontrado</response>
        /// <response code="200">Produto encontrado</response>
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _repository.GetById(id);

            if(product == null)
                return NotFound();

            return Ok(product);
        }


        /// <summary>
        /// Cadastro de Produto
        /// </summary>
        /// <returns>Objeto Criado</returns>
        /// <response code="400">Produto invalido</response>
        /// <response code="201">Produto Criado</response>
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody]AddProductInputModel model)
        {
            var product = new Product(
              model.Title,
              model.Description,
              model.Value,
              model.Quantity
                
        );

            await _repository.AddProduct(product);

            return CreatedAtAction(nameof(GetById), new {id = product.Id}, product);
        }


        /// <summary>
        /// Atualização do Produto
        /// </summary>
        /// <returns>Objeto Atualizado</returns>
        /// <response code="404">Produto não encontrado</response>
        /// <response code="204">Produto Atualizado</response>
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductInputModel model)
        {
            var product = await _repository.GetById(id);

            if (product == null)
                return NotFound();

            product.Update(model.Title, model.Description, model.Value, model.Quantity);
            await _repository.UpdateProduct(product);

            return NoContent();
        }


        /// <summary>
        /// Remoção do Produto
        /// </summary>
        /// <returns>Objeto Removido</returns>
        /// <response code="404">Produto não encontrado</response>
        /// <response code="204">Produto Removido</response>
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _repository.GetById(id);

            if (product == null)
                return NotFound();
     
            await _repository.DeleteProduct(product.Id);

            return NoContent();
        }
    }
}
