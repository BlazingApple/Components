using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.HTMLElements;

/// <summary>Renders a list of <see cref="TabPage" /></summary>
public partial class TabStrip : ComponentBase
{
    /// <summary>The active page</summary>
    public TabPage ActivePage { get; set; } = null!;

    /// <summary>Next line is needed so we are able to add <see cref="TabPage" /> components inside</summary>
    [Parameter]
    public RenderFragment ChildContent { get; set; } = null!;

    /// <summary>If true, we render the non-visible pages.</summary>
    [Parameter]
    public bool Prerender { get; set; } = false;

    private List<TabPage> Pages { get; set; } = null!;

    internal void AddPage(TabPage tabPage)
    {
        Pages.Add(tabPage);
        if (Pages.Count == 1)
            ActivePage = tabPage;
        StateHasChanged();
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Pages = new List<TabPage>();
    }

    private void ActivatePage(TabPage page)
    {
        ActivePage = page;
    }

    private string GetButtonClass(TabPage page)
    {
        return page == ActivePage ? "active og-color-primary" : "";
    }
}
