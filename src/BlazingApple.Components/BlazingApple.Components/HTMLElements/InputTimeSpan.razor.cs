using Syncfusion.Blazor.InPlaceEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazingApple.Components.Shared.Models.Time;

namespace BlazingApple.Components.HTMLElements;

/// <summary>Allows setting a timespan, using only even numbers.</summary>
public partial class InputTimeSpan : ComponentBase
{
	private readonly Guid _uniqueId = Guid.NewGuid();
	private int _countOfSpan;
	private int _maxForSpan;
	private SpanType _spanType;

	/// <summary>Captures/renders standard HTML attributes passed</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object> AdditionalAttributes { get; set; } = null!;

	/// <summary>Label for the switch</summary>
	[Parameter]
	public string? Label { get; set; }

	/// <summary>A reference to the Filter object that a consumer passes in.</summary>
	[Parameter]
	public TimeSpan? Value { get; set; } = default!;

	/// <summary>Allows binding to the Value parameter.</summary>
	[Parameter]
	public EventCallback<TimeSpan?> ValueChanged { get; set; }

	/// <summary>Forces the units of the control.</summary>
	[Parameter]
	public SpanType? Units { get; set; }

	/// <summary>The maximum span.</summary>
	[Parameter]
	public TimeSpan Max { get; set; } = new(365, 0, 0, 0);

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		base.OnInitialized();

		if (Units.HasValue)
		{
			_spanType = Units.Value;
			_maxForSpan = ToCount(_spanType, (int)Math.Floor(Max.TotalDays));
			return;
		}

		if (Max == default)
		{
			_spanType = SpanType.Days;
			_maxForSpan = 30;
		}

		if (Max.TotalDays <= 21)
		{
			_spanType = SpanType.Days;
			_maxForSpan = (int)Math.Floor(Max.TotalDays);
		}
		else if (Max.TotalDays is > 21 and <= 84)
		{
			// 84 days == 12 weeks
			_spanType = SpanType.Weeks;
			_maxForSpan = (int)Math.Floor(Max.TotalDays / 7);
		}
		else if (Max.TotalDays is > 84 and <= 900)
		{
			_spanType = SpanType.Months;
			_maxForSpan = (int)Math.Floor(Max.TotalDays / 30);
		}
		else if (Max.TotalDays > 900)
		{
			_spanType = SpanType.Years;
			_maxForSpan = (int)Math.Floor(Max.TotalDays / 365);
		}
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		base.OnParametersSet();
		if (Value.HasValue)
			_countOfSpan = ToCount(_spanType, (int)Math.Floor(Value.Value.TotalDays));
	}

	private static TimeSpan ToSpan(SpanType spanType, int count)
	{
		TimeSpan span = spanType switch
		{
			SpanType.Days => new TimeSpan(count, 0, 0, 0),
			SpanType.Weeks => new TimeSpan(count * 7, 0, 0, 0),
			SpanType.Months => new TimeSpan(count * 30, 0, 0, 0),
			SpanType.Years => new TimeSpan(count * 365, 0, 0, 0),
			_ => throw new ArgumentOutOfRangeException(nameof(spanType)),
		};
		return span;
	}

	private static int ToCount(SpanType spanType, int maxInDays)
	{
		int countForSpan = spanType switch
		{
			SpanType.Days => maxInDays,
			SpanType.Weeks => maxInDays / 7,
			SpanType.Months => maxInDays / 30,
			SpanType.Years => maxInDays / 365,
			_ => throw new ArgumentOutOfRangeException(nameof(spanType)),
		};
		return countForSpan;
	}

	private static int ToCountInDays(SpanType spanType, int countInSpan)
	{
		int countInDays = spanType switch
		{
			SpanType.Days => countInSpan,
			SpanType.Weeks => countInSpan * 7,
			SpanType.Months => countInSpan * 30,
			SpanType.Years => countInSpan * 365,
			_ => throw new ArgumentOutOfRangeException(nameof(spanType)),
		};
		return countInDays;
	}

	private static int ToCount(SpanType oldSpan, int countInOldSpan, SpanType newSpan)
	{
		int countInDays = ToCountInDays(oldSpan, countInOldSpan);
		return ToCount(newSpan, countInDays);
	}

	private async Task UpdateValue()
	{
		Value = ToSpan(_spanType, _countOfSpan);
		await ValueChangedInternal();
	}

	private async Task ValueChangedInternal()
	{
		if (ValueChanged.HasDelegate)
			await ValueChanged.InvokeAsync(Value);
	}

	private async Task CountChanged(int count)
	{
		_countOfSpan = count;
		await UpdateValue();
	}

	private async Task SpanTypeChanged(SpanType spanType)
	{
		_countOfSpan = ToCount(_spanType, _countOfSpan, spanType);
		_spanType = spanType;

		_maxForSpan = ToCount(_spanType, Convert.ToInt16(Math.Floor(Max.TotalDays)));

		await UpdateValue();
	}
}
