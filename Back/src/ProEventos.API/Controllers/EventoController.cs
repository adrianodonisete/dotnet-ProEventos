using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[]
            {
                new Evento()
                {
                    EventoId = 1,
                    Tema = "Angular 11 e .NET 5",
                    Local = "Belo Horizonte",
                    Lote = "1",
                    QtdPessoas = 250,
                    ImagemURL = "foto.png",
                    DataEvento = DateTime.Now.AddDays(2).ToString()
                },
                new Evento()
                {
                    EventoId = 2,
                    Tema = "Angular 13 e .NET 6",
                    Local = "Itajubá",
                    Lote = "1",
                    QtdPessoas = 200,
                    ImagemURL = "foto2.png",
                    DataEvento = DateTime.Now.AddDays(2).ToString()
                }
            };

        public EventoController()
        {

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(e => e.EventoId == id);
        }

        [HttpPost("{id}")]
        public string Post(int id)
        {
            return $"value {id}";
        }
    }
}
