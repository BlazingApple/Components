namespace BlazingApple.Components;

/// <summary>Bootstrap styled accordion, vertical layout.</summary>
public partial class VerticalAccordion : ComponentBase
{
	/// <summary>Id in the dom.</summary>
	public Guid Id { get; set; } = Guid.NewGuid();

	/// <summary>The data to render</summary>
	[Parameter]
	public IEnumerable<(string Heading, string Content)>? Items { get; set; }
}
