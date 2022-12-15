using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Services;

/// <summary>Determine information about the user's device.</summary>
public partial class DeviceManager
{
	private readonly IJSRuntime _jSRuntime;

	/// <summary>DI constructor.</summary>
	public DeviceManager(IJSRuntime jSRuntime)
	{
		_jSRuntime = jSRuntime;
	}

	/// <summary>Gets the screen size for the current device</summary>
	/// <returns><see cref="DeviceSize" /></returns>
	public async Task<DeviceSize> GetScreenSize()
	{
		int windowWidth = await _jSRuntime.InvokeAsync<int>("getScreenSize");

		DeviceSize screenSize = DeviceSize.Large;
		if (windowWidth < 768)
			screenSize = DeviceSize.ExtraSmall;
		else if (windowWidth < 992)
			screenSize = DeviceSize.Small;
		else if (windowWidth < 1200)
			screenSize = DeviceSize.Medium;

		return screenSize;
	}

	/// <summary>Determines if a device is a mobile device or not.</summary>
	/// <returns><c>true</c> if a mobile device, meaning they have no ability to click, <c>false</c> otherwise.</returns>
	public async Task<bool> IsTouchDevice()
	{
		bool isMobileDevice = await _jSRuntime.InvokeAsync<bool>("isMobileDevice");
		return isMobileDevice;
	}
}

/// <summary>Device sizes that correspond to Bootstrap size.</summary>
public enum DeviceSize
{
	/// <summary>Window widths less than 768px.</summary>
	ExtraSmall,

	/// <summary>Window widths less than 992px.</summary>
	Small,

	/// <summary>Window widths less than 1200px.</summary>
	Medium,

	/// <summary>Window widths greater or equal to 1200px.</summary>
	Large,
}
