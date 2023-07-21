namespace BlazingApple.Components.Shared.Interfaces;

/// <summary>Used to render a user record throughout our components.</summary>
public interface IUser
{
	/// <summary>
	/// The user's Id
	/// </summary>
	string Id { get; }

	/// <summary>The user's first name</summary>
	string? FirstName { get; }

	/// <summary>The user's full name</summary>
	string? FullName { get; }

	/// <summary>The user's full name</summary>
	string? LastName { get; }

	/// <summary>Url to retrieve the user's image</summary>
	string? ImageUrl { get; }

	/// <summary>The user's username</summary>
	string? UserName { get; }

	/// <summary>The user's email</summary>
	string? Email { get; }
}
