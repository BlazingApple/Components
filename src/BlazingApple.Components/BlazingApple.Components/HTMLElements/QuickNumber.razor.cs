using System.Numerics;

namespace BlazingApple.Components.HTMLElements;

/// <summary>Allows quickly selecting/alternating a number.</summary>
/// <typeparam name="TValue">The type of data bound to this.</typeparam>
public partial class QuickNumber<TValue> : ComponentBase
	where TValue : INumber<TValue>
{
	/// <summary>Any parameter provided to the component that doesn't match a parameter, will be provided here as a dictionary.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>If true, the input field will be hidden.</summary>
	[Parameter]
	public bool ButtonsOnly { get; set; }

	/// <summary>If true, the user will not be able to modify the value.</summary>
	[Parameter]
	public bool Disabled { get; set; }

	/// <summary>The amount by which to increment/decrement by.</summary>
	[Parameter]
	public TValue IncrementBy { get; set; } = TValue.One;

	/// <summary>The max value</summary>
	[Parameter]
	public TValue? MaxValue { get; set; }

	/// <summary>The minimum value.</summary>
	[Parameter]
	public TValue? MinValue { get; set; }

	/// <summary>The unit term for a nonzero instance of the unit (if the value is exactly one).</summary>
	[Parameter]
	public string? PluralUnit { get; set; }

	/// <summary>The unit term for a single instance of the unit (if the value is exactly one).</summary>
	[Parameter]
	public string? SingularUnit { get; set; }

	/// <summary>A reference to the Filter object that a consumer passes in.</summary>
	[Parameter]
	public TValue Value { get; set; } = default!;

	/// <summary>Eventcallback that allows people to bind to the Value parameter passed in.</summary>
	[Parameter]
	public EventCallback<TValue> ValueChanged { get; set; }

	private TValue BoundValue
	{
		get => Value;
		set
		{
			Value = value;
			if (ValueChanged.HasDelegate)
				ValueChanged.InvokeAsync(Value);
		}
	}

	private bool CanPressButton(bool isIncrement)
	{
		if (Disabled)
			return false;

		if (isIncrement && MaxValue is null)
			return true;
		else if (MinValue is null)
			return true;

		TValue val;

		if (isIncrement)
			val = Value + IncrementBy;
		else
			val = Value - IncrementBy;

		if (MinValue is not null && !isIncrement && val.CompareTo(MinValue) < 0)
			return false;
		else if (MaxValue is not null && MaxValue.CompareTo(0) != 0 && isIncrement && val.CompareTo(MaxValue) > 0)
			return false;
		else
			return true;
	}

	private async Task OnQuickSelect(bool isIncrement)
	{
		if (Disabled)
			return;

		if (isIncrement)
			Value += IncrementBy;
		else
			Value -= IncrementBy;

		if (ValueChanged.HasDelegate)
			await ValueChanged.InvokeAsync(Value);
	}
}
