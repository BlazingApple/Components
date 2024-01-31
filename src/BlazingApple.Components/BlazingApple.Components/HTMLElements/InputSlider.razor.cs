using System.Numerics;

namespace BlazingApple.Components.HTMLElements;

/// <summary>Slider control.</summary>
/// <typeparam name="TNumber">A type of number</typeparam>
public partial class InputSlider<TNumber> : ComponentBase
    where TNumber : INumber<TNumber>
{
    private readonly Guid _uniqueId = Guid.NewGuid();

    /// <summary>Captures/renders standard HTML attributes passed</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object> AdditionalAttributes { get; set; } = null!;

    /// <summary>Label for the switch</summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>Whether or not to show the current value.</summary>
    [Parameter]
    public bool ShowCurrentValue { get; set; } = true;

    /// <summary>Display text/title text to show on hover, if any.</summary>
    [Parameter]
    public string? TitleText { get; set; }

    /// <summary>Child content to render, if any.</summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>A reference to the Filter object that a consumer passes in.</summary>
    [Parameter]
    public TNumber Value { get; set; } = default!;

    /// <summary>Min value of the range.</summary>
    [Parameter]
    public TNumber? Min { get; set; }

    /// <summary>Max value of the range.</summary>
    [Parameter]
    public TNumber? Max { get; set; }

    /// <summary>Step of the range slider.</summary>
    [Parameter]
    public TNumber Step { get; set; } = TNumber.One;

    /// <summary>Allows binding to the Value parameter.</summary>
    [Parameter]
    public EventCallback<TNumber> ValueChanged { get; set; }

    private async Task ValueChangedInternal(ChangeEventArgs args)
    {
        Value = TNumber.Parse(args.Value!.ToString()!, System.Globalization.NumberStyles.Number, null);
        if (ValueChanged.HasDelegate)
            await ValueChanged.InvokeAsync(Value);
    }
}
