namespace BlazingApple.Components.Lists;

/// <summary>A list of items that can be clicked.</summary>
/// <typeparam name="TItem">The type of item.</typeparam>
public partial class ClickableList<TItem> : RecordList<TItem>
	where TItem : class
{
	private TItem? _selectedItem;

	/// <summary>The item that was clicked.</summary>
	[Parameter]
	public EventCallback<TItem> ItemClicked { get; set; }

	/// <summary>Reset the selected item.</summary>
	public void ResetSelectedItem()
	{
		_selectedItem = null;
	}

	private async Task OnItemClicked(TItem item)
	{
		_selectedItem = item;

		if (ItemClicked.HasDelegate)
		{
			await ItemClicked.InvokeAsync(_selectedItem);
		}
	}
}

