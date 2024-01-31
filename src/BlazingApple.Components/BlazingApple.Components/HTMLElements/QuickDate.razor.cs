using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.HTMLElements;

/// <summary>Allows for quick date selection, like tomorrow, next week, etc.</summary>
/// <typeparam name="TValue">Supported types are <see cref="DateTime" /> and <c>DateTime?</c></typeparam>
public partial class QuickDate<TValue> : ComponentBase
{
    /// <summary>Any parameter provided to the component that doesn't match a parameter, will be provided here as a dictionary.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>A reference to the Filter object that a consumer passes in.</summary>
    [Parameter]
    public TValue? Value { get; set; }

    /// <summary><see cref="EventCallback" /> that allows binding to <see cref="Value" />.</summary>
    [Parameter]
    public EventCallback<TValue> ValueChanged { get; set; }

    /// <summary>Used internally to trigger other event callbacks.</summary>
    private TValue? BoundValue
    {
        get => Value;
        set
        {
            Value = value;
            ValueChanged.InvokeAsync(Value);
        }
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        Type type = typeof(TValue);
        if (type != typeof(DateTime?) && type != typeof(DateTime))
            throw new ArgumentOutOfRangeException(nameof(TValue), $"Unsupported type passed to QuickDate, received {typeof(TValue)}");
    }

    private async Task OnQuickDateSelect(int daysFromNow)
    {
        Value = (TValue)(object)DateTime.Now.AddDays(daysFromNow);

        if (ValueChanged.HasDelegate)
            await ValueChanged.InvokeAsync(Value);
    }
}
