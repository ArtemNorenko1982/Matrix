using Microsoft.Extensions.DependencyInjection;

namespace Matrix.Common.Interfaces
{
    public interface IRegistrationModule
    {
        void Register(IServiceCollection services);
    }
}
