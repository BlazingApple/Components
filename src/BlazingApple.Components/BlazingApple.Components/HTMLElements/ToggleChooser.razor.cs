namespace BlazingApple.Components.HTMLElements;

/// <summary>Allows multiple selection of <typeparamref name="T"/></summary>
/// <typeparam name="T">The type of item.</typeparam>
public partial class ToggleChooser<T>
{
	private HashSet<T> _selected = [];

	/// <summary>Shown within the toggle button.</summary>
	[Parameter, EditorRequired]
	public RenderFragment<T> ResultTemplate { get; set; } = null!;

	/// <summary>Whether or not the component is disabled.</summary>
	[Parameter]
	public bool Disabled { get; set; }

	/// <summary>Displays attributes provided to the component via consumer.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>The items to choose from.</summary>
	[Parameter]
	public IReadOnlyList<T>? Items { get; set; }

	/// <summary>This is called when the selected value is changed.</summary>
	[Parameter]
	public EventCallback<List<T>> OnChange { get; set; }

	/// <summary>Binds the provided value to the selected value.</summary>
	[Parameter]
	public List<T>? Value { get; set; }

	/// <summary>Used for the two-way binding.</summary>
	[Parameter]
	public EventCallback<List<T>> ValueChanged { get; set; }

	/// <summary>Whether or not to provide a select all button.</summary>
	[Parameter]
	public bool ShowSelectAll { get; set; }

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		if (Value != null)
			_selected = Value.ToHashSet();
	}

	/// <summary>
	/// Fired when an item is toggled.
	/// </summary>
	/// <param name="item">Item that was clicked.</param>
	/// <returns>ASync op.</returns>
	protected async Task OnItemClicked(T item)
	{
		Value ??= [];

		if (!_selected.Remove(item))
		{
			_selected.Add(item);
			Value.Add(item);
		}
		else
		{
			Value.Remove(item);
		}

		await NotifyChanges();
	}

	private async Task NotifyChanges()
	{
		await ValueChanged.InvokeAsync(Value);

		if (OnChange.HasDelegate)
			await OnChange.InvokeAsync(Value);
	}

	private async Task SelectAllClicked()
	{
		if (Items is null)
			return;

		if (_selected.Count == 0)
		{
			foreach (T? item in Items)
				_selected.Add(item);
			Value ??= [];
			Value.AddRange(Items);
		}
		else
		{
			_selected.Clear();

			Value?.Clear();
		}

		await NotifyChanges();
	}
}
