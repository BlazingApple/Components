using BlazingApple.Components.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.HTMLElements;

/// <summary>A progress bar rendering component.</summary>
public partial class ProgressBar : ComponentBase
{
	private string? _progressTooltip, _asOfTime, _percentComplete;

	/// <summary>Additional attributes to apply to the timeline container.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>The date this metric was last reported.</summary>
	[Parameter]
	public DateTimeOffset AsOfTime { get; set; }

	/// <summary>The current position in the progress counter.</summary>
	[Parameter]
	public int CurrentIndex { get; set; }

	/// <summary>Defaults <c>true</c>. If <c>true</c>, shows text displaying the percentage complete.</summary>
	[Parameter]
	public bool ShowPercentComplete { get; set; } = true;

	/// <summary>If <c>true</c>, don't show a tooltip.</summary>
	[Parameter]
	public bool SuppressTooltip { get; set; }

	/// <summary>The sum total number of positions in the bar.</summary>
	[Parameter]
	public int TotalCount { get; set; }

	/// <summary>The user friendly unit name.</summary>
	[Parameter]
	public string? Units { get; set; }

	///<inheritdoc/>
	protected override void OnParametersSet()
	{
		if (TotalCount <= 0)
			return;

		_asOfTime = "As of " + CommonViewUtils.GetDateTimeString(AsOfTime);
		_percentComplete = CommonViewUtils.GetPercentString(((float)CurrentIndex) / TotalCount);

		if (!SuppressTooltip)
			_progressTooltip = CurrentIndex + " of " + TotalCount + " " + Units;
		else
			_progressTooltip = null;
	}
}
