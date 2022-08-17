using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Lists;

/// <summary>A lightweight carousel to render different components.</summary>
public partial class Carousel<TItem> : ComponentBase
{
    private int _activeItem = 0;

    /// <summary>The component to render the item.</summary>
    [Parameter, EditorRequired]
    public RenderFragment<TItem>? ChildContent { get; set; }

    /// <summary>Required if multiple carousels will be rendered on the same page. Defaults to <c>BlazingAppleCarousel{SlideNumber}</c></summary>
    [Parameter]
    public string ElementId { get; set; } = "BlazingAppleCarousel";

    /// <summary>If true, we don't show the indicator buttons.</summary>
    [Parameter]
    public bool HideIndicatorButtons { get; set; }

    /// <summary>If true, we don't show the previous/next buttons.</summary>
    [Parameter]
    public bool HideNavButtons { get; set; }

    /// <summary>The list of items to render.</summary>
    [Parameter, EditorRequired]
    public IReadOnlyList<TItem>? Items { get; set; }

    [Inject]
    private IJSRuntime JsRuntime { get; set; } = null!;

    private async Task ItemButtonClicked(int itemNumber)
    {
        if (Items is null)
            throw new ArgumentNullException(nameof(Items));

        if (itemNumber < 0)
            itemNumber = Items.Count - 1;

        itemNumber %= Items.Count;
        _activeItem = itemNumber;

        await JsRuntime.InvokeVoidAsync("scrollToCarouselSlide", $"{ElementId}{itemNumber}");
    }

    private async Task NextButtonClicked() => await ItemButtonClicked(++_activeItem);

    private async Task PreviousButtonClicked() => await ItemButtonClicked(--_activeItem);
}
