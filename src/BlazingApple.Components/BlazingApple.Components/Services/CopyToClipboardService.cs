using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Services;

/// <summary>Programmatically copy text to the clipboard.</summary>
public partial class ClipboardService : IClipboardService
{
	private readonly IJSRuntime _jsInterop;

	/// <summary>DI Constructor.</summary>
	public ClipboardService(IJSRuntime jsInterop) => _jsInterop = jsInterop;

	/// <summary>Copy text to the clipboard.</summary>
	/// <param name="text">The text to copy.</param>
	/// <returns>Async op.</returns>
	public async Task CopyToClipboard(string text)
		=> await _jsInterop.InvokeVoidAsync("navigator.clipboard.writeText", text);
}
