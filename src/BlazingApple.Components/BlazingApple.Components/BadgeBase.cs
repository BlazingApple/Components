using BlazingApple.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazingApple.Components;

/// <summary>Base class for Badge components.</summary>
public abstract class BadgeBase : ComponentBase
{
	/// <summary>The string to place inside the badge.</summary>
	protected string BadgeString = null!;

	/// <summary>Whether or not to render the component.</summary>
	protected bool IsLoaded;
	private Colors? _colors;

	/// <summary>Additional styles to apply to the badge.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>Additional CSS classes to apply to the badge. Will not overwrite the classes.</summary>
	[Parameter]
	public string? AdditionalClasses { get; set; }

	/// <summary>The color of the badge to render.</summary>
	[Parameter]
	public dynamic? Color { get; set; }

	/// <summary>
	///     The FontAwesome icon class to use, if any. If passed, this overrides the <see cref="Name" /> text that might otherwise have been used.
	/// </summary>
	[Parameter]
	public string? IconClass { get; set; }

	/// <summary>If true, the badge is rendered as a larger component on the page.</summary>
	[Parameter]
	public bool LargeDisplay { get; set; }

	/// <summary>The name to generate an abbreviated badge for.</summary>
	[Parameter]
	public string Name { get; set; } = null!;

	/// <summary>The tooltip to show when someone hovers over the badge.</summary>
	[Parameter]
	public string? Tooltip { get; set; }

	/// <summary>Defaults to false. If true, instead of generating an abbreviation, the <see cref="Name" /> property is used directly.</summary>
	[Parameter]
	public bool UseFullString { get; set; } = false;

	/// <summary>
	///     By default, we use the badge name to determine the color of the badge. If this is true, the component just selects a color randomly.
	/// </summary>
	[Parameter]
	public bool UseRandomColor { get; set; }

	/// <summary>Gets the badge string.</summary>
	/// <param name="name">The initial name to process.</param>
	/// <param name="useFullString">Whether or not the string has been preprocessed and should not be processed.</param>
	/// <returns></returns>
	public static string GetBadgeString(string name, bool useFullString = false)
	{
		name = Regex.Replace(name, @"[^\w\d\s]", "");

		if (useFullString || IsAllUpper(name))
		{
			if (name.Length > 4)
				name = name[..4];

			return name;
		}
		else
		{
			string badgeString = "";
			List<string> wordList = name.Split(' ').ToList();

			foreach (string word in wordList)
			{
				if (word.Length > 0)
					badgeString += word[0].ToString().ToUpper();
			}

			if (badgeString.Length > 4)
				badgeString = badgeString[..4];

			return badgeString;
		}
	}

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		base.OnParametersSet();
		BadgeString = GetBadgeString(Name, UseFullString);

		SetColorIfNull();
	}

	/// <summary>Set the <see cref="Color" /> member if not set.</summary>
	protected void SetColorIfNull()
	{
		if (Color == null)
		{
			_colors = new Colors();

			if (UseRandomColor)
				Color = _colors.GetRandomThemeColor();
			else
				Color = Card.GetColorForName(_colors, BadgeString);
		}
	}

	private static bool IsAllUpper(string input)
	{
		for (int i = 0; i < input.Length; i++)
		{
			if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
				return false;
		}
		return true;
	}
}
