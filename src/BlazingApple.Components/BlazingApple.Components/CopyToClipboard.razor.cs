using BlazingApple.Components.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components;

/// <summary>A button to copy the text to the clipboard.</summary>
public partial class CopyToClipboard : ComponentBase
{
    private const string _normalButtonClass = "btn btn-light";
    private const string _successButtonClass = "btn btn-success";
    private string _buttonClass = "btn btn-light";

    /// <summary>Excess attributes.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object> AdditionalAttributes { get; set; } = null!;

    /// <summary>The text to copy to the clipboard.</summary>
    [Parameter, EditorRequired]
    public string Text { get; set; } = null!;

    [Inject]
    private IClipboardService ClipboardService { get; set; } = null!;

    private async Task OnClick()
    {
        await ClipboardService.CopyToClipboard(Text);
        _buttonClass = _successButtonClass;
        StateHasChanged();

        await Task.Delay(TimeSpan.FromSeconds(.5));
        _buttonClass = _normalButtonClass;
    }
}
