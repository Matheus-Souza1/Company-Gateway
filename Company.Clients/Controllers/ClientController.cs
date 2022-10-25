using Company.Clients.Entities;
using Company.Clients.Infrastructure.Repositories;
using Company.Clients.Model.InputModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Company.Clients.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _repository;

        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todos os dados dos clientes
        /// </summary>
        /// <returns>Objeto de detalhes dos clientes</returns>
        /// <response code="200">Clientes encontrados</response>
        [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _repository.GetAll();

            return Ok(clients);
        }

        /// <summary>
        /// Retorna todos os dados do Cliente
        /// </summary>
        /// <returns>Objeto de detalhe do Cliente</returns>
        /// <response code="404">Cliente não encontrado</response>
        /// <response code="200">Cliente encontrado</response>
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Client), (int)HttpStatusCode.OK)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var client = await _repository.GetById(id);

            if(client == null)
                return NotFound();

            return Ok(client);
        }

        /// <summary>
        /// Cadastro de Cliente
        /// </summary>
        /// <returns>Objeto Criado</returns>
        /// <response code="400">Cliente invalido</response>
        /// <response code="201">Cliente Criado</response>
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Client), (int)HttpStatusCode.Created)]
        [HttpPost]
        public async Task<IActionResult> Add(AddClientInputModel model)
        {
            var client = new Client(
                model.FirstName,
                model.LastName,
                model.Document
                );
           
            await _repository.AddClient(client);

            return CreatedAtAction(nameof(GetById), new {id = client.Id}, client);
        }


        /// <summary>
        /// Atualização do Cliente
        /// </summary>
        /// <returns>Objeto Atualizado</returns>
        /// <response code="404">Cliente não encontrado</response>
        /// <response code="204">Cliente Atualizado</response>
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateClientInputModel model)
        {
            var client = await _repository.GetById(id);
            if (client == null)
                return NotFound();

            client.Update(model.FirstName, model.LastName, model.Document);
            
            await _repository.UpdateClient(client);

            return NoContent();
        }



        /// <summary>
        /// Remoção do Cliente
        /// </summary>
        /// <returns>Objeto Removido</returns>
        /// <response code="404">Cliente não encontrado</response>
        /// <response code="204">Cliente Removido</response>
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = await _repository.GetById(id);
            if (client == null)
                return NotFound();
          
            await _repository.DeleteClient(client.Id);

            return NoContent();
        }
    }
}
