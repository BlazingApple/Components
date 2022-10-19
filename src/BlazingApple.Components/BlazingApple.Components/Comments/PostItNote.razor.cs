using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Comments;

/// <summary>Renders a cute post it note alongside a component.</summary>
public partial class PostItNote : ComponentBase
{
	private Guid _postItGuid = Guid.NewGuid();

	/// <summary>The detailed comment.</summary>
	[Parameter]
	public string? Comment { get; set; }

	/// <summary>The subtitle.</summary>
	[Parameter]
	public string? Subtitle { get; set; }

	/// <summary>Defaults to the post it element id if not set. Otherwise, any element Id on the screen.</summary>
	[Parameter]
	public string? TargetId { get; set; }

	/// <summary>The title of on the post it note.</summary>
	[Parameter]
	public string? Title { get; set; }

	/// <inheritdoc />
	protected override async Task OnParametersSetAsync()
	{
		await base.OnParametersSetAsync();
		TargetId ??= $"#post-{_postItGuid}";
	}
}
