using Eventos.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
