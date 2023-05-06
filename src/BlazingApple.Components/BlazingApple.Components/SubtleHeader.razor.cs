namespace BlazingApple.Components;

/// <summary></summary>
public partial class SubtleHeader : ComponentBase
{
	/// <summary>The header details to show.</summary>
	[Parameter, EditorRequired]
	public string Name { get; set; } = null!;

	/// <summary>Additional styles to apply to the badge.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>Child content to render</summary>
	[Parameter]
    public RenderFragment? ChildContent { get; set; }
}