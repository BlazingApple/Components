using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Alerts;

/// <summary>Shows a subtle warning</summary>
public partial class SubtleWarning : ComponentBase
{
	/// <summary>Display left of the text if provided</summary>
    public RenderFragment? ChildContent { get; set; }

	/// <summary>The warning message to display.</summary>
	[Parameter, EditorRequired]
	public string? Message { get; set; }

	/// <summary>If true, make the text small</summary>
	[Parameter]
	public bool SmallText { get; set; }
}

