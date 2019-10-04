using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Infra.Data.Context;
using Modelo.Service.Services;

namespace Modelo.Application.Controllers
{
    /// <summary>
    /// MarcasController
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly MarcaService _baseService;
        private readonly PatrimonioService _patrimonioService;

        /// <summary>
        /// MarcasController
        /// </summary>
        /// <param name="context"></param>
        public MarcasController(SQLServerContext context)
        {
            _baseService = new MarcaService(context);
            _patrimonioService = new PatrimonioService(context);
        }

        /// <summary>
        /// Obtém todas as Marcas cadastradas no sistema
        /// </summary>
        /// <returns>Lista de Marcas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_baseService.Get());
        }

        /// <summary>
        /// Obtém uma Marca por ID
        /// </summary>
        /// <returns>Marca</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var marca = _baseService.Get(id);

            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }

        /// <summary>
        /// Obtém todos os patrimônios de uma marca
        /// </summary>
        /// <returns>Marca</returns>
        [HttpGet("{id}/Patrimonios")]
        public IActionResult GetPatrimonios(int id)
        {
            var lstPatrimonios = _patrimonioService.GetAllPatrimoniosIncludes(id);

            return Ok(lstPatrimonios);
        }

        /// <summary>
        /// Atualiza uma Marca enviado
        /// </summary>
        /// <returns>Marca atualizada</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Marca marca)
        {
            if (string.IsNullOrEmpty(marca.Nome))
                return BadRequest($"Obrigatório informar o nome!");

            if (_baseService.MarcaDuplicada(marca.Nome))
                return BadRequest($"A marca {marca.Nome} informada já existe!");

            if (id != marca.Id)
                return BadRequest($"Id {id} informado não coincide com a marca!");

            marca.Id = id;

            return Ok(_baseService.Put(marca));
        }

        /// <summary>
        /// Cria uma Marca enviado
        /// </summary>
        /// <returns>Marca criada</returns>
        [HttpPost]
        public IActionResult Post(Marca marca)
        {
            if (string.IsNullOrEmpty(marca.Nome))
                return BadRequest($"Obrigatório informar o nome!");
            
            if (_baseService.MarcaDuplicada(marca.Nome))
                return BadRequest($"A marca {marca.Nome} informada já existe!");

            return Ok(_baseService.Post(marca));
        }

        /// <summary>
        /// Exclui uma Marca por Id
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
