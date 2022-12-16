using BlazingApple.Components.Shared.Interfaces;
using Syncfusion.Blazor.TreeMap.Internal;
using System;
using System.Text.RegularExpressions;

namespace BlazingApple.Components;

/// <summary>Displays a short color coded string summarizing a concept.</summary>
public partial class Badge : BadgeBase
{
	private string _badgeClass = null!;
	private string _badgeStyle = null!;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		base.OnParametersSet();
		IsLoaded = false;

		_badgeClass = $"og-badge-subtle {Color?.BackgroundCssClass} {Color?.CssClass}";
		_badgeClass += " " + AdditionalClasses;
		if (LargeDisplay)
			_badgeClass += " large";

		_badgeStyle = $"color: {Color?.ForegroundHexCode}; border: 1px solid {Color?.ForegroundHexCode};";
		if (BadgeString.Length == 4)
			_badgeStyle += " font-size:.75rem;";

		IsLoaded = true;
	}
}
