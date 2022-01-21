﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components
{
    /// <summary>Describes when to open the tooltip.</summary>
    public enum TooltipOpenOn
    {
        /// <summary>Open the tooltip on hover.</summary>
        Hover,

        /// <summary>Open the tooltip on click.</summary>
        Click,
    }

    /// <summary>A generic tooltip.</summary>
    public partial class Tooltip : ComponentBase
    {
        /// <summary>The content to expose with the target Id, that a user must hover or click on.</summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        /// <summary>The delay on closing the tooltip if no action is taken, in seconds.</summary>
        [Parameter]
        public int CloseDelay { get; set; } = 10;

        /// <summary>When to open the tooltip. Defaults to open on <see cref="TooltipOpenOn.Click" /></summary>
        [Parameter]
        public TooltipOpenOn OpenOn { get; set; } = TooltipOpenOn.Click;

        /// <summary>The element Id to target. Ensure it's keyed if in a list.</summary>
        [Parameter]
        public string TargetId { get; set; }

        /// <summary>The content to render inside the tooltip.</summary>
        [Parameter]
        public RenderFragment TooltipContent { get; set; }
    }
}
