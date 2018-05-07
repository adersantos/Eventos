using Eventos.IO.Domain.Core.Models;
using Eventos.IO.Domain.Organizadores;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.IO.Domain.Eventos
{
    public class Evento : Entity<Evento>
    {
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

        public decimal Valor { get; protected set; }

        public bool OnLine { get; protected set; }

        public string NomeEmpresa { get; protected set; }

        public Categoria Categoria { get; protected set; }

        public ICollection<Tags> Tags { get; protected set; }

        public Endereco Endereco { get; protected set; }

        public Organizador Organizador { get; protected set; }

        public Dictionary<string, string> ErrosValidacao { get; set; }

        public override bool EhValido()
        {
            Validar();

            return false;
        }

        #region Validações

        private void Validar()
        {
            ValidarNome();
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
                .ExclusiveBetween(0 ,0).When( e => e.Gratuito)
                .WithMessage("O valor não deve ser diferente de zero para evento gratuito.");
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
        #endregion
    }
}
