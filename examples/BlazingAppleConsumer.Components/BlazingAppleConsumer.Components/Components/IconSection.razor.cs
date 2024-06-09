using BlazingApple.Components;
using BlazingApple.Components.Services;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Components.Components;

/// <summary>Icons</summary>
public partial class IconSection : ComponentBase
{
	public IconData? _iconData = new("fas fa-times", "Cancel", IconType.Cancel);
}
