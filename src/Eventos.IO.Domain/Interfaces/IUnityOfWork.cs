using Eventos.IO.Domain.Core.Commands;
using System;

namespace Eventos.IO.Domain.Interfaces
{
    public interface IUnityOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
