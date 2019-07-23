using System;
using Eventos.IO.Domain.Core.Models;
using FluentValidation;

namespace Eventos.IO.Domain.Eventos
{
    public class Endereco : Entity<Endereco>
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public Guid? EventoId { get; set; }
        
        //EF prop de navegação
        public virtual Evento Evento { get; private set; }

        public Endereco(Guid id, string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado, Guid? eventoId, Evento evento)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
            EventoId = eventoId;
        }

        //Contrutor para o EF
        protected Endereco(){}
        
        public override bool EhValido()
        {
            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("Logradouro não pode ser nulo")
                .Length(2, 150).WithMessage("Nome do Logradouro precisa ter entre 2 e 150 caracteres");
            
            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("Bairro necessário")
                .Length(2, 150).WithMessage("Nome do Bairro precisa ter entre 2 e 150 caracteres");
            
            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("Cidade necessária")
                .Length(2, 150).WithMessage("Nome da Cidade precisa ter entre 2 e 150 caracteres");
            
            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("Estado necessário")
                .Length(2, 150).WithMessage("Nome do Estado precisa ter entre 2 e 150 caracteres");
            
            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("CEP necessário")
                .Length(2, 150).WithMessage("CEP precisa ter 8 caracteres");

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("Número do endereço necessário")
                .Length(2, 150).WithMessage("Número precisa estar entre 1 e 150 caracteres");

            ValidationResult = Validate(this);
            
            return ValidationResult.IsValid;
        }
    }
}