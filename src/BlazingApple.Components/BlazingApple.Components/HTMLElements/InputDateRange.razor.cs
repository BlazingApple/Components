using Blazorise;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazingApple.Components.HTMLElements;

/// <summary>Allows setting a range of dates (begin and end).</summary>
public partial class InputDateRange : ComponentBase
{
	/// <inheritdoc cref="InputDateType" />
	[Parameter]
	public InputDateType DateType { get; set; }

	/// <summary>The default range</summary>
	[Parameter]
	public DateRange? DefaultRange { get; set; }

	/// <summary>The label to show atop the daterange.</summary>
	[Parameter]
	public string? Label { get; set; }

	/// <summary>Value to bind to.</summary>
	[Parameter]
	public DateRange Value { get; set; } = null!;

	/// <summary>Required to support @bind-Value.</summary>
	[Parameter]
	public EventCallback<DateRange> ValueChanged { get; set; }

	private DateTime BoundEndValue
	{
		get => Value.EndDate;

		set
		{
			DateTime adjustedValue = AdjustEndDateBasedOnInput(value);
			Value.SetEndDate(adjustedValue);
			ValueChanged.InvokeAsync(Value);
		}
	}

	private DateTime BoundStartValue
	{
		get => Value.StartDate;
		set
		{
			DateTime adjustedValue = AdjustStartDateBasedOnInput(value);
			Value.SetStartDate(adjustedValue);
			ValueChanged.InvokeAsync(Value);
		}
	}

	/// <inheritdoc />
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();

		Value = new DateRange()
		{
			StartDate = AdjustStartDateBasedOnInput(DefaultRange?.StartDate ?? DateTime.Now),
			EndDate = AdjustEndDateBasedOnInput(DefaultRange?.EndDate ?? DateTime.Now),
		};

		await ValueChanged.InvokeAsync(Value);

		StateHasChanged();
	}

	private DateTime AdjustDateBasedOnInput(DateTime dateTime, bool isStartDate)
	{
		DateTime adjustedDateTime = DateType switch
		{
			InputDateType.Time => dateTime,
			InputDateType.DateTimeLocal => dateTime,
			InputDateType.Date => SetTime(dateTime.Date, isStartDate ? TimeOnly.MinValue : TimeOnly.MaxValue),
			InputDateType.Month => isStartDate ? ToFirstDayOfMonth(dateTime) : ToLastDayOfMonth(dateTime),
			_ => throw new ArgumentOutOfRangeException(nameof(dateTime)),
		};

		return adjustedDateTime;
	}

	private DateTime AdjustEndDateBasedOnInput(DateTime dateTime)
		=> AdjustDateBasedOnInput(dateTime, false);

	private DateTime AdjustStartDateBasedOnInput(DateTime dateTime)
		=> AdjustDateBasedOnInput(dateTime, true);

	/// <summary>Translates the current date to the first day of the month.</summary>
	/// <param name="date">Date to convert to first day of the month.</param>
	/// <returns>Last day of a month at midnight.</returns>
	public static DateTime ToFirstDayOfMonth(DateTime date)
		=> new(date.Year, date.Month, 1);

	/// <summary>Translates the current date to the last day of the month.</summary>
	/// <param name="date">Date to convert to last day of the month.</param>
	/// <returns>Last day of a month at midnight.</returns>
	public static DateTime ToLastDayOfMonth(DateTime date)
		=> new(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

	/// <summary>Overwrites <paramref name="source" /> with the time specified.</summary>
	/// <param name="source">The <see cref="DateTime" /> to overwrite.</param>
	/// <param name="time">The <see cref="TimeOnly" /> (time) to set.</param>
	/// <returns>A new <see cref="DateTime" /></returns>
	public static DateTime SetTime(DateTime source, TimeOnly time)
	{
		return new DateTime(
			source.Year,
			source.Month,
			source.Day,
			time.Hour,
			time.Minute,
			time.Second);
	}

}
