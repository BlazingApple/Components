using BlazingApple.Components.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components;

public partial class AddToCalendar : ComponentBase
{
    private bool _dropdownExposed;
    private CalendarEvent? _event;

    /// <summary>Additional styles to apply to the badge.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>The Css classes to apply to the backdrop, if any.</summary>
    [Parameter]
    public string BackdropClasses { get; set; } = "";

    /// <summary>Rendered as the interior of the button content.</summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <inheritdoc cref="CalendarEvent.Description" />
    [Parameter]
    public string? Description { get; set; }

    /// <summary>The Css classes to the dropdown, if any.</summary>
    [Parameter]
    public string DropdownClasses { get; set; } = "";

    /// <summary>The end date/time. If null, the event is full day.</summary>
    [Parameter]
    public DateTime End { get; set; }

    /// <summary>If true, uses the entire date.</summary>
    [Parameter]
    public bool IsFullDay { get; set; }

    /// <summary>The label to apply to the button.</summary>
    [Parameter]
    public string? Label { get; set; } = "Add to Calendar";

    /// <inheritdoc cref="CalendarEvent.Location" />
    [Parameter]
    public string? Location { get; set; }

    /// <summary>The start date/time of the event</summary>
    [Parameter, EditorRequired]
    public DateTime Start { get; set; }

    /// <inheritdoc cref="CalendarEvent.Title" />
    [Parameter, EditorRequired]
    public string Title { get; set; } = null!;

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        _event = new CalendarEvent(Start, End, Title, Description, Location, IsFullDay);
    }

    private void ToggleDropdown()
    {
        _dropdownExposed = !_dropdownExposed;
    }
}
