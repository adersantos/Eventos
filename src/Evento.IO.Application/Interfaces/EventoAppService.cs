using System;
using System.Collections.Generic;
using Evento.IO.Application.ViewModel;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Eventos.Commands;

namespace Evento.IO.Application.Interfaces
{
    public class EventoAppService : IEventoAppService
    {

        private readonly IBus _bus;

        public EventoAppService(IBus bus)
        {
            _bus = bus;
        }

        public void Registrar(EventoViewModel eventoViewModel)
        {
            //var registroCommand = new RegistrarEventoCommand();
            //_bus.Sendcommand(registroCommand);
        }

        public void Atualizar(EventoViewModel eventoViewModel)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventoViewModel> ObterEventoPorOrganizador(Guid organizadorId)
        {
            throw new NotImplementedException();
        }

        public EventoViewModel ObterPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventoViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

}
