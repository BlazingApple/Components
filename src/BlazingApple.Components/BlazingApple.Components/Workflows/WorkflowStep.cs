namespace BlazingApple.Components.Workflows;

/// <summary>A single step within a <see cref="Workflow" /></summary>
public class WorkflowStep : ISubwayStop
{
    /// <summary>If true, allow this form to be navigated to backwards.</summary>
    public bool AllowPreviousNavigation { get; set; }

    /// <summary>The date and time of the step completion.</summary>
    public DateTime CompletionTimestamp { get; set; }

    /// <summary>The content to display when the user is working on this step.</summary>
    public RenderFragment? Content { get; set; }

    /// <summary>Detailed description of the step, indicating to the user what needs to be done (and why).</summary>
    public string? Description { get; set; }

    /// <summary>Whether or not the step has been completed.</summary>
    public bool IsComplete { get; set; }

    /// <summary>Indicates when the step is rendered.</summary>
    public EventCallback OnRendered { get; set; }

    /// <summary>The route value within the workflow, a partial URL.</summary>
    public string RouteValue { get; set; }

    /// <summary>The short title that Kate made me add. Displays in the progress bar.</summary>
    public string ShortTitle { get; set; }

    /// <inheritdoc cref="WorkflowStepStatus" />
    public WorkflowStepStatus Status { get; set; }

    /// <summary>The display title of the step.</summary>
    public string Title { get; set; }

    /// <summary>Constructor.</summary>
    public WorkflowStep(string title, string shortTitle, string routeValue, WorkflowStepStatus? status = null)
    {
        Title = title;
        ShortTitle = shortTitle;
        RouteValue = routeValue;
        Status = status ?? WorkflowStepStatus.NotStarted;
    }
}
