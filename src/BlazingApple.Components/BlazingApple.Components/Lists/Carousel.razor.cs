using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Lists;

/// <summary>A lightweight carousel to render different components.</summary>
public sealed partial class Carousel<TItem> : ComponentBase, IDisposable
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

	/// <inheritdoc cref="IDisposable.Dispose" />
	public async void Dispose()
	{
		await JsRuntime.InvokeVoidAsync("disconnectObserver");
	}

	/// <inheritdoc />
	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		await base.OnAfterRenderAsync(firstRender);
		await InitializeScrollSpy();
	}

	private async Task InitializeScrollSpy()
	{
		await JsRuntime.InvokeVoidAsync("registerObserver", ".carouselWindow .slide");
	}

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

	private async Task ItemButtonClickedWrapper(bool increase)
	{
		string activeItem = await JsRuntime.InvokeAsync<string>("getActiveSlideIndex", ".carouselButton.active");
		_activeItem = Convert.ToInt32(activeItem);

		if (increase)
			await ItemButtonClicked(++_activeItem);
		else
			await ItemButtonClicked(--_activeItem);
	}

	private async Task NextButtonClicked() => await ItemButtonClickedWrapper(true);

	private async Task PreviousButtonClicked() => await ItemButtonClickedWrapper(false);
}
