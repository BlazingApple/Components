namespace BlazingApple.Components;

/// <summary>A minimalist card</summary>
public partial class MinimalCard : ComponentBase
{
	/// <summary>Captures/renders standard HTML attributes passed to the card</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object> AdditionalAttributes { get; set; } = null!;

	/// <summary>Content to render inside the card.</summary>
	[Parameter, EditorRequired]
	public RenderFragment? ChildContent { get; set; }
}
