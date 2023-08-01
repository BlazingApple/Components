namespace BlazingApple.Components.HTMLElements;

/// <summary>A segment</summary>
public partial class ProgressBarSegment : ComponentBase
{
	/// <summary>Additional styles to apply to the bar.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>The container <see cref="ProgressBarMulti"/>.</summary>
	[Parameter, CascadingParameter]
	public ProgressBarMulti? Parent { get; set; }

	/// <summary>The current value for this segment.</summary>
	[Parameter]
	public int Value { get; set; }

	/// <summary>Additional classes to apply to the bar.</summary>
	[Parameter]
	public string? AdditionalClasses { get; set; }

	/// <summary>The display text to render <em>on</em> the bar</summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>Tooltip for the segment. Displayed on hover.</summary>
	[Parameter]
	public string? Tooltip { get; set; }

	/// <summary>Width as a percentage of the total width of the bar.</summary>
	private string Width => $"{((double)Value / Parent?.DenominatorCore ?? Value) * 100}%";

	private string StyleString => AdditionalAttributes?.ContainsKey("style") ?? false ? $"width: {Width}; {AdditionalAttributes["style"]}" : $"width: {Width};";

	/// <inheritdoc />
	protected override async Task OnParametersSetAsync()
	{
		await base.OnParametersSetAsync();

		if (!(Parent?.Children?.Contains(this) ?? true))
			Parent.Children.Add(this);
	}
}
