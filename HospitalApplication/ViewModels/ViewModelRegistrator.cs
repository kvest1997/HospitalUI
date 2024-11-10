using HospitalUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalApplication.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModel(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            ;

    }
}
