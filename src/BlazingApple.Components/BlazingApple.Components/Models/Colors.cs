using BlazingApple.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Models;

/// <summary>A collection of <see cref="IThemeColor" /></summary>
public partial class Colors : List<IThemeColor>
{
	/// <summary>Initialized the colors.</summary>
	public Colors() : base()
	{
		AddRange(
		new List<IThemeColor>
		{
			new ThemeColor("1", "Altitude", "#0091ea", "og-altitude", "#80c8f5", "#f2fafe"),
			new ThemeColor("2", "Azure", "#0085f2", "og-azure", "#80c2f9", "#e6f3fe"),
			new ThemeColor("3", "Blush", "#FF6665", "og-blush", "#ffb3b2", "#fff7f7"),
			new ThemeColor("4", "Caribbean", "#00bfd4", "og-caribbean", "#80dfea", "#f2fcfd"),
			new ThemeColor("5", "Dahlia", "#b429cc", "og-dahlia", "#da94e6", "#fbf4fd"),
			new ThemeColor("6", "Fuchsia", "#dd299d", "og-fuchsia", "#ee94ce", "#fdf4fa"),
			new ThemeColor("7", "Golden", "#f4c100", "og-golden", "#fae080", "#fffcf2"),
			new ThemeColor("8", "Lime", "#69c300", "og-lime", "#b4e180", "#f8fcf2"),
			new ThemeColor("9", "Mediterranean", "#19c295", "og-mediterranean", "#8ce1ca", "#f4fcfa"),
			new ThemeColor("10", "Rose", "#d94e6f", "og-rose", "#eca7b7", "#fdf6f8"),
			new ThemeColor("11", "Sky", "#24a4ee", "og-sky", "#92d2f7", "#f4fbfe"),
			new ThemeColor("12", "Tangerine", "#ff9200", "og-tangerine", "#ffc980", "#fffaf2"),
			new ThemeColor("13", "Wisteria", "#6a4ce0", "og-wisteria", "#b5a6f0", "#f8f6fe")
		});
	}

	/// <summary>Gets a color within the range.</summary>
	/// <returns></returns>
	public IThemeColor GetRandomThemeColor()
	{
		int randomIndex = new Random().Next(Count - 1);
		return this[randomIndex];
	}
}
