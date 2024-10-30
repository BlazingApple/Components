namespace BlazingApple.Components.Alerts;

/// <summary>A full width warning to alert a user that a page is in draft.</summary>
public partial class DraftAlertWarning : ComponentBase
{
	/// <summary>Whether or not the record is in draft.</summary>
	[Parameter, EditorRequired]
	public bool IsDraft { get; set; }

	/// <summary>The type of thing in draft.</summary>
	[Parameter, EditorRequired]
	public string? UnitSingular { get; set; }
}
