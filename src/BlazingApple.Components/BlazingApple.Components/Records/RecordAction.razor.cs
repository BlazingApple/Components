using BlazingApple.Components.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Records;

/// <summary>Links for doing actions to a record (CRUD actions).</summary>
public partial class RecordAction : ComponentBase
{
	private readonly string vertBar = "|";
	private string _detailsRoute = null!;
	private string _editRoute = null!;
	private string _idForRoute = null!;

	/// <summary>Additional styles to apply to each action.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>If true, the links will be shown as disabled.</summary>
	[Parameter]
	public bool Disabled { get; set; }

	/// <summary>If passed, this will show content on the disabled link.</summary>
	[Parameter]
	public string? DisabledTooltip { get; set; }

	/// <summary>
	///     If this is set to true, then the edit button will always be an icon. If it is not set or set to false the edit button is not guaranteed to
	///     be text, it could still be an icon, based on the default styles.
	/// </summary>
	[Parameter]
	public bool DisplayEditAsIcon { get; set; }

	/// <summary>Hides the edit button.</summary>
	[Parameter]
	public bool HideEditButton { get; set; }

	/// <summary>Describes what action to take upon clicking the delete link.</summary>
	[Parameter]
	public EventCallback<string> OnDeleteClick { get; set; }

	/// <summary>If true, we don't show the details button, since the action links are already displayed here.</summary>
	[Parameter]
	public bool OnDetailsPage { get; set; }

	/// <summary>The action to take upon clicking the edit button.</summary>
	[Parameter]
	public EventCallback<string> OnEditClick { get; set; }

	/// <summary>True if on the edit page, will hide the edit button.</summary>
	[Parameter]
	public bool OnEditPage { get; set; }

	/// <summary>The record to render links/actions for.</summary>
	[Parameter]
	public IRecord Record { get; set; } = null!;

	/// <summary>The route for the record.</summary>
	[Parameter]
	public string Route { get; set; } = null!;

	/// <summary>If true, uses a vertical bar to space the buttons from one another.</summary>
	[Parameter]
	public bool ShowSpacer { get; set; }

	/// <summary>If record is not populated, we use this as the route Identifier.</summary>
	[Parameter]
	public string Slug { get; set; } = null!;

	private string AdditionalClassNames => (AdditionalAttributes?.ContainsKey("class") ?? false) ? (string)AdditionalAttributes["class"] : "";

	private string LinkClassNames => Disabled ? $"btn btn-link disabled p-0" : AdditionalClassNames;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		if (Record != null)
			_idForRoute = Record.Id.ToString()!;
		else
			_idForRoute = Slug;

		_editRoute = $"{Route}/edit/{_idForRoute}";
		_detailsRoute = $"{Route}/{_idForRoute}";
	}

	private void _OnDeleteClick()
	{
		if (OnDeleteClick.HasDelegate && !Disabled)
			OnDeleteClick.InvokeAsync(_idForRoute);
	}

	private void _OnEditClick()
	{
		if (OnEditClick.HasDelegate && !Disabled)
			OnEditClick.InvokeAsync(_idForRoute);
	}
}
