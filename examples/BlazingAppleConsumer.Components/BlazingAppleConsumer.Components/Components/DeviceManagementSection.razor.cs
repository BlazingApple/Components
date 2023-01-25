using BlazingApple.Components.Services;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Components.Components;

public partial class DeviceManagementSection : ComponentBase
{
	private DeviceSize _deviceSize;

	[Inject]
	public DeviceManager DeviceManager { get; set; } = null!;

	private async Task DeviceSizeClicked()
	{
		_deviceSize = await DeviceManager.GetScreenSize();
	}
}
