using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.HTMLElements;

/// <summary>An item in <see cref="DropDown{T}"/>.</summary>
/// <typeparam name="T">The type of item.</typeparam>
public partial class DropDownItem<T> : ComponentBase
{
	/// <summary>Used to style the containing div.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>The value this item represents.</summary>
	[Parameter]
	public T Value { get; set; } = default!;

	/// <summary>The content to display in the button</summary>
	[Parameter, EditorRequired]
	public RenderFragment? ChildContent { get; set; }

	/// <summary>The parent filter collection.</summary>
	[CascadingParameter]
	protected DropDown<T> Parent { get; set; } = null!;

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		base.OnInitialized();
		Parent.AddItem(this);
	}

	/// <summary><c>True</c> if the component should be disabled, <c>false</c> otherwise.</summary>
	[Parameter]
	public bool Disabled { get; set; }

	private async Task OnClick()
		=> await Parent.OnValueSelect(Value);
}
