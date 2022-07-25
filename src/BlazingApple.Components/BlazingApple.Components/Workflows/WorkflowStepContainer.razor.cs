using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Workflows;

/// <summary>Renders the individual workflow step.</summary>
public sealed partial class WorkflowStepContainer : ComponentBase, IDisposable
{
    /// <summary>The parent workflow container, needed to navigate forward and backward.</summary>
    [CascadingParameter]
    public WorkflowContainer Parent { get; set; } = null!;

    /// <summary>The step to render.</summary>
    [Parameter, EditorRequired]
    public WorkflowStep Step { get; set; } = null!;

    /// <inheritdoc />
    public void Dispose() => Parent.NotifyStepChange -= OnStepChange;

    /// <summary>Marks this step as complete.</summary>
    public void MarkStepComplete()
    {
        Step.IsComplete = true;
        StateHasChanged();
    }

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        Parent.NotifyStepChange += OnStepChange;
    }

    /// <summary>hides or shows the current step if it is the current step.</summary>
    /// <returns>The class to apply to the container.</returns>
    private string GetHiddenClass()
    {
        if (Parent.Workflow.CurrentStep == Step)
            return "";
        else
            return "hidden";
    }

    /// <summary>Allow navigating if this step is complete</summary>
    private async Task OnNextClick()
    {
        if (Step.IsComplete)
        {
            await Parent.Next();
            StateHasChanged();
        }
    }

    /// <summary>Allow navigating forward and backward.</summary>
    private async Task OnPreviousClick()
    {
        if (!Step.AllowPreviousNavigation)
            return;

        await Parent.Previous();
        StateHasChanged();
    }

    private async Task OnStepChange(WorkflowStep step)
    {
        if (Step == step && Step.Status == WorkflowStepStatus.Skipped)
        {
            Step.IsComplete = true;
            await OnNextClick();
        }
    }
}
