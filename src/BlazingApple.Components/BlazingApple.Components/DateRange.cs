namespace BlazingApple.Components;
/// <summary>Date range class, returns true/valid if a date false within the range.</summary>
public sealed class DateRange : IDateRange
{
	/// <summary>The last date of the range.</summary>
	public DateTime EndDate { get; set; }

	/// <summary>The first date of the range.</summary>
	public DateTime StartDate { get; set; }

	/// <summary>Set <see cref="EndDate" /> and also update <see cref="StartDate" /> if necessary</summary>
	/// <param name="value">New <see cref="EndDate" /></param>
	public void SetEndDate(DateTime value)
	{
		EndDate = value;
		if (StartDate > value)
			StartDate = value;
	}

	/// <summary>Set <see cref="StartDate" /> and also update <see cref="EndDate" /> if necessary</summary>
	/// <param name="value">New <see cref="StartDate" /></param>
	public void SetStartDate(DateTime value)
	{
		StartDate = value;
		if (EndDate < value)
			EndDate = value;
	}
}

