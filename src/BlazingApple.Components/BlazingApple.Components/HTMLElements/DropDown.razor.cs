namespace BlazingApple.Components.HTMLElements;


/// <summary>A drop down selection component</summary>
/// <typeparam name="T">The values composed within the dropdown.</typeparam>
public partial class DropDown<T> : ComponentBase
{
	/// <summary>Used to style the containing div.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	private bool _isOpen;

	/// <summary><c>True</c> if the component should be disabled, <c>false</c> otherwise.</summary>
	[Parameter]
	public bool Disabled { get; set; }

	/// <summary>Label/title for the component.</summary>
	[Parameter]
	public string? Label { get; set; }

	/// <summary>Bootstrap button class, like <c>btn-outline-secondary</c> or <c>btn-primary btn-sm</c>.</summary>
	[Parameter]
	public string? ButtonClass { get; set; } = "btn-light";

	/// <summary>Child content to render into the dropdown.</summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>The value of the dropdown.</summary>
	[Parameter]
	public T Value { get; set; } = default!;

	/// <summary>Used to support bind-Value, invoked on the dropdown being changed.</summary>
	[Parameter]
	public EventCallback<T> ValueChanged { get; set; }

	private List<DropDownItem<T>>? Items { get; set; }

	/// <summary>To be called by children.</summary>
	/// <param name="item">The component to add</param>
	public void AddItem(DropDownItem<T> item)
	{
		Items ??= [];

		if (!Items!.Contains(item))
		{
			Items!.Add(item);
		}
	}

	/// <inheritdoc />
	protected override void OnAfterRender(bool firstRender)
	{
		base.OnAfterRender(firstRender);

		if (firstRender)
		{
			_isOpen = true;
			StateHasChanged();
			_isOpen = false;
			StateHasChanged();
		}
	}

	/// <summary>
	/// Called when a <see cref="DropDownItem{T}"/> is clicked.
	/// </summary>
	/// <param name="newVal">The new value.</param>
	/// <returns>Async op.</returns>
	public async Task OnValueSelect(T newVal)
	{
		Value = newVal;
		_isOpen = false;

		if (ValueChanged.HasDelegate)
		{
			await ValueChanged.InvokeAsync(newVal);
		}

		StateHasChanged();
	}

	private void ToggleOpen()
	{
		_isOpen = !_isOpen;
	}
}
