namespace BlazingApple.Components.Calendar;

/// <summary>Renders a calendar showing a particular day.</summary>
public partial class CalendarIcon : ComponentBase
{
    /// <summary>Additional styles to apply to the badge.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>The date/time to render</summary>
    [Parameter, EditorRequired]
    public DateTime Date { get; set; }

    /// <summary>"small", "medium", or "large" to change the size of the calendar, or use your own css class.</summary>
    [Parameter]
    public string SizeClass { get; set; } = "small";
}
