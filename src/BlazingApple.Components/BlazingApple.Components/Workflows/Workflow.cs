using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Workflows;

/// <summary>Models a set of steps a user must do to complete a workflow.</summary>
public class Workflow
{
    /// <summary>The current <see cref="WorkflowStep" /></summary>
    public WorkflowStep? CurrentStep { get; set; }

    /// <summary>The index of the current <see cref="WorkflowStep" /></summary>
    public int? CurrentStepIndex { get; set; }

    /// <summary>The collection of steps needed to complete the workflow.</summary>
    public IList<WorkflowStep> Steps { get; }

    /// <summary>The title of the workflow, displayed to end users.</summary>
    public string Title { get; set; }

    /// <summary>Notification that a step has changed.</summary>
    public event Func<WorkflowStep?, Task>? NotifyStepChange;

    /// <summary>Workflow constructor.</summary>
    public Workflow(string title, IList<WorkflowStep> steps)
        : this(title, steps, 0)
    { }

    /// <summary>With a specific start index.</summary>
    public Workflow(string title, IList<WorkflowStep> steps, int startIndex)
    {
        Title = title;
        Steps = steps;
        CurrentStepIndex = startIndex;
        CurrentStep = Steps[CurrentStepIndex.Value];
    }

    /// <summary>Automatically redirect to the right step.</summary>
    /// <param name="stepIndex">The step number indexed from zero to navigate to.</param>
    /// <returns>Async op.</returns>
    public async Task GoToStep(int stepIndex)
    {
        for (int i = 0; i < stepIndex; i++)
            Steps[i].IsComplete = true;

        CurrentStepIndex = stepIndex;
        CurrentStep = Steps[stepIndex];

        (int index, WorkflowStep? step) = TryGetClosestNonSkippedStep(CurrentStepIndex.Value);
        CurrentStepIndex = index;
        CurrentStep = step;

        if (CurrentStep != null)
            await RaiseStepChange(CurrentStep);
    }

    /// <summary>Whether or not the workflow is complete.</summary>
    /// <returns>True if completed.</returns>
    public bool IsComplete() => Steps.All(step => step.IsComplete || step.Status == WorkflowStepStatus.Skipped);

    /// <summary>Advances the current step to the next step.</summary>
    /// <returns>The new current step, or null if at the end.</returns>
    public async Task<WorkflowStep?> Next()
    {
        if (!CurrentStepIndex.HasValue)
        {
            CurrentStepIndex = 0;
        }
        else if (CurrentStepIndex == Steps.Count - 1)
        {
            CurrentStep = null;
        }
        else
        {
            CurrentStepIndex++;

            (int stepIndex, WorkflowStep? step) = TryGetClosestNonSkippedStep(CurrentStepIndex.Value);

            CurrentStepIndex = stepIndex;
            CurrentStep = step;
        }

        await RaiseStepChange(CurrentStep);
        return CurrentStep;
    }

    /// <summary>Reverts the current step to the previous step.</summary>
    /// <returns>The new current step, or null if at the beginning.</returns>
    public async Task<WorkflowStep?> Previous()
    {
        if (CurrentStepIndex is null || CurrentStepIndex == 0)
            CurrentStepIndex = 0;
        else
            CurrentStepIndex--;

        (int newIndex, WorkflowStep? step) = TryGetClosestNonSkippedStep(CurrentStepIndex.Value);

        CurrentStepIndex = newIndex;
        CurrentStep = step;

        await RaiseStepChange(CurrentStep);
        return CurrentStep;
    }

    private async Task RaiseStepChange(WorkflowStep? newStep)
    {
        if (NotifyStepChange is not null)
            await NotifyStepChange.Invoke(newStep);
    }

    private (int StepIndex, WorkflowStep? Step) TryGetClosestNonSkippedStep(int currentIndex)
    {
        WorkflowStep currentStep = Steps[currentIndex];
        while (currentStep.Status == WorkflowStepStatus.Skipped && currentIndex < Steps.Count)
        {
            currentIndex++;
            currentStep = Steps[currentIndex];
        }

        return (currentIndex, currentStep);
    }
}
