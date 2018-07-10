using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Organizadores;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Eventos.IO.Domain.Eventos
{
    public class Evento : Entity<Evento>
    {
        //construtor privado para utilizar o Factory
        private Evento(){ }

        public Evento(string nome, 
                      DateTime dataInicio,
                      DateTime dataFim,
                      bool gratuito,
                      decimal valor,
                      bool onLine,
                      string nomeEmpresa)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Gratuito = gratuito;
            Valor = valor;
            OnLine = onLine;
            NomeEmpresa = nomeEmpresa;

            ErrosValidacao = new Dictionary<string, string>();
            if (nome.Length < 3)
                ErrosValidacao.Add("Nome: ","O nome do evento não pode ser menor que 3");

            if (gratuito && valor != 0)
                ErrosValidacao.Add("Valor: ","Não pode ter valor sendo gratuito");

        }

        public string Nome { get; protected set; }

        public string DescricaoCurta { get; protected set; }

        public string DescricaoLonga { get; protected set; }

        public DateTime DataInicio { get; protected set; }

        public DateTime DataFim { get; protected set; }

        public bool Gratuito { get; protected set; }

        public bool Online { get; set; }

        public decimal Valor { get; protected set; }

        public bool OnLine { get; private set; }

        public string NomeEmpresa { get; private set; }

        public bool Excluido { get; private set; }

        public ICollection<Tags> Tags { get; protected set; }

        #region EF Propriedades de chave entre entidades
        public Guid? CategoriaId { get; private set; }
        public Guid? EnderecoId { get; private set; }
        public Guid OrganizadorId { get; private set; }
        #endregion

        #region EF Propriedades de navegação
        public Categoria Categoria { get; protected set; }

        public Endereco Endereco { get; protected set; }

        public Organizador Organizador { get; protected set; }

        public Dictionary<string, string> ErrosValidacao { get; set; }
        #endregion

        #region Validações
        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarNome();
            ValidarValor();
            ValidarData();
            ValidarLocal();
            ValidarNomeEmpresa();
            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(n => n.Nome)
                .NotEmpty().WithMessage("O nome do evento precisa ser fornecido.")
                .Length(2, 150).WithMessage("O nome do evento precisa ter entre 2 e 150 caracteres.");
        }

        private void ValidarValor()
        {
            if(Gratuito)
            RuleFor(n => n.Valor)
                .ExclusiveBetween(0,0).When( e => e.Gratuito)
                .WithMessage("O valor deve ser zero para evento gratuito.");

            if (!Gratuito)
                RuleFor(n => n.Valor)
                    .ExclusiveBetween(1, 5000).When(e => e.Gratuito)
                    .WithMessage("O valor deve estar entre 1,00 e 5.000,00.");
        }

        private void ValidarData()
        {
            RuleFor(n => n.DataInicio)
                .GreaterThan(d => d.DataFim)
                .WithMessage("A data de início deve ser maior que a data final do evento.");
            RuleFor(n => n.DataInicio)
                .LessThan(DateTime.Now)
                .WithMessage("A data de início não deve ser menor que a data atual.");
        }

        private void ValidarLocal()
        {
            if (OnLine)
                RuleFor(c => c.Endereco)
                    .Null().When(c => c.OnLine)
                    .WithMessage("O evetno não deve possuir endereço se online");
            if (!Online)
                RuleFor(c => c.Endereco)
                    .NotNull().When(c => c.Online == false)
                    .WithMessage("O evento deve possuir um endereço.");
        }

        private void ValidarNomeEmpresa()
        {
            RuleFor(c => c.NomeEmpresa)
                .NotEmpty().WithMessage("O nome do organizador precisa ser fornecido.")
                .Length(2, 150).WithMessage("O nome do organizador precisa ter entre 2 e 150 caracteres.");
        }

        #endregion

        public static class EventoFactory
        {
            public static Evento NovoEventoCompleto(Guid id, string nome, string desCurta, string descLonga,
                                                    DateTime dataInicio, DateTime dataFim, bool gratuito,
                                                    decimal valor, bool online, string nomeEmpresa, Guid? organizadorId)
            {
                var evento = new Evento()
                {
                    Id = id,
                    Nome = nome,
                    DescricaoCurta = desCurta,
                    DescricaoLonga = descLonga,
                    DataInicio = dataInicio,
                    DataFim = dataFim,
                    Gratuito = gratuito,
                    Valor = valor,
                    Online = online,
                    NomeEmpresa = nomeEmpresa
                };

                if (organizadorId != null)
                {
                    evento.Organizador = new Organizador(organizadorId.Value);
                }

                return evento;
            }
        }
    }
}
