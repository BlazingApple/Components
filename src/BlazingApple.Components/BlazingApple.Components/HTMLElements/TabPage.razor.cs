using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.HTMLElements;

/// <summary>A single page rendered in a tab within a <see cref="TabStrip" /></summary>
public partial class TabPage : ComponentBase
{
    /// <summary>The content to render within the page.</summary>
    [Parameter, EditorRequired]
    public RenderFragment ChildContent { get; set; } = null!;

    /// <summary>The title of the tab page.</summary>
    [Parameter, EditorRequired]
    public string Title { get; set; } = null!;

    /// <summary>The <see cref="TabStrip" /> parent.</summary>
    [CascadingParameter]
    private TabStrip Parent { get; set; } = null!;

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        if (Parent == null)
        {
            throw new ArgumentNullException(nameof(Parent), "TabPage must exist within a TabControl");
        }
        base.OnInitialized();
        Parent.AddPage(this);
    }

    private string ClassIfIsHidden()
    {
        if (Parent.ActivePage == this)
            return string.Empty;
        else
            return "hidden";
    }
}
