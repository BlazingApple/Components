namespace BlazingApple.Components.Interfaces
{
	/// <summary>Defines a "comment" that a user can create.</summary>
	public interface IComment
	{
		/// <summary>The string content of the comment.</summary>
		public string Content { get; set; }

		/// <summary>The date the comment was authored.</summary>
		public DateTimeOffset DateCreated { get; set; }

		/// <summary>The identifier of the comment.</summary>
		public string Id { get; set; }

		/// <summary>The author's user identifier.</summary>
		public string UserId { get; set; }
	}

	/// <summary>Ids are required for records.</summary>
	public interface IRecord
	{
		/// <summary>The record's Identifier.</summary>
		string Id { get; set; }
	}

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

	/// <summary>A collection of <see cref="IThemeColor" /></summary>
	public class Colors : List<IThemeColor>
	{
		/// <summary>Initialized the colors.</summary>
		public Colors() : base()
		{
			AddRange(new List<IThemeColor>
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

	/// <summary>Represents a theme color for the site.</summary>
	public class ThemeColor : IThemeColor
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
}
