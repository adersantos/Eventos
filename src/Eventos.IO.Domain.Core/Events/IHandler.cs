using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Core.Events
{
    /// <summary>
    /// Utilizando Contra Variância - tipos menos ou mais derivados
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
