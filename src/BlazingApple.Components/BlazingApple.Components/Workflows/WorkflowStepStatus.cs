namespace BlazingApple.Components.Workflows;

/// <summary>Indicates the status of an individual step.</summary>
public enum WorkflowStepStatus
{
    /// <summary>A step that has not yet been started, but is expected to be completed.</summary>
    NotStarted,

    /// <summary>A step that is in progress, or the current step.</summary>
    InProgress,

    /// <summary>A step that the user has actually completed successfully.</summary>
    Completed,

    /// <summary>
    ///     A step that has been skipped, that otherwise may have been in the list. The use will never see the rendered contents of a skipped step.
    /// </summary>
    Skipped,

    /// <summary>A step that the user declined or failed to complete.</summary>
    Failed,
}
