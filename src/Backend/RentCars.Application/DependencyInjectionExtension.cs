using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentCars.Application.Services.AutoMapper;
using RentCars.Application.Services.Cryptography;
using RentCars.Application.UseCases.Car.Register;
using RentCars.Application.UseCases.Login.DoLogin;
using RentCars.Application.UseCases.User.Register;

namespace RentCars.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            AddAutoMapper(services);
            AddUseCases(services);
            AddPasswordEncripter(services, configuration);
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
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
        }

        private static void AddPasswordEncripter(IServiceCollection services, IConfiguration configuration)
        {
            var additionalKey = configuration.GetValue<string>("Settings:Password:AdditionalKey");
            services.AddScoped(option => new PasswordEncripter(additionalKey!));
        }
    }
}
