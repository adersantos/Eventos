using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Eventos.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Eventos.EventHandlers
{
    public class EventoEventHandler :
        IHandler<EventoRegistradoEvent>,
        IHandler<EventoAtualizadoEvent>,
        IHandler<EventoExcluidoEvent>
    {
        public void Handle(EventoExcluidoEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handle(EventoAtualizadoEvent message)
        {
            //Enviar e-mail
        }

        public void Handle(EventoRegistradoEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
