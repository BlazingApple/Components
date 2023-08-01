namespace BlazingApple.Components.HTMLElements;

/// <summary>Display multiple stacked bars on a progress bar.</summary>
public partial class ProgressBarMulti : ComponentBase
{
	/// <summary>Additional styles to apply to the bar.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>The total number units in the component. 
	/// This is optional if the sum of the segments equates to the total. Otherwise, pass in an arbitrary value.
	/// </summary>
	[Parameter]
	public int? Denominator { get; set; }

	/// <summary>The <c>true</c> denominator at any time.</summary>
	public int DenominatorCore => Denominator ?? Children?.Sum(s => s.Value) ?? 1;

	/// <summary>The set of bars.</summary>
	public List<ProgressBarSegment>? Children { get; set; } = new List<ProgressBarSegment>();

	/// <summary>The segments to render within the component.</summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }
}
