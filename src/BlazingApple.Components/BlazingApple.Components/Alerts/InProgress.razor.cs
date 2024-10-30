using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Alerts;

/// <summary>Indicates a feature is in progress.</summary>
public partial class InProgress : ComponentBase
{
    /// <summary>Content to display in the alert, if any.</summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>If <c>true</c>, the alert is rendered in a more compact manner.</summary>
    [Parameter]
    public bool Compact { get; set; }

    /// <summary>A subtitle/description of the intention of the feature.</summary>
    [Parameter]
    public string? Description { get; set; }

    /// <summary>The name of the feature being worked on.</summary>
    [Parameter]
    public string? Name { get; set; }
}
