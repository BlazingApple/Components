namespace BlazingApple.Components.Interfaces;

/// <summary>Defines a "comment" that a user can create.</summary>
public interface IComment
{
	/// <summary>The string content of the comment.</summary>
	public string Content { get; set; }

	/// <summary>The date the comment was authored.</summary>
	public DateTimeOffset DateCreated { get; set; }

	/// <summary>The identifier of the comment.</summary>
	public string Id { get; set; }

	/// <summary>The author's user identifier.</summary>
	public string UserId { get; set; }
}
