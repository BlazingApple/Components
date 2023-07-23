using BlazingApple.Components.Shared.Models.Reactions;

namespace BlazingApple.Components.Reactions;

/// <summary>A button that renders the current reaction and launches the tooltip allowing selection of other reactions.</summary>
public partial class ReactionButton : ComponentBase
{
	private bool _showOptions;

	/// <summary>Additional styles to apply to the badge.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>The value of the dropdown.</summary>
	[Parameter]
	public ReactionType? Value { get; set; } = default!;

	/// <summary>Used to support bind-Value, invoked on the dropdown being changed.</summary>
	[Parameter]
	public EventCallback<ReactionType?> ValueChanged { get; set; }

	/// <summary>The value shown when there is nothing selected.</summary>
	[Parameter]
	public string DefaultButtonText { get; set; } = ReactionType.Like.ToString();
	
	/// <summary>Only show the selected reaction's icon once selected.</summary>
	[Parameter]
	public bool ShowIconsOnly { get; set; }

	/// <summary>
	/// Invoked when one of the Reaction buttons is clicked.
	/// </summary>
	/// <param name="newVal">The new value.</param>
	/// <returns>Async op.</returns>
	public async Task OnValueSelect(ReactionType? newVal)
	{
		_showOptions = false;
		if (Value == newVal)
			Value = null;
		else
			Value = newVal;

		if (ValueChanged.HasDelegate)
			await ValueChanged.InvokeAsync(Value);

		StateHasChanged();
	}

	private void OnMouseIn() => _showOptions = true;
	private void OnMouseOut() => _showOptions = false;
}
