using AutoMapper;
using RentCars.Communication.Requests;
using RentCars.Domain.Enums.Car;
using RentCars.Domain.Enums.User;

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
            CreateMap<RequestRegisterCarJson, Domain.Entities.Car>()
                // Para ignorar o case sensitive dos Enums
                .ForMember(dest => dest.Steering_type, opt => opt.MapFrom(src => Enum.Parse<EnumCarSteeringType>(src.Steering_type, true)));

            CreateMap<RequestRegisterUserJson, Domain.Entities.User>()
                // Realizado o mapeamento manual da senha para aplicar criptografia
                .ForMember(dest => dest.Password, opt => opt.Ignore())

                // Para ignorar o case sensitive dos Enums
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => Enum.Parse<EnumGender>(src.Gender, true)))
                .ForMember(dest => dest.Document_Type, opt => opt.MapFrom(src => Enum.Parse<EnumDocumentType>(src.Document_Type, true)))

                // Referente ao endereço
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address!.City))
                .ForMember(dest => dest.Zip_Code, opt => opt.MapFrom(src => src.Address!.Zip_Code))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address!.Country))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address!.Street))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address!.State))
                .ForMember(dest => dest.Neighborhood, opt => opt.MapFrom(src => src.Address!.Neighborhood))
                .ForMember(dest => dest.House_Number, opt => opt.MapFrom(src => src.Address!.House_Number));
        }

        private void DomainToResponse()
        {
            // futuro
        }
    }
}
