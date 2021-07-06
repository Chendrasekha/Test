using leo.eventhandler.nuget;
using Leo.Guided.Buy.Service.Implementation;
using Leo.Guided.Buy.Service.Interface;
using Microsoft.Extensions.DependencyInjection;
using nexxe.decor.nuget;

namespace Leo.Guided.Buy.API
{
    public static class RegisterBusinessService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddDecor()
            .AddTransient<GepEventHandler>()    // Transient means decorator will inherit target's lifetime.
            .AddScoped<IEventHandlerService, EventHandlerService>().Decorated();
            services.AddScoped<IQuicklinkService, QuicklinkService>();
            services.AddScoped<IQuestionarieService, QuestionarieService>();
        }
    }
}
