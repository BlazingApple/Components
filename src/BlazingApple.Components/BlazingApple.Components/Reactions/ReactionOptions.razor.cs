using BlazingApple.Components.Shared.Models.Reactions;

namespace BlazingApple.Components.Reactions;

/// <summary>Renders the different types of options.</summary>
public partial class ReactionOptions : ComponentBase
{

	/// <summary>Additional styles to apply to the badge.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	private bool _isLoading;
	/// <summary>The value of the dropdown.</summary>
	[Parameter]
	public ReactionType? Value { get; set; } = default!;

	/// <summary>Used to support bind-Value, invoked on the dropdown being changed.</summary>
	[Parameter]
	public EventCallback<ReactionType?> ValueChanged { get; set; }

	/// <summary>The available reactions to be selected from.</summary>
	[Parameter]
	public IReadOnlyList<ReactionType> Options { get; set; } = Enum.GetValues<ReactionType>();

	/// <summary>
	/// Invoked when one of the Reaction buttons is clicked.
	/// </summary>
	/// <param name="newVal">The new value.</param>
	/// <returns>Async op.</returns>
	public async Task OnValueSelect(ReactionType newVal)
	{
		if (Value == newVal)
			Value = null;
		else
			Value = newVal;

		_isLoading = true;

		if (ValueChanged.HasDelegate)
			await ValueChanged.InvokeAsync(Value);

		_isLoading = false;
		StateHasChanged();
	}
}
