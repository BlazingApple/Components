namespace BlazingApple.Components.Calendar;

/// <summary>The data required to create a calendar event on a customer's device.</summary>
public partial class CalendarEvent
{
	/// <summary>Event details or description(URL encoded format).</summary>
	public string? Description { get; set; }

	/// <summary>The end date/time.</summary>
	public DateTime End { get; set; }

	/// <summary>If true, no times are provided to the calendar event.</summary>
	public bool IsFullDay { get; set; }

	/// <summary>The location of the event, as a string.</summary>
	public string? Location { get; set; }

	/// <summary>The start date/time.</summary>
	public DateTime Start { get; set; }

	/// <summary>Title of the event (URL encoded format).</summary>
	public string Title { get; set; }

	/// <summary>Creates a starting event with default timestamps.</summary>
	public CalendarEvent()
	{
		Start = DateTime.Now;
		End = DateTime.Now.AddHours(.5);
		Title = $"Event at {Start}";
	}

	/// <summary>Quick constructor</summary>
	public CalendarEvent(DateTime start, DateTime end, string title)
		: this(start, end, title, null, null, false)
	{ }

	/// <summary>Full featured constructor.</summary>
	public CalendarEvent(DateTime start, DateTime end, string title, string? description, string? location, bool isFullDay)
	{
		Start = start;
		End = end;
		Title = title;
		Description = description;
		Location = location;
		IsFullDay = isFullDay;
	}
}
