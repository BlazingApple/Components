using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Label { get; set; } = "Add to Google Calendar";

        private string LinkUrl => Event is not null ? $"https://calendar.google.com/calendar/render?action=TEMPLATE&text={Event.Title}&details={Event.Description}&dates={Event.Start.ToString(TimeFormat)}/{Event.End.ToString(TimeFormat)}&location={Event.Location}" : "";

        private string TimeFormat => Event?.IsFullDay ?? false ? _withoutTimeFormat : _withTimeFormat;
    }
}
