using Matrix.Common.Interfaces;
using Matrix.Core;
using Matrix.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Matrix.WebApp.Registrations
{
    public class ServicesRegistration : IRegistrationModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<IRotationService, RotationService>();
        }
    }
}
