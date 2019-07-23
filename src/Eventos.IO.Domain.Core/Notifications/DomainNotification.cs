using Eventos.IO.Domain.Core.Events;
using System;

namespace Eventos.IO.Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public Guid DomainNotificationId { get; private set; }

        public string Key { get;private set; }//nome do Evento

        public string Value { get;private set; }//mensagem

        public int Version { get;private set; }


        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }
    }
}
