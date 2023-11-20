namespace BlazingApple.Components.Accordion;

/// <summary>Accordion section</summary>
public partial class AccordionSection : ComponentBase
{
	private bool _isVisible;
	private readonly Guid id = Guid.NewGuid();

	/// <summary>Accordion parent.</summary>
	[CascadingParameter]
	[Parameter]
	public VerticalAccordion? Parent { get; set; }

	/// <summary>Data to pass to the accordion section.</summary>
	[Parameter]
	public (string Heading, string Content)? Data { get; set; }
}
