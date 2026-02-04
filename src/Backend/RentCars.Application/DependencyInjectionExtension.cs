using Microsoft.Extensions.DependencyInjection;
using RentCars.Application.Services.AutoMapper;
using RentCars.Application.UseCases.Car.Register;

namespace RentCars.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());
            }).CreateMapper();

            services.AddScoped(option => autoMapper);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterCarUseCase, RegisterCarUseCase>();
        }
    }
}
