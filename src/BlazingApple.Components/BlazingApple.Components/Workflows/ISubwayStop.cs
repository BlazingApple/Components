namespace BlazingApple.Components.Workflows;

/// <summary>This interface allows a model to be displayed in a "subway map-like" user interface.</summary>
public interface ISubwayStop
{
    /// <summary>Details of the stop, displayed in a subdued format.</summary>
    string? Description { get; set; }

    /// <summary>Display a shortened title, displayed in the progress bar.</summary>
    string ShortTitle { get; set; }

    /// <summary>Display title of the stop, displayed prominently.</summary>
    string Title { get; set; }
}
