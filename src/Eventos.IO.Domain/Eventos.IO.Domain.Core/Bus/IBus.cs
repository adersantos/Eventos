using Eventos.IO.Domain.Core.Commands;
using Eventos.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Core.Bus
{

    /// <summary>
    /// Dispara Eventos e Commandos
    /// </summary>
    public interface IBus
    {
        void Sendcommand<T>(T theCommand) where T : Command;

        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}
