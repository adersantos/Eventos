using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Eventos.IO.Domain.Core.Notifications;
using Eventos.IO.Domain.Eventos.Repository;
using Eventos.IO.Domain.Interfaces;
using Eventos.IO.Services.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.IO.Services.Api.Controllers
{
    public class EventosController : BaseController
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        
        public EventosController(INotificationHandler<DomainNotification> notifications, 
                                 IUser user,
                                 IEventoRepository eventoRepository,
                                 IMapper mapper,
                                 IMediatorHandler mediator) : base(notifications, user, mediator)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("eventos")]
        [AllowAnonymous]
        public IEnumerable<EventoViewModel> Get()
        {
            return _mapper.Map<IEnumerable<EventoViewModel>>(_eventoRepository.ObterTodos());
        }
    }
}