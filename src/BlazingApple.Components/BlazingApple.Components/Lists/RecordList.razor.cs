namespace BlazingApple.Components.Lists;

/// <summary>A list of items to render.</summary>
/// <typeparam name="TItem">The type of model to render.</typeparam>
public partial class RecordList<TItem> : ComponentBase
{
	private string? _colWidthClass;
	private List<List<TItem>>? _rowItems;
	private bool awaitingLoadMoreResponse;

	/// <summary>The extra attributes to show on a page.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>Tbe column grouping to use, if any.</summary>
	[Parameter]
	public RenderFragment? ColGroup { get; set; }

	/// <summary>This represents the number of columns in each row of list items. The default is 1. Allowed values are 2, 3, or 4.</summary>
	[Parameter]
	public int ColumnsPerRow { get; set; } = 1;

	/// <summary>
	///     If this is set to true, rather than a table, an unordered list element will be used. If this is set to true, HeadRow is rendered as is,
	///     not as a <thead></thead> element.
	/// </summary>
	[Parameter]
	public bool FormatAsList { get; set; }

	/// <summary>The render fragment that displays the table heading columns.</summary>
	[Parameter]
	public RenderFragment? HeadRow { get; set; }

	/// <summary>The item models to render.</summary>
	[Parameter, EditorRequired]
	public IReadOnlyList<TItem> Items { get; set; } = null!;

	/// <summary>Used to provide a more data to the row.</summary>
	[Parameter]
	public EventCallback LoadMoreCallback { get; set; }

	/// <summary>A css-compliant string value for the attribute 'max-height'. None, if not supplied.</summary>
	[Parameter]
	public string? MaxHeight { get; set; }

	/// <summary>The remplate for each row.</summary>
	[Parameter, EditorRequired]
	public RenderFragment<TItem> RowTemplate { get; set; } = null!;

	private string RootDivStyles => string.IsNullOrEmpty(MaxHeight) ? "" : $"max-height: {MaxHeight}; overflow: auto; overflow-x: hidden;";

	private bool ShouldVirtualize => Items?.Count > 1000;

	internal static List<List<TItem>> ToGrid(IReadOnlyList<TItem> items, int columns = 2)
	{
		int rows = items.Count / columns + (items.Count % columns != 0 ? 1 : 0);
		List<List<TItem>> gridRows = new();

		IEnumerator<TItem> itemEnumerator = items.GetEnumerator();
		itemEnumerator.Reset();
		for (int rowIndex = 0; rowIndex < rows; rowIndex++)
		{
			List<TItem> itemsForRow = new();
			for (int colIndex = 0; colIndex < columns; colIndex++)
			{
				bool successfulAdvance = itemEnumerator.MoveNext();
				if (!successfulAdvance)
					break;
				itemsForRow.Add(itemEnumerator.Current);
			}

			gridRows.Add(itemsForRow);
		}

		return gridRows;
	}

	/// <inheritdoc />
	protected override async Task OnParametersSetAsync()
	{
		await base.OnParametersSetAsync();
		if (ColumnsPerRow < 1 || ColumnsPerRow > 4)
		{
			throw new ArgumentOutOfRangeException(nameof(ColumnsPerRow), "Number of columns must be between 1 and 4");
		}
		else if (ColumnsPerRow != 1)
		{
			_colWidthClass = $"col-md-{12 / ColumnsPerRow} d-flex align-items-center justify-content-center";

			_rowItems = ToGrid(Items, ColumnsPerRow);
		}
	}

	private async void OnLoadMoreClicked()
	{
		awaitingLoadMoreResponse = true;
		await LoadMoreCallback.InvokeAsync();
		awaitingLoadMoreResponse = false;
		StateHasChanged();
	}
}
