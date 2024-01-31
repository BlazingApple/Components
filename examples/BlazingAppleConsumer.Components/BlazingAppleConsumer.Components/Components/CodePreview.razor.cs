using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Components.Components;
public partial class CodePreview : ComponentBase
{
	private readonly Guid _id = Guid.NewGuid();

	/// <summary>The code to render.</summary>
	[Parameter, EditorRequired]
	public string? Code { get; set; }

	/// <summary>The code to render.</summary>
	[Parameter]
	public string Label { get; set; } = "Usage";

	/// <summary>Whether this is just an inline reference to code.</summary>
	[Parameter]
	public bool Inline { get; set; }
}
