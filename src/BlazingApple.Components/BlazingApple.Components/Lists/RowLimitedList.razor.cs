namespace BlazingApple.Components.Lists;

/// <summary>Renders a list, but limited in numbers.</summary>
/// <typeparam name="TItem">Type of item to render.</typeparam>
public partial class RowLimitedList<TItem> : RecordList<TItem>
{
	private bool _seeMoreSelected;
	private IReadOnlyList<TItem>? _itemsToDisplay;

	/// <summary>Number of rows to show by default</summary>
	[Parameter]
	public int RowLimit { get; set; } = 5;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		base.OnInitialized();
		FormatAsList = true;
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		base.OnParametersSet();
		PopulateList();
	}

	private void SeeMoreClicked(bool newValue)
	{
		_seeMoreSelected = newValue;

		PopulateList();
	}

	private void PopulateList()
	{
		if (_seeMoreSelected)
		{
			_itemsToDisplay = Items;
		}
		else
		{
			_itemsToDisplay = Items.Count > RowLimit ? Items.Take(RowLimit).ToList() : Items;
		}
	}
}

