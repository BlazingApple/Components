using BlazingApple.Components.Toasts;
using Blazored.Toast.Configuration;
using Blazored.Toast.Services;
using Microsoft.JSInterop;

namespace BlazingApple.Components.Services;

/// <summary>Programmatically copy text to the clipboard.</summary>
public partial class ClipboardService : IClipboardService
{
	private readonly IJSRuntime _jsInterop;
	private readonly IToastService _toastService;

	/// <summary>DI Constructor.</summary>
	public ClipboardService(IJSRuntime jsInterop, IToastService toastService)
	{
		_jsInterop = jsInterop;
		_toastService = toastService;
	}

	/// <summary>Copy text to the clipboard.</summary>
	/// <param name="text">The text to copy.</param>
	/// <returns>Async op.</returns>
	public async Task CopyToClipboard(string text)
	{
		await _jsInterop.InvokeVoidAsync("navigator.clipboard.writeText", text);
		_toastService.ShowToast<CopiedToClipboardToast>(UpdateToastSettings);
	}

	private void UpdateToastSettings(ToastSettings settings)
	{
		settings.Timeout = 2;
		settings.AdditionalClasses += "blazored-toast-small";
	}
}
