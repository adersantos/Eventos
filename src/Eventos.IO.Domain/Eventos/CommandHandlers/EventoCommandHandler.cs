using Eventos.IO.Domain.CommandHandlers;
using Eventos.IO.Domain.Core.Events;
using Eventos.IO.Domain.Eventos.Commands;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Eventos.CommandHandlers
{
    public class EventoCommandHandler : CommandHandler,
        IHandler<RegistrarEventoCommand>, 
        IHandler<AtualizarEventoCommand>,
        IHandler<ExcluirEventoCommand>
    {

        private readonly IEventoRepository _eventoRepository;

        public EventoCommandHandler(IEventoRepository eventoRepository, IUnityOfWork uow) : base(uow)
        {
            _eventoRepository = eventoRepository;
        }

        public void Handle(ExcluirEventoCommand Message)
        {
            var evento = new Evento(Message.Nome, Message.DataInicio, Message.DataFim,
                                    Message.Gratuito, Message.Valor, Message.OnLine, Message.NomeEmpresa);

            if (!evento.EhValido())
            {
                NotificarValidacoesErro(evento.ValidationResult);
                return;
            }

            //validações de Negócio


            //Persistência
            _eventoRepository.Add(evento);

            if (Commit())
            {
                //Notificar processo concluído
            }
        }

        public void Handle(AtualizarEventoCommand message)
        {
            throw new NotImplementedException();
        }

        public void Handle(RegistrarEventoCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
