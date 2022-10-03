using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using ProEventos.Application.Interfaces;
using ProEventos.Domain;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IEventosService _service;

        public EventosController(IEventosService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _service.GetAllEventosAsync(true);
                if (eventos == null)
                {
                    return NotFound("Nenhum evento encontrado");
                }
                return Ok(eventos);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, $"Erro: {e.Message}");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _service.GetEventoByIdAsync(id, true);
                if (evento == null)
                {
                    return NotFound("Nenhum evento encontrado com esse ID");
                }
                return Ok(evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, $"Erro: {e.Message}");
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var eventos = await _service.GetAllEventosByTemaAsync(tema, true);
                if (eventos == null)
                {
                    return NotFound("Nenhum evento encontrado com esse tema");
                }
                return Ok(eventos);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, $"Erro: {e.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                var evento = await _service.AddEvento(model);
                if (evento == null)
                {
                    return BadRequest("Erro ao inserir evento");
                }
                return this.StatusCode(StatusCodes.Status201Created, evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, $"Erro: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await _service.UpdateEvento(id, model);
                if (evento == null)
                {
                    return BadRequest("Erro ao alterar evento");
                }
                return Ok(evento);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status400BadRequest, $"Erro: {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await _service.GetEventoByIdAsync(id, true);
                if (evento == null)
                {
                    return NotFound("Nenhum evento encontrado com esse ID");
                }

                if (await _service.DeleteEvento(id))
                {
                    return Ok("Deletado");
                }

                return BadRequest("Erro ao tentar deletar evento");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro: {e.Message}");
            }
        }
    }
}
