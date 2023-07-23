using System.ComponentModel.DataAnnotations;

namespace BlazingApple.Components.Shared.Models.Reactions;

/// <summary>The type of reaction ("laugh", "thumbs up", down, heart, etc.).</summary>
public enum ReactionType
{
	/// <summary>Indicates the user likes the content.</summary>
	[Display(Name = "👍")]
	Like,
	/// <summary>Indicates the user dislikes the content.</summary>
	[Display(Name = "👎")]
	Dislike,

	/// <summary>Indicates the user loves the content.</summary>
	[Display(Name = "❤️")]
	Love,

	/// <summary>Indicates the user finds the content funny.</summary>
	[Display(Name = "😂")]
	Laugh,

	/// <summary>Indicates the user is shocked at the content.</summary>
	[Display(Name = "😮")]
	Shock,

	/// <summary>Indicates the user is saddened by the content.</summary>
	[Display(Name = "😥")]
	Sad,

	/// <summary>Indicates the user angered by the content.</summary>
	[Display(Name = "😡")]
	Anger
}
