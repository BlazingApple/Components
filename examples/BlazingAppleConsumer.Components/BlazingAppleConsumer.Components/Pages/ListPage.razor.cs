using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Lists;

namespace BlazingAppleConsumer.Components.Pages;

/// <summary>Shows various list components.</summary>
public partial class ListPage : ComponentBase
{
	private int _itemCount;
	private List<int>? _items;

	/// <inheritdoc />
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_items = new List<int>();

		for (int i = 0; i < 100; i++)
		{
			_items.Add(i);
		}
	}
}
