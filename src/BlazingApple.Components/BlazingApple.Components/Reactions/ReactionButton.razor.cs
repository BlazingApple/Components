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

	/// <summary>Used to render the number of reactions by <see cref="ReactionType"/></summary>
	[Parameter, EditorRequired]
	public IDictionary<ReactionType, int>? Reactions { get; set; }

	/// <summary>Additional classes to apply to the reaction button.</summary>
	[Parameter]
	public string? AdditionalClasses { get; set; }

	/// <summary>The value shown when there is nothing selected.</summary>
	[Parameter]
	public string DefaultButtonText { get; set; } = ReactionType.Like.ToString();

	/// <summary>Only show the selected reaction's icon once selected.</summary>
	[Parameter]
	public bool ShowIconsOnly { get; set; }

	/// <summary>The available reactions to be selected from.</summary>
	[Parameter]
	public IReadOnlyList<ReactionType> Options { get; set; } = Enum.GetValues<ReactionType>();

	private string ButtonClasses => $"btn btn-link p-0 {AdditionalClasses}";

	/// <inheritdoc/>

	protected override void OnParametersSet() => base.OnParametersSet();

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

	private void OnClickAway() => _showOptions = false;

	/// <summary>Performs the basic logic to update the reactions dictionary.</summary>
	/// <param name="oldValue">The value prior to the new action</param>
	/// <param name="newValue">The new value</param>
	/// <param name="reactions">The reactions dictionary</param>
	public static void UpdateDictionaryWithReactionChange(ReactionType? oldValue, ReactionType? newValue, IDictionary<ReactionType, int> reactions)
	{
		if (reactions is not null)
		{
			if (oldValue.HasValue && reactions.ContainsKey(oldValue.Value))
			{
				reactions[oldValue.Value]--;

				if (reactions[oldValue.Value] <= 0)
					reactions.Remove(oldValue.Value);
			}

			if (newValue.HasValue)
			{
				if (reactions.ContainsKey(newValue.Value))
				{
					reactions[newValue.Value]++;
				}
				else
				{
					reactions.Add(newValue.Value, 1);
				}
			}
		}
	}
}
