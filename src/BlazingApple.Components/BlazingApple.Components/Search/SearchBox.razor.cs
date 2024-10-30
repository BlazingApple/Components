namespace BlazingApple.Components.Search;

/// <summary>A search box, for searching.</summary>
public partial class SearchBox : ComponentBase
{
	private string _clearButtonClasses = "ba-clear-search text-muted hidden";
	private bool _displayClearButton;

	// really, this is the previous search term...
	private string? _oldOldSearchTerm;
	private string? _oldSearchTerm;

	/// <summary>Used internally to trigger other event callbacks.</summary>
	public string? BoundValue
	{
		get => Value;
		set
		{
			Value = value;
			ValueChanged.InvokeAsync(value);
			InternalOnSearchChange();
		}
	}

	/// <summary>Whether the input field is disabled.</summary>
	[Parameter]
	public bool Disabled { get; set; }

	/// <summary>Fired when the user's focus leaves or enter is pressed.</summary>
	[Parameter]
	public EventCallback<ChangeEventArgs> OnSearchChange { get; set; }

	/// <summary>The title text for the search field.</summary>
	[Parameter]
	public string? TitleText { get; set; }

	/// <summary>Binds the provided value to the selected value.</summary>
	[Parameter]
	public string? Value { get; set; }

	/// <summary>Used for the two-way binding.</summary>
	[Parameter]
	public EventCallback<string> ValueChanged { get; set; }

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		base.OnInitialized();
		ApplyVisualStateChanges();
	}

	private void ApplyVisualStateChanges()
	{
		_displayClearButton = !string.IsNullOrEmpty(BoundValue);
		if (_displayClearButton)
		{
			_clearButtonClasses = "og-clear-seach text-muted";
		}
		else
		{
			_clearButtonClasses = "og-clear-seach text-muted hidden";
		}
	}

	/// <summary>Business logic delegate to clear the search string.</summary>
	private void Clear()
	{
		BoundValue = "";
	}

	/// <summary>Update whether or not the "x" is shown based on the value.</summary>
	private void InternalOnSearchChange()
	{
		bool isDisabled = BoundValue == _oldSearchTerm;
		_oldOldSearchTerm = _oldSearchTerm;
		if (isDisabled)
		{
			return;
		}

		_displayClearButton = !string.IsNullOrEmpty(BoundValue);
		if (_displayClearButton)
		{
			_clearButtonClasses = "ba-clear-search text-muted";
		}
		else
		{
			_clearButtonClasses = "ba-clear-search text-muted hidden";
		}

		OnSearchChange.InvokeAsync(new ChangeEventArgs() { Value = BoundValue });
		_oldSearchTerm = BoundValue;
	}

	/// <summary>Click handler for clicking the "Clear" button.</summary>
	private void OnClearClick()
	{
		Clear();
	}
}
