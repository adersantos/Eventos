using System;
using Eventos.IO.Domain.Core.Models;

namespace Eventos.IO.Domain.Eventos
{
    public class Endereco : Entity<Evento>
    {
        public Endereco(Guid id)
        {
            Id = id;
        }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        
    }
}