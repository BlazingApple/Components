using Microsoft.AspNetCore.Components;
using System.ComponentModel;

namespace BlazingAppleConsumer.Components.Components;

/// <summary>Section of buttons.</summary>
public partial class ButtonSection : ComponentBase
{
	private bool _toggleButton = true;

	private ListSortDirection _sortDirection;
}
