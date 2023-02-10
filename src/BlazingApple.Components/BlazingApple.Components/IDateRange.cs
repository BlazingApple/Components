namespace BlazingApple.Components;

/// <summary>Interface defining what it means to be a date range.</summary>
public interface IDateRange
{
	/// <summary>Last date of the range.</summary>
	DateTime EndDate { get; set; }

	/// <summary>First date of the range.</summary>
	DateTime StartDate { get; set; }
}
