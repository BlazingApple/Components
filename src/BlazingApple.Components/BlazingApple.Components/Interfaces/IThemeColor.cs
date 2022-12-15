using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Interfaces;

/// <summary>Represents a theme color.</summary>
public interface IThemeColor
{
	/// <summary>The Css class to use for the background of the site (not the site content) but the light site background.</summary>
	public string BackgroundCssClass { get; }

	/// <summary>The hex code for the background color.</summary>
	public string BackgroundHexCode { get; set; }

	/// <summary>The CssClass for the foreground.</summary>
	public string CssClass { get; set; }

	/// <summary>The name of the theme color (e.g. Romance Blue, etc.).</summary>
	public string DisplayName { get; set; }

	/// <summary>Primary foreground color.</summary>
	public string ForegroundHexCode { get; set; }

	/// <summary>The identifier for the record.</summary>
	public string Id { get; set; }

	/// <summary>The name of the color in the code.</summary>
	public string NameInCode { get; }

	/// <summary>The page content background color, aka the almost white color for a theme that other content lays atop.</summary>
	public string PageContentHexCode { get; set; }
}
