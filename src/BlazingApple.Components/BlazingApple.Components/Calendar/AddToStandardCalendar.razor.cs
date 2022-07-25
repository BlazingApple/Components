using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.JSInterop;

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

    /// <summary>The desired filename, without the file type.</summary>
    [Parameter]
    public string? Filename { get; set; }

    /// <summary>The label to apply to the button, if any.</summary>
    [Parameter]
    public string Label { get; set; } = "Apple/Outlook";

    /// <summary>Called when the component is clicked.</summary>
    [Parameter]
    public EventCallback OnClick { get; set; }

    [Inject]
    private IJSRuntime JsRuntime { get; set; } = null!;

    /// <summary>Downloads the calendar event to the browser.</summary>
    /// <returns>Nothing, async op.</returns>
    private async Task DownloadEvent()
    {
        if (Event is null)
            throw new ArgumentNullException(nameof(Event), "unexpected null error for event");

        if (string.IsNullOrEmpty(Filename))
            Filename = $"New-Event-{Event.Start.ToString("yyyy-MM-dd")}";

        await JsRuntime.InvokeVoidAsync("downloadCalendarEvent", Event.Title, Event.Description, Event.Location, Event.Start, Event.End, Filename);

        await OnClickInternal();
    }

    private async Task OnClickInternal()
    {
        if (OnClick.HasDelegate)
            await OnClick.InvokeAsync();
    }
}
