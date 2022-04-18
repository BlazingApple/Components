using BlazingApple.Components.Interfaces;
using System;
using System.Text.RegularExpressions;

namespace BlazingApple.Components;

/// <summary>Displays a short color coded string summarizing a concept.</summary>
public partial class Badge : ComponentBase
{
    private string _badgeClass = null!;
    private string _badgeString = null!;
    private string _badgeStyle = null!;

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

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        _badgeString = "";

        Name = Regex.Replace(Name, @"[^\w\d\s]", "");

        if (UseFullString || IsAllUpper(Name))
        {
            _badgeString = Name;
        }
        else
        {
            List<string> wordList = Name.Split(' ').ToList();

            foreach (string word in wordList)
            {
                if (word.Length > 0)
                    _badgeString += word[0].ToString().ToUpper();
            }
        }

        if (_badgeString.Length > 4)
            _badgeString = _badgeString[..4];

        SetColorIfNull();

        _badgeClass = $"og-badge-subtle {Color?.BackgroundCssClass} {Color?.CssClass}";
        _badgeClass += " " + AdditionalClasses;
        if (LargeDisplay)
            _badgeClass += " large";

        _badgeStyle = $"color: {Color?.HexCode}; border: 1px solid {Color?.HexCode};";
        if (_badgeString.Length == 4)
            _badgeStyle += " font-size:.75rem;";
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

    private void SetColorIfNull()
    {
        if (Color == null)
        {
            _colors = new Colors();

            if (UseRandomColor)
                Color = _colors.GetRandomThemeColor();
            else
                Color = Card.GetColorForName(_colors._colors, _badgeString);
        }
    }
}
