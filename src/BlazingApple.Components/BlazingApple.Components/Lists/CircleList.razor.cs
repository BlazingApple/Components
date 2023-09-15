namespace BlazingApple.Components.Lists;

/// <summary>Render items in a circle.</summary>
/// <typeparam name="TItem">The item being rendered.</typeparam>
public partial class CircleList<TItem> : ComponentBase
{
	private double _tan;

	/// <summary>Items to render</summary>
	[Parameter, EditorRequired]
	public IReadOnlyList<TItem> Items { get; set; } = null!;

	/// <summary>Template to render each <see cref="Items"/></summary>
	[Parameter, EditorRequired]
	public RenderFragment<TItem> RowTemplate { get; set; } = null!;

	/// <summary>The Css/Html compliant format for the item size</summary>
	[Parameter, EditorRequired]
	public string ItemSize { get; set; } = null!;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		int count = Math.Max(Items.Count, 3);
		_tan = Math.Tan(Math.PI / count);
	}
}
