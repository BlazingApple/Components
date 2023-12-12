using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.HTMLElements;

/// <summary>Toggle button, has an active and inactive state.</summary>
public partial class ToggleButton : ComponentBase
{
	/// <summary>Button styles.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>Classes to apply to the primary button in the toggle button.</summary>
	[Parameter]
	public string Classes { get; set; } = "btn btn-light";

	/// <summary>Active or inactive state of the button</summary>
	[Parameter]
	public bool Value { get; set; }

	/// <summary>Event callback that allows people to bind to the Value parameter passed in.</summary>
	[Parameter]
	public EventCallback<bool> ValueChanged { get; set; }

	/// <summary>Child content to render within the button.</summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	private async Task ToggleClicked()
	{
		Value = !Value;
		if (ValueChanged.HasDelegate)
			await ValueChanged.InvokeAsync(Value);
	}
}
