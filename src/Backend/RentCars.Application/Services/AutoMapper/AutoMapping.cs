using AutoMapper;
using RentCars.Communication.Requests;

namespace RentCars.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterCarJson, Domain.Entities.Car>();
                // .ForMember(dest => dest.Password, opt => opt.MapFrom(source => source.Password))
        }

        private void DomainToResponse()
        {
            // futuro
        }
    }
}
