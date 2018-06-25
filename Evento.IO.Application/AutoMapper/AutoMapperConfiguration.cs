using AutoMapper;
using Evento.IO.Application.ViewModel;
using Eventos.IO.Domain.Eventos;
using Eventos.IO.Domain.Eventos.Commands;

namespace Evento.IO.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMapptings()
        {
            return new MapperConfiguration(ps => 
            {
                ps.AddProfile(new DomainToViewModelMappingProfile);
                ps.AddProfile(new ViewModelToDomainMappingProfile);
            });
        }
    }

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Eventos.IO.Domain.Eventos.Evento, EventoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }

    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<EventoViewModel, RegistrarEventoCommand>()
                .ConstructUsing(c => new RegistrarEventoCommand())
        }
    }
}
