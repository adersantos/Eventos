using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.IO.Application.ViewModel
{
    public class EventoViewModel
    {
        public EventoViewModel()
        {
            Id = Guid.NewGuid();
            Endereco = new EnderecoViewModel();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O Nome é requerido")]
        [MinLength(2, ErrorMessage ="O tamanho mínimo do Nome é {0}")]
        [MaxLength(150, ErrorMessage ="O tamanho máximo do Nome é {0}")]
        [Display(Name ="Nome do Evento")]
        public string Nome { get; set; }

        [Display(Name ="Descricao curta do Evento")]
        public string DescricaoCurta { get; set; }

        [Display(Name ="Descricao longa do Evento")]
        public string DescricaoLonga { get; set; }

        [Display(Name ="Início do Evento")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Fim do Evento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataFim { get; set; }

        [Display(Name ="Será gratuito?")]
        public bool Gratuito { get; set; }

        public bool Online { get; set; }

        [Display(Name ="Valor")]
        [DisplayFormat(DataFormatString ="{0:C}")]
        public decimal Valor { get; set; }

        [Display(Name ="Será Online?")]
        public bool OnLine { get; private set; }

        [Display(Name ="Empresa / Grupo Organizador")]
        public string NomeEmpresa { get; set; }


        public EnderecoViewModel Endereco { get; set; }
    }
}
