namespace BlazingApple.Components.Icons;

/// <summary>Info icon with nice tooltip.</summary>
public partial class InfoIcon : ComponentBase
{
    private readonly Guid _id = Guid.NewGuid();

    /// <summary>The tooltip content</summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
