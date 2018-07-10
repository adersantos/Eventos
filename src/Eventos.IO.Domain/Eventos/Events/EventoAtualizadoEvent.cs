using System;

namespace Eventos.IO.Domain.Eventos.Events
{
    public class EventoAtualizadoEvent : BaseEventoEvent
    {
        public EventoAtualizadoEvent(Guid id,
                                     string nome,
                                     string descCurta,
                                     string descLonga,
                                     DateTime dataInicio,
                                     DateTime dataFim,
                                     bool gratuito,
                                     decimal valor,
                                     bool onLine,
                                     string nomeEmpresa)
        {
            Id = id;
            Nome = nome;
            DescricaoCurta = descCurta;
            DescricaoLonga = descLonga;
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
