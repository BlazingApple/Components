using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;

namespace BlazingApple.Components.HTMLElements;

/// <summary></summary>
/// <typeparam name="TValue"></typeparam>
public partial class InputRadioOG<TValue> : InputBase<TValue>
{
    /// <summary>Optionally pass this instead of using <see cref="DisplayString" /></summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>Whether or not to disable the radio button.</summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>Required if <see cref="ChildContent" /> is null</summary>
    [Parameter]
    public string? DisplayString { get; set; }

    /// <summary>Custom css classes to apply to the rendered label element</summary>
    [Parameter]
    public string? LabelCssClasses { get; set; }

    /// <summary>The selected value.</summary>
    [Parameter]
    public TValue SelectedValue { get; set; }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        string disabledClass = " disabled";
        if (string.IsNullOrEmpty(DisplayString) && SelectedValue is not null)
        {
            DisplayString = SelectedValue.ToString();
        }
        if (string.IsNullOrEmpty(LabelCssClasses))
        {
            LabelCssClasses = "btn-outline-primary";
        }
        if (Disabled && SelectedValue is not null && !SelectedValue.Equals(Value))
        {
            LabelCssClasses += disabledClass;
        }
    }

    /// <inheritdoc />
    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        bool success = BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out TValue? parsedValue);

        if (success)
        {
            result = parsedValue!;
            validationErrorMessage = null;

            return true;
        }
        else
        {
            result = default;
            validationErrorMessage = $"{FieldIdentifier.FieldName} field isn't valid.";

            return false;
        }
    }

    private string ActiveClass()
    {
        if (SelectedValue.Equals(Value))
            return " active";

        return string.Empty;
    }

    private void OnChange(ChangeEventArgs args)
        => CurrentValueAsString = args.Value.ToString();
}
