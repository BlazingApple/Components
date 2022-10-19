using BlazingApple.Components.Services;
using BlazingApple.FontAwesome.Services;
using Blazorise.Icons.FontAwesome;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingApple.Components.Configuration
{
	/// <summary>Adds the necessary services for <see cref="BlazingApple.Components" /> to work.</summary>
	public static class Startup
	{
		/// <summary>Adds the necessary services for <see cref="BlazingApple.Components" /> to work.</summary>
		/// <param name="services"><inheritdoc cref="IServiceCollection" /></param>
		/// <param name="configRoot">The root configuration object.</param>
		/// <returns><inheritdoc cref="IServiceCollection" /></returns>
		public static IServiceCollection AddBlazingAppleComponents(this IServiceCollection services, IConfiguration configRoot)
		{
			services.AddFontAwesomeIcons(); // Used in Icon.razor, probably can deprecate soon.
			IConfigurationSection config = configRoot.GetSection("FontAwesome");
			services.Configure<FontAwesomeSettings>(config);
			services.AddScoped<FontSearchService>();
			services.AddScoped<IClipboardService, ClipboardService>();
			services.AddScoped<DeviceManager>();
			return services;
		}
	}
}
