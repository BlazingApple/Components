namespace BlazingApple.Components;

/// <summary>A set of text that is capped in length, and displays a button allowing the user to indicate it shouldn't be capped in length.</summary>
public partial class TextLimitedSegment : ComponentBase
{
	private string _limitedContent = null!;

	private bool _showMoreSelected;

	private int _wordCount = default;

	/// <summary>Optional set of additional attributes.</summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public IDictionary<string, object>? AdditionalAttributes { get; set; }

	/// <summary>The string text to truncate if it is too long.</summary>
	[Parameter, EditorRequired]
	public string Content { get; set; } = null!;

	/// <summary>Defaults to 25 words if not set. Any count of words over this are truncated and an ellipsis added.</summary>
	[Parameter]
	public int MaxWords { get; set; } = 25;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		base.OnParametersSet();

		string[] words = Content.Split(" ");
		_limitedContent = string.Empty;
		_wordCount = words.Length;

		if (_wordCount > MaxWords)
		{
			for (int i = 0; i < MaxWords; i++)
			{
				if (i != 0)
				{
					_limitedContent += " " + words[i];
				}
				else
				{
					_limitedContent += words[i];
				}
			}
			_limitedContent += "...";
		}
	}
}
