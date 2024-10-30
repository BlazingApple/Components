namespace BlazingApple.Components.Alerts;

/// <summary>Alert base.</summary>
public abstract class AlertBase : ComponentBase
{
	/// <summary>Overridden by <see cref="HeadingContent"/>. Defaults to <c>Success!</c></summary>
	[Parameter]
	public string? HeadingText { get; set; }

	/// <summary>Overrides <see cref="HeadingText"/></summary>
	[Parameter]
	public RenderFragment? HeadingContent { get; set; }

	/// <summary>Content to throw in the body, if any.</summary>
	[Parameter]
	public RenderFragment? BodyContent { get; set; }

	/// <summary>Whether the alert can be dismissed.</summary>
	[Parameter]
	public bool IsDismissible { get; set; }
}
