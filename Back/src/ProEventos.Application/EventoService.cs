using System;
using System.Threading.Tasks;

using ProEventos.Application.Interfaces;
using ProEventos.Domain;
using ProEventos.Persistence.Interfaces;

namespace ProEventos.Application
{
    public class EventoService : IEventosService
    {
        private readonly IGeralPersistence _geralPersist;
        private readonly IEventoPersistence _eventoPersist;

        public EventoService(IGeralPersistence geralPersist, IEventoPersistence eventoPersist)
        {
            _geralPersist = geralPersist;
            _eventoPersist = eventoPersist;
        }

        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralPersist.Add<Evento>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Evento> UpdateEvento(int EventoId, Evento model)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(EventoId, false);
                if (evento == null)
                {
                    return null;
                }

                model.Id = evento.Id;
                _geralPersist.Update<Evento>(model);
                if (await _geralPersist.SaveChangesAsync())
                {
                    return await _eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteEvento(int EventoId)
        {
            try
            {
                var evento = await _eventoPersist.GetEventoByIdAsync(EventoId, false);
                if (evento == null)
                {
                    throw new Exception("Evento not found");
                }

                _geralPersist.Delete<Evento>(evento);
                return await _geralPersist.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                return await _eventoPersist.GetAllEventosAsync(includePalestrantes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                return await _eventoPersist.GetAllEventosByTemaAsync(tema, includePalestrantes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                return await _eventoPersist.GetEventoByIdAsync(eventoId, includePalestrantes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}