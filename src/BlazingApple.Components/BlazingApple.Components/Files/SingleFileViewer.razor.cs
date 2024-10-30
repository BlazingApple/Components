using BlazingApple.Components.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Files;

/// <summary>Renders a single <see cref="IRenderableFile"/></summary>
public partial class SingleFileViewer : ComponentBase
{
	private bool _isSmallDevice;

	/// <inheritdoc cref="IRenderableFile"/>
	[Parameter]
	public IRenderableFile? File { get; set; }

	/// <summary>Indicates the file has been loaded to the browser.</summary>
	[Parameter]
	public EventCallback FileLoaded { get; set; }

	[Inject]
	private DeviceManager DeviceManager { get; set; } = null!;

	/// <inheritdoc />
	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		await base.OnAfterRenderAsync(firstRender);
		if (firstRender)
		{
			DeviceSize deviceSize = await DeviceManager.GetScreenSize();
			_isSmallDevice = deviceSize <= DeviceSize.Small;
		}
	}

	private async Task OnIFrameLoaded()
	{
		if (FileLoaded.HasDelegate)
			await FileLoaded.InvokeAsync();
	}
}
