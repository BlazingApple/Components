namespace BlazingApple.Components.Workflows;

/// <summary>The container for the workflow, renders the workflow and its steps.</summary>
public sealed partial class WorkflowContainer : ComponentBase, IDisposable
{
    /// <inheritdoc cref="NavigationManager" />
    [Inject]
    public NavigationManager NavManager { get; set; } = null!;

    /// <summary>The workflow object.</summary>
    [Parameter, EditorRequired]
    public Workflow Workflow { get; set; } = null!;

    /// <summary>The workflow's base url, to append a route value from each step.</summary>
    [Parameter, EditorRequired]
    public string? WorkflowUri { get; set; }

    /// <summary>Notification that a step has changed.</summary>
    public event Func<WorkflowStep, Task>? NotifyStepChange;

    /// <inheritdoc />
    public void Dispose() => Workflow.NotifyStepChange -= OnStepChange;

    /// <summary>Navigate to the next step, or the home page if on the last page.</summary>
    /// <returns>Async op.</returns>
    public async Task Next()
    {
        _ = await Workflow.Next();

        StateHasChanged();
    }

    /// <summary>Navigate to the previous step.</summary>
    /// <returns>Async op.</returns>
    public async Task Previous()
    {
        _ = await Workflow.Previous();
        StateHasChanged();
    }

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Workflow.NotifyStepChange += OnStepChange;
    }

    private async Task OnStepChange(WorkflowStep? step) => await RaiseStepChange(step);

    private async Task RaiseStepChange(WorkflowStep? newStep)
    {
        if (NotifyStepChange is not null && newStep is not null)
            await NotifyStepChange.Invoke(newStep);

        if (newStep is null)
        {
            NavManager.NavigateTo("/");
        }
        else
        {
            Validate();
            NavManager.NavigateTo($"{WorkflowUri}/{newStep.RouteValue}");

            if (newStep.OnRendered.HasDelegate)
                await newStep.OnRendered.InvokeAsync(newStep);
        }
    }

    [MemberNotNull(nameof(WorkflowUri))]
    private void Validate()
    {
        if (WorkflowUri is null)
            throw new ArgumentNullException(nameof(WorkflowUri));
    }
}
