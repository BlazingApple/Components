using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Workflows;

/// <summary>Center "stop" between two lines--this represents a "step" in a workflow.</summary>

public partial class SubwayProgressBarStop : ComponentBase
{
    private string _contentContainerClasses = null!;
    private string _leftTimelineLineClasses = null!;
    private string _rightTimelineLineClasses = null!;
    private string _subwayStopBadgeClasses = null!;

    /// <summary>The description of the stop, displayed in a subdued fashion.</summary>
    [Parameter]
    public string? Description { get; set; }

    /// <summary>Whether or not the stop is complete.</summary>
    [Parameter]
    public bool IsComplete { get; set; }

    /// <summary>Whether or not the stop is the current stop.</summary>
    [Parameter]
    public bool IsCurrentStop { get; set; }

    /// <summary>Whether or not the stop is the first subway stop, and should not have a separator preceding it.</summary>
    [Parameter]
    public bool IsFirst { get; set; }

    /// <summary>Whether or not the stop is the last subway stop, and should not have a separator proceding it.</summary>
    [Parameter]
    public bool IsLast { get; set; }

    /// <summary>The title of the subway stop, displayed prominently underneath the icon.</summary>
    [Parameter, EditorRequired]
    public string Title { get; set; } = null!;

    /// <summary>Applies the appropriate classes to stops.</summary>
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        _subwayStopBadgeClasses = IsComplete ? "og-badge og-primary" : "og-badge og-primary not-complete";
        _contentContainerClasses = "mb-2 timelineStopContentContainer";
        _leftTimelineLineClasses = IsComplete ? "timelineSeperator left complete" : "timelineSeperator left";
        _rightTimelineLineClasses = IsComplete && !IsCurrentStop ? "timelineSeperator right complete" : "timelineSeperator right";

        if (IsFirst)
            _contentContainerClasses += " first";
        else if (IsLast)
            _contentContainerClasses += " last";
    }
}
