using Microsoft.AspNetCore.Mvc;
using Modelo.Domain.Entities;
using Modelo.Infra.Data.Context;
using Modelo.Service.Services;

namespace Modelo.Application.Controllers
{
    /// <summary>
    /// PatrimoniosController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PatrimoniosController : ControllerBase
    {
        private readonly PatrimonioService _baseService;
        private readonly MarcaService _marcaService;


        /// <summary>
        /// PatrimoniosController
        /// </summary>
        /// <param name="context"></param>
        public PatrimoniosController(SQLServerContext context)
        {
            _baseService = new PatrimonioService(context);
            _marcaService = new MarcaService(context);
        }

        /// <summary>
        /// Obtém todos os patrimônios cadastrados no sistema
        /// </summary>
        /// <returns>Lista de patrimônios</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_baseService.GetAllIncludes());
        }

        /// <summary>
        /// Obtém um patrimônio por ID
        /// </summary>
        /// <returns>Patrimônio</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var patrimonio = _baseService.GetIncludes(id);

            if (patrimonio == null)
            {
                return NotFound();
            }

            return Ok(patrimonio);
        }

        /// <summary>
        /// Atualiza um patrimônio enviado
        /// </summary>
        /// <returns>Patrimônio atualizado</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Patrimonio patrimonio)
        {
            if (patrimonio.Marca.Id > 0)
            {
                if (!_marcaService.MarcaExists(patrimonio.Marca.Id))
                    return BadRequest($"A marca {patrimonio.Marca.Id} informada não foi encontrada!");
            }
            else
                return BadRequest($"Obrigatório informar a marca!");

            if (string.IsNullOrEmpty(patrimonio.Nome))
                return BadRequest($"Obrigatório informar o nome do patrimônio!");

            if (id != patrimonio.Id)
            {
                return BadRequest("Id informado não identificado com o patrimônio!");
            }

            patrimonio.NumeroTombo = _baseService.Get(patrimonio.Id).NumeroTombo;
            patrimonio.Id = id;

            return Ok(_baseService.Put(patrimonio));
        }

        /// <summary>
        /// Cria um patrimônio enviado
        /// </summary>
        /// <returns>Patrimônio criado</returns>
        [HttpPost]
        public IActionResult Post(Patrimonio patrimonio)
        {
            if (patrimonio.Marca.Id > 0)
            {
                if (!_marcaService.MarcaExists(patrimonio.Marca.Id))
                    return BadRequest($"A marca {patrimonio.Marca.Id} informada não foi encontrada!");
            }
            else
                return BadRequest($"Obrigatório informar a marca!");
            
            if (string.IsNullOrEmpty(patrimonio.Nome))
                return BadRequest($"Obrigatório informar o nome do patrimônio!");            

            patrimonio.NumeroTombo = _baseService.GetNumeroTombo();

            return Ok(_baseService.Post(patrimonio));
        }

        /// <summary>
        /// Exclui um patrimônio por Id
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _baseService.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
