using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Lists;

/// <summary>Renders a selector/input field for selecting a page size value</summary>
public partial class DropDownPageSize : ComponentBase
{
	/// <summary>Captures extra attributes</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IReadOnlyDictionary<string, object?> AdditionalAttributes { get; set; } = null!;

	/// <summary>Current value of the dropdown.</summary>
	[Parameter]
	public int Value { get; set; }

	/// <summary>Callback</summary>
	[Parameter]
	public EventCallback<int> ValueChanged { get; set; }

	/// <summary>Label for the drop down.</summary>
	[Parameter]
	public string Label { get; set; } = "Page size";

	/// <summary>Class to throw on the dropdown button.</summary>
	[Parameter]
	public string ButtonClass { get; set; } = "ms-1 btn-sm btn-outline-primary d-flex align-items-center";

	/// <inheritdoc />
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		if (Value is < 5 or > 500)
		{
			Value = 5;
			await ValueChanged.InvokeAsync(Value);
		}
	}
}
