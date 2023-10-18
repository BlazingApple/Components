namespace BlazingApple.Components.Calendar
{
    /// <summary>Renders a link that adds to a Google calendar.</summary>
    public partial class AddToGoogleCalendar : ComponentBase
    {
        private const string _withoutTimeFormat = "yyyyMMdd";
        private const string _withTimeFormat = "yyyyMMddTHHmmss";

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
        public string Label { get; set; } = "Google";

        /// <summary>Called when the component is clicked.</summary>
        [Parameter]
        public EventCallback OnClick { get; set; }

        private string LinkUrl => Event is not null ? $"https://calendar.google.com/calendar/render?action=TEMPLATE&text={Uri.EscapeDataString(Event.Title)}&location={Uri.EscapeDataString(Event.Location ?? "")}&details={Uri.EscapeDataString(Event.Description ?? "")}&dates={Event.Start.ToString(TimeFormat)}/{Event.End.ToString(TimeFormat)}" : "";

        private string TimeFormat => Event?.IsFullDay ?? false ? _withoutTimeFormat : _withTimeFormat;

        private async Task OnClickInternal()
        {
            if (OnClick.HasDelegate)
                await OnClick.InvokeAsync();
        }
    }
}
