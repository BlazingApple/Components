using BlazingApple.Components.Shared.Models.Reactions;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Components.Components;

/// <summary>Reactions</summary>
public partial class ReactionSection : ComponentBase
{
	public ReactionType? SelectedReaction { get; set; }
	public ReactionType? SelectedReaction2 { get; set; }
}
