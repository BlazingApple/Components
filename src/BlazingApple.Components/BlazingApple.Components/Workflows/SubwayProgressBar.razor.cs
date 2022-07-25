using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Workflows;

/// <summary>Represents a multi-step process and colors in the completed or in progress portion of that process.</summary>
public partial class SubwayProgressBar : ComponentBase
{
    /// <summary>Additional attributes to apply to the timeline container.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>This is used to display which stop was last completed.</summary>
    [Parameter]
    public int LastCompletedStopIndex { get; set; }

    /// <summary>The list of subways stops to render.</summary>
    [Parameter]
    public IList<ISubwayStop>? Stops { get; set; }
}
