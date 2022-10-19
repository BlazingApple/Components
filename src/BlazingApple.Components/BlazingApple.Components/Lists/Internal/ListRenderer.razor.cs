namespace BlazingApple.Components.Lists.Internal;

/// <summary>Handles virtually rendering or actually rendering list items.</summary>
/// <typeparam name="TItem">The type of item being rendered.</typeparam>
public partial class ListRenderer<TItem> : ComponentBase
{
    /// <summary>The items being rendered.</summary>
    [Parameter, EditorRequired]
    public IReadOnlyList<TItem> Items { get; set; } = null!;

    /// <summary>The remplate for each row.</summary>
    [Parameter, EditorRequired]
    public RenderFragment<TItem> RowTemplate { get; set; } = null!;

    /// <summary>True if the list should be virtualized, false otherwise.</summary>
    [Parameter]
    public bool Virtualize { get; set; }
}
