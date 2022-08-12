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

    /// <summary>The date this metric was last reported.</summary>
    [Parameter]
    public DateTimeOffset AsOfTime { get; set; }

    /// <summary>The current position in the progress counter.</summary>
    [Parameter]
    public int CurrentIndex { get; set; }

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
        _progressTooltip = CurrentIndex + " of " + TotalCount + " " + Units;
    }
}
