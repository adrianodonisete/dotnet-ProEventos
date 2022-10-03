using System.Threading.Tasks;

using ProEventos.Domain;

namespace ProEventos.Application.Interfaces
{
    public interface IEventosService
    {
        Task<Evento> AddEvento(Evento model);
        Task<Evento> UpdateEvento(int EventoId, Evento model);
        Task<bool> DeleteEvento(int EventoId);
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int EventoId, bool includePalestrantes = false);
    }
}