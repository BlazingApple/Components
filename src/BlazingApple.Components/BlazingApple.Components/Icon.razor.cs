using BlazingApple.Components.Services;
using FontAwesomeIcons = Blazorise.Icons.FontAwesome.FontAwesomeIcons;

namespace BlazingApple.Components;

/// <summary>Renders an icon using the FontAwesome library.</summary>
public partial class Icon : ComponentBase
{
	/// <summary>Any additional attributes to apply to the icon, like an id etc.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>Any additional classes to apply to the icon.</summary>
	[Parameter]
	public string? AdditionalClasses { get; set; }

	/// <summary>Used for the icon's title text</summary>
	[Parameter]
	public string? AltText { get; set; }

	/// <summary>
	///     Pass this if you want a custom icon from FontAwesome that's not in the icon list. Can use <see cref="FontAwesomeIcons" /> to source them.
	/// </summary>
	[Parameter]
	public string? CustomIcon { get; set; }

	/// <summary>IconType enumeration requesting a specific</summary>
	[Parameter]
	public IconType I { get; set; }

	/// <summary>Sub icon content</summary>
	[Parameter]
	public RenderFragment? ChildContent { get; set; }


}