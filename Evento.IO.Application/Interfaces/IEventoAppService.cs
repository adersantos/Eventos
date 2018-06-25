using Evento.IO.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.IO.Application.Interfaces
{
    public interface IEventoAppService: IDisposable
    {
        void Registrar(EventoViewModel eventoViewModel);

        IEnumerable<EventoViewModel> ObterTodos();

        IEnumerable<EventoViewModel> ObterEventoPorOrganizador(Guid organizadorId);

        EventoViewModel ObterPorId(Guid Id);

        void Atualizar(EventoViewModel eventoViewModel);

        void Excluir(Guid id);
    }
}
