namespace BlazingApple.Components.HTMLElements;

/// <summary>Renders a checkbox as a switch.</summary>
/// <remarks>See https://getbootstrap.com/docs/5.0/forms/checks-radios/#switches</remarks>
public partial class InputSwitch : ComponentBase
{
    private readonly Guid _uniqueId = Guid.NewGuid();

    /// <summary>Label for the switch</summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>Display text/title text to show on hover, if any.</summary>
    [Parameter]
    public string? TitleText { get; set; }

    /// <summary>Child content to render, if any.</summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>A reference to the Filter object that a consumer passes in.</summary>
    [Parameter]
    public bool Value { get; set; } = default!;

    /// <summary>Allows binding to the Value parameter.</summary>
    [Parameter]
    public EventCallback<bool> ValueChanged { get; set; }

    private async Task ValueChangedInternal(ChangeEventArgs args)
    {
        Value = (bool)args.Value!;
        if (ValueChanged.HasDelegate)
            await ValueChanged.InvokeAsync(Value);
    }
}
