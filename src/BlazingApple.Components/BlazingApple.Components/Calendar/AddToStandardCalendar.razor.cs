using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Calendar;

/// <summary>Delivers an .ics event to the browser.</summary>
public partial class AddToStandardCalendar : ComponentBase
{
    /// <summary>Additional styles to apply to the badge.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>Rendered as the interior of the button content.</summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <inheritdoc cref="CalendarEvent" />
    [Parameter, EditorRequired]
    public CalendarEvent? Event { get; set; }

    /// <summary>The label to apply to the button, if any.</summary>
    [Parameter]
    public string Label { get; set; } = "Add to Apple Calendar";
}
