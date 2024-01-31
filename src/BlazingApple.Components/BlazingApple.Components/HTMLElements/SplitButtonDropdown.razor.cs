using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.HTMLElements;

/// <summary>A split button dropdown.</summary>
public partial class SplitButtonDropdown : ComponentBase
{
	private bool _expanded;

	/// <summary>Button styles.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>Classes to apply to the primary button in the split button group.</summary>
	[Parameter]
	public string SplitButtonClasses { get; set; } = "btn btn-light";

	/// <summary>Dropdown buttons content.</summary>
	[Parameter, EditorRequired]
	public RenderFragment DropbownButtons { get; set; } = null!;

	/// <summary>Primary button content.</summary>
	[Parameter, EditorRequired]
	public RenderFragment PrimaryButton { get; set; } = null!;

	private string BtnGroupClasses => _expanded ? "btn-group show" : "btn-group";

	private string BtnGroupStyle => _expanded ? "z-index: 1031;" : "";

	private string DropdownMenuClasses => _expanded ? "dropdown-menu show" : "dropdown-menu";

	private void DropdownClick() => _expanded = !_expanded;
}
