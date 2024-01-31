using BlazingApple.Components.Services;

namespace BlazingApple.Components;

/// <summary>A button to copy the text to the clipboard.</summary>
public partial class CopyToClipboard : ComponentBase
{
    private const string _normalButtonClass = "btn btn-light d-flex align-items-center justify-content-center background-color-animate";
    private const string _successButtonClass = "btn btn-success d-flex align-items-center justify-content-center background-color-animate";
    private string _buttonClass = _normalButtonClass;

    /// <summary>Excess attributes.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object> AdditionalAttributes { get; set; } = null!;

    /// <summary>
    ///     By default, the button is displayed without any text. If passed, the button is not rendered with 50% border radius, and text is displayed
    ///     alongside the icon.
    /// </summary>
    [Parameter]
    public string? ButtonDisplayText { get; set; }

    /// <summary>Text color of the button, hex code.</summary>
    [Parameter]
    public string? TextColor { get; set; }

    /// <summary>The default button class(es). If not passed, it uses 'btn btn-light'.</summary>
    [Parameter]
    public string DefaultButtonClass { get; set; } = "btn btn-light";

    /// <summary>The text to copy to the clipboard.</summary>
    [Parameter, EditorRequired]
    public string Text { get; set; } = null!;

    private string ButtonClass => $"{DefaultButtonClass} d-flex align-items-center justify-content-center background-color-animate";

    [Inject]
    private IClipboardService ClipboardService { get; set; } = null!;

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        base.OnInitialized();
        _buttonClass = ButtonClass;
    }

    private async Task OnClick()
    {
        await ClipboardService.CopyToClipboard(Text);
        _buttonClass = _successButtonClass;
        StateHasChanged();

        await Task.Delay(TimeSpan.FromSeconds(.5));
        _buttonClass = ButtonClass;
    }
}
