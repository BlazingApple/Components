using Microsoft.AspNetCore.Components;

namespace BlazingApple.Components.HTMLElements
{
    /// <summary>Core component representing a field and its label.</summary>
    public partial class FormGroup : ComponentBase
    {
        /// <summary>Any parameter provided to the component that doesn't match a parameter, will be provided here as a dictionary.</summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object>? AdditionalAttributes { get; set; }

        /// <summary>The elements/content to display in the form group.</summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; } = null!;

        /// <summary>Classes applied to the containing div.</summary>
        [Parameter]
        public string? ColumnWidthClass { get; set; }

        /// <summary>The label for the group.</summary>
        [Parameter]
        public string? Label { get; set; }
    }
}
