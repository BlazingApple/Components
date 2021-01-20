using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Interfaces
{
	public interface IRecord
	{
		string Id { get; set; }
	}

	public interface IComment
	{
		public string Id { get; set; }
		public string UserId { get; set; }

		public DateTimeOffset DateCreated { get; set; }
		public string Content { get; set; }
	}

	public interface IThemeColor
	{
		public string Id { get; set; }
		public string DisplayName { get; set; }
		public string HexCode { get; set; } /* Includes # hash */
		public string CssClass { get; set; }
		public string NameInCode { get; }
		public string BackgroundHexCode { get; set; }
		public string BackgroundCssClass { get; }
	}

	public class ThemeColor: IThemeColor
	{
		public string Id { get; set; } // todo change back to ID
		public string DisplayName { get; set; }
		public string HexCode { get; set; } /* Includes # hash */
		public string CssClass { get; set; }
		public string NameInCode
		{
			get
			{
				return "theme" + DisplayName;
			}
		} /* Use this in code... */

		public string BackgroundHexCode { get; set; }

		public ThemeColor()
		{

		}

		public ThemeColor(string Id, string DisplayName, string HexCode, string CssClass, string BackgroundHexCode)
		{
			this.Id = Id;
			this.DisplayName = DisplayName;
			this.HexCode = HexCode;
			this.CssClass = CssClass;
			this.BackgroundHexCode = BackgroundHexCode;
		}

		public virtual string BackgroundCssClass
		{
			get
			{
				return CssClass + "-bg";
			}
		}
	}

	public class Colors
	{
		public List<IThemeColor> _colors { get; set; }
		public Colors()
		{
			_colors = new List<IThemeColor>();
			_colors.Add(new ThemeColor("1", "Altitude", "#0091ea", "og-altitude", "#80c8f5"));
			_colors.Add(new ThemeColor("2", "Azure", "#0085f2", "og-azure", "#80c2f9"));
			_colors.Add(new ThemeColor("3", "Blush", "#FF6665", "og-blush", "#ffb3b2"));
			_colors.Add(new ThemeColor("4", "Caribbean", "#00bfd4", "og-caribbean", "#80dfea"));
			_colors.Add(new ThemeColor("5", "Dahlia", "#b429cc", "og-dahlia", "#da94e6"));
			_colors.Add(new ThemeColor("6", "Fuchsia", "#dd299d", "og-fuchsia", "#ee94ce"));
			_colors.Add(new ThemeColor("7", "Golden", "#f4c100", "og-golden", "#fae080"));
			_colors.Add(new ThemeColor("8", "Lime", "#69c300", "og-lime", "#b4e180"));
			_colors.Add(new ThemeColor("9", "Mediterranean", "#19c295", "og-mediterranean", "#8ce1ca"));
			_colors.Add(new ThemeColor("10", "Rose", "#d94e6f", "og-rose", "#eca7b7"));
			_colors.Add(new ThemeColor("11", "Sky", "#24a4ee", "og-sky", "#92d2f7"));
			_colors.Add(new ThemeColor("12", "Tangerine", "#ff9200", "og-tangerine", "#ffc980"));
			_colors.Add(new ThemeColor("13", "Wisteria", "#6a4ce0", "og-wisteria", "#b5a6f0"));
		}
		public IThemeColor GetRandomThemeColor()
		{
			int randomIndex = new Random().Next(_colors.Count - 1);
			return _colors[randomIndex];
		}
	}
}
