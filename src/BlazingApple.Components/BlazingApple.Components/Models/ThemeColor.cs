using BlazingApple.Components.Interfaces;

namespace BlazingApple.Components.Models;

/// <summary>Represents a theme color for the site.</summary>
public partial class ThemeColor : IThemeColor
{
	/// <inheritdoc />
	public virtual string BackgroundCssClass
	{
		get
		{
			return CssClass + "-bg";
		}
	}

	/// <inheritdoc />
	public string BackgroundHexCode { get; set; } = null!;

	/// <inheritdoc />
	public string CssClass { get; set; } = null!;

	/// <inheritdoc />
	public string DisplayName { get; set; } = null!;

	/// <inheritdoc />
	public string ForegroundHexCode { get; set; } = null!;

	/// <inheritdoc />
	public string Id { get; set; } = null!;

	/// <summary>The name in code for the color.</summary>
	public string NameInCode
	{
		get
		{
			return "theme" + DisplayName;
		}
	}

	/// <summary>The background content slightly offwhite color.</summary>
	public string PageContentHexCode { get; set; } = null!;

	/// <summary>DI Constructor.</summary>
	public ThemeColor()
	{
	}

	/// <summary>Parameterized constructor.</summary>
	public ThemeColor(string Id, string DisplayName, string ForegroundHexCode, string CssClass, string BackgroundHexCode, string PageContentHexCode)
	{
		this.Id = Id;
		this.DisplayName = DisplayName;
		this.ForegroundHexCode = ForegroundHexCode;
		this.CssClass = CssClass;
		this.BackgroundHexCode = BackgroundHexCode;
		this.PageContentHexCode = PageContentHexCode;
	}
}
