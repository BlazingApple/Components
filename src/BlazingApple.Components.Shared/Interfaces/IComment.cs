namespace BlazingApple.Components.Shared.Interfaces;

/// <summary>Defines a "comment" that a user can create.</summary>
public interface IComment
{
	/// <summary>The string content of the comment.</summary>
	string Content { get; set; }

	/// <summary>The date the comment was authored.</summary>
	DateTimeOffset DateCreated { get; set; }

	/// <summary>The identifier of the comment.</summary>
	Guid Id { get; set; }

	/// <summary>The author's user identifier.</summary>
	string UserId { get; set; }

	/// <summary>The linked user.</summary>
	IUser? User { get; set; }

	/// <summary>When created</summary>
	DateTime DatabaseCreationTimestamp { get; set; }

	/// <summary>When created, or last updated</summary>
	DateTime DatabaseModificationTimestamp { get; set; }
}
