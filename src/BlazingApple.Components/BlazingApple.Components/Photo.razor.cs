using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components;

/// <summary>Renders a <see cref="Badge" /> or rounded image if no photo is found.</summary>
public partial class Photo : ComponentBase
{
    private bool _showBadge;

    /// <summary>Additional attributes to display, if any.</summary>
    [Parameter(CaptureUnmatchedValues = true)]
    public IDictionary<string, object>? AdditionalAttributes { get; set; }

    /// <summary>Name to show next to the picture</summary>
    [Parameter]
    public string? AltText { get; set; }

    /// <summary>The additional content, if any.</summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>The backup image to display if the image fails to load.</summary>
    [Parameter]
    public string? ImageBackupUrl { get; set; }

    /// <summary>The url to photo/image to display, if any.</summary>
    [Parameter]
    public string? ImageUrl { get; set; }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        if (string.IsNullOrEmpty(ImageUrl) && !string.IsNullOrEmpty(AltText))
            _showBadge = true;
    }

    /// <summary>Update the image source for an image if we fail to load it.</summary>
    private void OnImageLoadFail()
    {
        if (!string.IsNullOrEmpty(ImageBackupUrl))
            ImageUrl = ImageBackupUrl;
        else
            ImageUrl = "/images/MissingImage.png";
    }
}
