using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Files;

/// <summary>Allows viewing various files.</summary>
public partial class FileViewer : ComponentBase
{
	private IRenderableFile? _selectedFile;

	/// <summary>The files to render.</summary>
	[Parameter, EditorRequired]
	public IReadOnlyList<IRenderableFile>? Files { get; set; }

	/// <summary>
	/// Set to false if the desired initial state of the component is to not have any file selected.
	/// </summary>
	[Parameter]
	public bool DefaultFileSelection { get; set; } = true;

	/// <inheritdoc />
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		if (Files is not null && Files.Count > 0 && DefaultFileSelection)
			_selectedFile = Files[0];
	}

	private void OnFileSelect(IRenderableFile selectedFile)
	{
		_selectedFile = null;
		StateHasChanged();
		_selectedFile = selectedFile;
		StateHasChanged();
	}
}
