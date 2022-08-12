using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components;

/// <summary>Structure to display when no content is available.</summary>
public partial class ZeroState : ComponentBase
{
    /// <summary>The visual content to render above the <see cref="Message" /></summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>The message to display when there is no content</summary>
    [Parameter]
    public string? Message { get; set; }
}
