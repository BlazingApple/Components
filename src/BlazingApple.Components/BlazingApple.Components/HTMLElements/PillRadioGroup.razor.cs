using Microsoft.AspNetCore.Components.Forms;

namespace BlazingApple.Components.HTMLElements;

/// <summary>
/// Renders a radio group in pill form.
/// </summary>
/// <typeparam name="T">The type to bind to.</typeparam>
public partial class PillRadioGroup<T> : InputRadioGroup<T>
{
    private int OptionCount => Options?.Count ?? OptionsByKey?.Count ?? 0;

    private int SelectedIndex => GetIndexOfCurrentValue();

    private string? BoundValue
    {
        get => GetCurrentValueAsString();
        set => SetCurrentValueFromString(value);
    }

    /// <summary>Additional classes to apply to the pill list.</summary>
    [Parameter]
    public string? AdditionalClasses { get; set; }

    /// <summary></summary>
    [Parameter]
    public RenderFragment<T>? TemplatedContent { get; set; }

    /// <summary>The options to render where the dictionary key is a unique value for <typeparamref name="T"/>.</summary>
    [Parameter]
    public IReadOnlyDictionary<string, T>? OptionsByKey { get; set; }

    /// <summary>The options to render where <typeparamref name="T"/>'s <c>ToString</c> renders a unique, keyed, value.</summary>
    [Parameter]
    public IReadOnlyList<T>? Options { get; set; }


    /// <summary>Provide this if you cannot guarantee preserving this component after <see cref="InputBase{TValue}.ValueChanged"/> is invoked.</summary>
    /// <remarks>This allows for the animation to be "preserved".</remarks>
    [Parameter]
    public T? PreviousValue { get; set; }

    /// <inheritdoc />
    protected override void OnInitialized() => base.OnInitialized();

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        Name ??= Guid.NewGuid().ToString();
    }

    /// <inheritdoc/>

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (!EqualityComparer<T?>.Default.Equals(PreviousValue, default))
        {
            PreviousValue = default;
            StateHasChanged();
        }
    }

    private int GetIndexOfCurrentValue()
    {
        T? currentValue;

        // This is pretty hacky. Technically this hack to even get the animation won't work if the previous value was the "first"
        // / default value for a given struct. We could make this work entirely if we boxed to <em>or</em> a struct, but not when it's entirely open.
        // Oh well.

        if (!EqualityComparer<T?>.Default.Equals(PreviousValue, default))
            currentValue = PreviousValue;
        else
            currentValue = CurrentValue;

        if (currentValue is null)
        {
            return 0;
        }
        else
        {
            return Options is not null
                ? Options?.ToList()?.IndexOf(currentValue) ?? 0
                : OptionsByKey?.Keys is not null ? OptionsByKey?.Values.ToList()?.IndexOf(currentValue) ?? 0 : 0;
        }
    }

    private string? GetCurrentValueAsString()
    {
        return Options is not null && Value is not null
            ? Value.ToString()
            : OptionsByKey?.Keys is not null && Value is not null ? OptionsByKey.SingleOrDefault(kvp => kvp.Value!.Equals(Value)).Key : null;
    }

    private void SetCurrentValueFromString(string? value)
    {
        if (Options is not null)
        {
            CurrentValue = Options.Single(o => o?.ToString() == value);
        }
        else if (OptionsByKey?.Keys is not null)
        {
            CurrentValue = value is not null ? OptionsByKey[value] : default;
        }
    }

    private T? GetValueFromString(string? value)
    {
        return Options is not null && value is not null
            ? Options.SingleOrDefault(o => o.Equals(value))
            : OptionsByKey?.Keys is not null && value is not null ? OptionsByKey[value] : default;
    }

    /// <inheritdoc/>
    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out T result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        result = GetValueFromString(value);
        if (result != null)
        {
            validationErrorMessage = null;
            return true;
        }
        else
        {
            validationErrorMessage = "Unable to find matching value";
            return false;
        }
    }
}
