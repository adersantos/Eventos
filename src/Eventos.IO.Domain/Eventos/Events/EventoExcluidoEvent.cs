using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class EventoExcluidoEvent : BaseEventoEvent
    {
        public EventoExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
