using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.EmailSafe;

/// <summary>Email safe version with inlined styles of <see cref="Badge" /></summary>
public partial class BadgeEmailSafe : BadgeBase
{
	private const string _badgeSubtleStyle = "flex-shrink: 0; text-align: center; border-radius: 50%; height: 2.5rem; width: 2.5rem; vertical-align: middle; align-items: center; user-select: none; flex-shrink: 0;";
	private string _badgeBackgroundColorStyle = "";
	private string _badgeStyle = null!;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		base.OnParametersSet();
		IsLoaded = false;

		_badgeBackgroundColorStyle = $"background-color: {Color?.PageContentHexCode};";

		_badgeStyle = $"color: {Color?.ForegroundHexCode}; border: 1px solid {Color?.ForegroundHexCode};";
		if (BadgeString.Length == 4)
			_badgeStyle += " font-size:.75rem;";

		_badgeStyle += $"{_badgeBackgroundColorStyle} {_badgeSubtleStyle}";

		IsLoaded = true;
	}
}
