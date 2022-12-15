using BlazingApple.Components.Interfaces;
using BlazingApple.Components.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components;

/// <summary>Renders a badge alongside a title.</summary>
public partial class BadgeTitle : ComponentBase
{
	private Colors _colors = null!;
	private string _titleStyle = null!;

	/// <summary>The badge string, pass if wanting to override the <see cref="Title" /></summary>
	[Parameter]
	public string BadgeString { get; set; } = null!;

	/// <summary>The color object/</summary>
	[Parameter]
	public IThemeColor Color { get; set; } = null!;

	/// <summary>The title of the badge.</summary>
	[Parameter]
	public string Title { get; set; } = null!;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		SetColorIfNull();
		_titleStyle = "color: " + Color.ForegroundHexCode + ";";

		if (string.IsNullOrEmpty(BadgeString))
			BadgeString = Title;
	}

	[MemberNotNull(nameof(Color))]
	private void SetColorIfNull()
	{
		if (Color == null)
		{
			_colors = new Colors();
			Color = _colors.GetRandomThemeColor();
		}
	}
}
