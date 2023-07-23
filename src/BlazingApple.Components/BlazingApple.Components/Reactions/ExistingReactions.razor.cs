using BlazingApple.Components.Shared.Models.Reactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Reactions;

/// <summary>Shows existing reactions for an entity.</summary>
public partial class ExistingReactions : ComponentBase
{
    private int _totalReactionCount;
    /// <summary>Used to render the number of reactions by <see cref="ReactionType"/></summary>
    [Parameter, EditorRequired]
    public IReadOnlyDictionary<ReactionType, int>? Reactions { get; set; }

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        base.OnParametersSet();
        _totalReactionCount = Reactions?.Values.Sum(v => v) ?? 0;

	}
}