﻿using Eventos.IO.Domain.CommandHandlers;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Eventos.Commands;
using Eventos.IO.Domain.Eventos.Events;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using System;

namespace Eventos.IO.Domain.Eventos.CommandHandlers
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>, 
        IHandler<AtualizarEventoCommand>,
        IHandler<ExcluirEventoCommand>
    {

        private readonly IEventoRepository _eventoRepository;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public EventoCommandHandler(IEventoRepository eventoRepository, 
                                    IUnityOfWork uow,
                                    IBus bus,
                                    IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _eventoRepository = eventoRepository;
            _bus = bus;
            _notifications = notifications;
        }

        public void Handle(RegistrarEventoCommand message)
        {
            var evento = new Evento(message.Nome, message.DataInicio, message.DataFim,
                                    message.Gratuito, message.Valor, message.OnLine, message.NomeEmpresa);

            if (!evento.EhValido())
            {
                NotificarValidacoesErro(evento.ValidationResult);
                return;
            }

            //TODO:
            //validações de Negócio
            //Organizador pode registrar evento?

            //Persistência
            _eventoRepository.Add(evento);

            if (Commit())
            {
                //Notificar processo concluído
                Console.WriteLine("Evento registrado com sucesso.");
                _bus.RaiseEvent(new EventoRegistradoEvent(evento.Id, evento.Nome, evento.DataInicio, evento.DataFim, evento.Gratuito,evento.Valor, evento.OnLine, evento.NomeEmpresa));
            }
        }

        public void Handle(AtualizarEventoCommand message)
        {
            throw new NotImplementedException();
        }
        
        public void Handle(ExcluirEventoCommand Message)
        {
            throw new NotImplementedException();
        }
    }
}
