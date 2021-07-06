using Leo.Guided.Buy.DataAccess.Implementation;
using Leo.Guided.Buy.DataAccess.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Leo.Guided.Buy.API
{
    public static class RegisterDataAccess
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IQuicklinkDataAccess, QuicklinkDataAccess>();
        }
    }
}
