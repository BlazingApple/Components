using Blazorise.Icons.FontAwesome;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingApple.Components.Configuration
{
    /// <summary>Adds the necessary services for <see cref="BlazingApple.Components" /> to work.</summary>
    public static class Startup
    {
        /// <summary>Adds the necessary services for <see cref="BlazingApple.Components" /> to work.</summary>
        /// <param name="serviceCollection"><inheritdoc cref="IServiceCollection" /></param>
        /// <returns><inheritdoc cref="IServiceCollection" /></returns>
        public static IServiceCollection AddBlazingAppleComponents(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddFontAwesomeIcons();
            return serviceCollection;
        }
    }
}
