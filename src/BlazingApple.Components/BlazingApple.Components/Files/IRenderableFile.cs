namespace BlazingApple.Components.Files;

/// <summary>
/// A file that can be displayed to a user.
/// </summary>
public interface IRenderableFile
{
	/// <summary>The name of the file to display to the user.</summary>
	string Name { get; }

	/// <summary>The icon to show alongside the user.</summary>
	string? IconClass { get; }

	/// <summary>The source url to pull the file from.</summary>
	string Url { get; }

	/// <summary>The mimetype of the file.</summary>
	string MimeType { get; }

	/// <summary>Whether the file is selectable</summary>
	bool IsDisabled { get; }
}
