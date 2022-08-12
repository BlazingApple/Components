using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components;

/// <summary>Renders a loading message, with varying levels of "subtlety".</summary>
public partial class Loading : ComponentBase
{
    private readonly List<string> _loadingIcons = new()
    {
        "fas fa-compact-disc",
        "fas fa-compass",
        "far fa-compass",
        "fas fa-sync-alt",
        "fas fa-atom",
        "fas fa-yin-yang",
        "fas fa-fan",
        "fas fa-asterisk",
        "fas fa-sun",
        "far fa-snowflake",
        "far fa-life-ring",
        "fas fa-circle-notch",
        "fas fa-bahai",
        "fas fa-stroopwafel",
        "fas fa-spinner",
        "fas fa-cog"
    };
    private string _containerCssClass = "ba-page-loading-container";

    private string _loadingIcon = null!;

    /// <inheritdoc cref="LoadingStyle" />
    [Parameter]
    public LoadingStyle Style { get; set; } = LoadingStyle.Default;

    /// <inheritdoc />
    protected override void OnInitialized()
    {
        int randomIndex = new Random().Next(_loadingIcons.Count);
        _loadingIcon = _loadingIcons[randomIndex];
    }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        _containerCssClass = "ba-page-loading-container";

        if (Style == LoadingStyle.FullPage)
            _containerCssClass += " full-page";
    }

    /// <summary>The style of loading indicator desired.</summary>
    public enum LoadingStyle
    {
        /// <summary>Position Relatively within parent</summary>
        Default,

        /// <summary>Position Subtle, with text</summary>
        Subtle,

        /// <summary>Position Absolutely</summary>
        FullPage
    }
}
