using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.IO.Application.ViewModel
{
    public class EstadoViewModel
    {
        public string UF { get; set; }

        public string Nome { get; set; }

        public static List<EstadoViewModel> ListarEstados()
        {
            return new List<EstadoViewModel>
            {
                new EstadoViewModel { UF = "AC", Nome="Acre" },
                new EstadoViewModel { UF = "AL", Nome="Alagoas" },
                new EstadoViewModel { UF = "AP", Nome="Amapá" },
                new EstadoViewModel { UF = "AM", Nome="Amazonas" },
                new EstadoViewModel { UF = "BA", Nome="Bahia" },
                new EstadoViewModel { UF = "CE", Nome="Ceará" },
                new EstadoViewModel { UF = "DF", Nome="Distrito Federal" },
                new EstadoViewModel { UF = "ES", Nome="Espírito Santo" },
                new EstadoViewModel { UF = "GO", Nome="Goiás" },
                new EstadoViewModel { UF = "MA", Nome="Maranhão" },
                new EstadoViewModel { UF = "MT", Nome="Mato Grosso" },
                new EstadoViewModel { UF = "MS", Nome="Mato Grosso do Sul" },
                new EstadoViewModel { UF = "MG", Nome="Minas Gerais" },
                new EstadoViewModel { UF = "PA", Nome="Pará" },
            };
        }
    }
}
