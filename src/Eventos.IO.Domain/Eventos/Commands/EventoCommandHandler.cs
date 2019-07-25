using Eventos.IO.Domain.CommandHandlers;
using Eventos.IO.Domain.Core.Bus;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Eventos.Events;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using System;

namespace Eventos.IO.Domain.Eventos.Commands
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
            var evento = new Evento(message.Nome, message.DataInicio, message.DataFim, message.Gratuito, message.Valor, message.OnLine, message.NomeEmpresa);

            if(!EventoValido(evento)) return;

            //TODO:
            //validações de Negócio
            //Organizador pode registrar evento?

            //Persistência
            _eventoRepository.Adicionar(evento);

            if (Commit())
            {
                //Notificar processo concluído
                Console.WriteLine("Evento registrado com sucesso.");
                _bus.RaiseEvent(new EventoRegistradoEvent(evento.Id, evento.Nome, evento.DataInicio, evento.DataFim, evento.Gratuito,evento.Valor, evento.OnLine, evento.NomeEmpresa));
            }
        }

        public void Handle(AtualizarEventoCommand message)
        {
            //verifica se evento existe
            if (!EventoExistente(message.Id, message.MessageType)) return;

            //recebe o comando e tranforma na entidade
            //trabalhar com Factory pois permite melhor flexibilização na construção da classe
            var evento = Evento.EventoFactory.NovoEventoCompleto(message.Id, message.Nome, message.DescricaoCurta,
                                              message.DescricaoLonga, message.DataInicio, message.DataFim,
                                              message.Gratuito, message.Valor, message.OnLine, message.NomeEmpresa, null);

            if (!EventoValido(evento)) return;

            _eventoRepository.Atualizar(evento);

            //se evento foi atualizado com sucesso
            if (Commit())
            {
                _bus.RaiseEvent(new EventoAtualizadoEvent(evento.Id, evento.Nome, evento.DescricaoCurta, evento.DescricaoLonga,
                                                          evento.DataInicio, evento.DataFim, evento.Gratuito, evento.Valor,
                                                          evento.Online, evento.NomeEmpresa));
            }
        }
        
        public void Handle(ExcluirEventoCommand message)
        {
            //verifica se evento existe
            if (!EventoExistente(message.Id, message.MessageType)) return;

            _eventoRepository.Remove(message.Id);

            if (Commit())
                _bus.RaiseEvent(new EventoExcluidoEvent(message.Id));
        }

        //método para simplesmente efetivar validações
        private bool EventoValido(Evento evento)
        {
            if (evento.EhValido()) return true;

            NotificarValidacoesErro(evento.ValidationResult);

            return false;
        }

        //método para validações se evento existe
        private bool EventoExistente(Guid id, string messageType)
        {
            var evento = _eventoRepository.ObterPorId(id);

            if (evento != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Evento não encontrado."));

            return false;

        }
    }
}
