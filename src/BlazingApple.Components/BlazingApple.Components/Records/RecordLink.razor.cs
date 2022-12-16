using BlazingApple.Components.Shared.Interfaces;

namespace BlazingApple.Components.Records;

/// <summary>A link to various records.</summary>
public partial class RecordLink : ComponentBase
{
	private string _detailsRoute = null!;

	/// <summary>The name or any content we want in the link</summary>
	[Parameter, EditorRequired]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>The record to link to.</summary>
	[Parameter]
	public IRecord? Record { get; set; }

	/// <summary>Required if <see cref="Record" /> is not provided.</summary>
	[Parameter]
	public string? Route { get; set; }

	/// <summary>Required if <see cref="Record" /> is not provided.</summary>
	[Parameter]
	public string? Slug { get; set; }

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		string idForRoute;

		if (Record != null)
			idForRoute = Record.Id.ToString();
		else
			idForRoute = Slug!;

		_detailsRoute = $"{Route}/{idForRoute}";
	}
}
