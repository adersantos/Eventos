using System;

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
