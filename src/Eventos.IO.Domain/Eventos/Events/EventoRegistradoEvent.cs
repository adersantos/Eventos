using Eventos.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class EventoRegistradoEvent : BaseEventoEvent
    {
        public EventoRegistradoEvent(Guid id,
                      string nome,
                      DateTime dataInicio,
                      DateTime dataFim,
                      bool gratuito,
                      decimal valor,
                      bool onLine,
                      string nomeEmpresa)
        {
            Id = id;
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            OnLine = onLine;
            NomeEmpresa = nomeEmpresa;

            AggregateId = id;  
        }
    }
}
