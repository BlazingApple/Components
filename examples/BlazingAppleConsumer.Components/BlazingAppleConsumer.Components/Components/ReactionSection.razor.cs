using BlazingApple.Components.Reactions;
using BlazingApple.Components.Shared.Models.Reactions;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Components.Components;

/// <summary>Reactions</summary>
public partial class ReactionSection : ComponentBase
{
	private IDictionary<ReactionType, int>? _reactions;
	private ReactionType? _oldReaction;
	public ReactionType? SelectedReaction { get; set; }
	public ReactionType? SelectedReaction2
	{
		get => SelectedReaction;
		set
		{
			_oldReaction = SelectedReaction;
			SelectedReaction = value;

			if (_reactions is not null)
				ReactionButton.UpdateDictionaryWithReactionChange(_oldReaction, value, _reactions);
		}
	}

	/// <inheritdoc />
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		_reactions = new Dictionary<ReactionType, int>()
		{
			{ ReactionType.Like, Random.Shared.Next(0, 20) },
			{ ReactionType.Love, Random.Shared.Next(0, 20) },
			{ ReactionType.Laugh, Random.Shared.Next(0, 5) },
			{ ReactionType.Anger, Random.Shared.Next(0, 2) },
			{ ReactionType.Shock, Random.Shared.Next(0, 2) },
			{ ReactionType.Sad, Random.Shared.Next(0, 2) }
		};
	}
}
