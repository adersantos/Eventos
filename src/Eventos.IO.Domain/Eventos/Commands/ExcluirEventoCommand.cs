using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Eventos.Commands
{
    public class ExcluirEventoCommand : BaseEventoCommand
    {
        public ExcluirEventoCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
