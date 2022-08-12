using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Records;

/// <summary>A link to various records.</summary>
public partial class RecordLink : ComponentBase
{
    private string _detailsRoute = null!;

    /// <summary>The name or any content we want in the link</summary>
    [Parameter, EditorRequired]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>The record to link to.</summary>
    [Parameter]
    public dynamic? record { get; set; }

    /// <summary>Required if <see cref="record" /> is not provided.</summary>
    [Parameter]
    public string? route { get; set; }

    /// <summary>Required if <see cref="record" /> is not provided.</summary>
    [Parameter]
    public string? slug { get; set; }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        string idForRoute;

        if (record != null)
            idForRoute = record.Id.ToString();
        else
            idForRoute = slug!;

        _detailsRoute = $"{route}/{idForRoute}";
    }
}
