using Microsoft.AspNetCore.Components.Forms;

namespace BlazingApple.Components.HTMLElements;

/// <summary>
/// Renders a radio group in pill form.
/// </summary>
/// <typeparam name="T">The type to bind to.</typeparam>
public partial class PillRadioGroup<T> : InputRadioGroup<T>
{
	private int OptionCount => Options?.Count ?? OptionsByKey?.Count ?? 0;

	private int SelectedIndex => Options is not null && Value is not null
				? Options?.ToList()?.IndexOf(Value) ?? 0
				: OptionsByKey?.Keys is not null && Value is not null ? OptionsByKey?.Values.ToList()?.IndexOf(Value) ?? 0 : 0;

	/// <summary>Additional classes to apply to the pill list.</summary>
	[Parameter]
	public string? AdditionalClasses { get; set; }

	/// <summary></summary>
	[Parameter, EditorRequired]
	public RenderFragment<T>? TemplatedContent { get; set; }

	/// <summary>The options to render where the dictionary key is a unique value for <typeparamref name="T"/>.</summary>
	[Parameter]
	public IReadOnlyDictionary<string, T>? OptionsByKey { get; set; }

	/// <summary>The options to render where <typeparamref name="T"/>'s <c>ToString</c> renders a unique, keyed, value.</summary>
	[Parameter]
	public IReadOnlyList<T>? Options { get; set; }

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		base.OnParametersSet();
		Name ??= Guid.NewGuid().ToString();
	}
}
