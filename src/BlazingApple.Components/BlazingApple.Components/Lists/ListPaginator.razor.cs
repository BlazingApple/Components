namespace BlazingApple.Components.Lists
{
	/// <summary>This component allows paginating a list.</summary>
	public partial class ListPaginator : ComponentBase
	{
		private int _pageCount = 0;

		/// <summary>Any parameter provided to the component that doesn't match a parameter, will be provided here as a dictionary.</summary>
		[Parameter(CaptureUnmatchedValues = true)]
		public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }

		/// <summary>The number of results on each page.</summary>
		[Parameter, EditorRequired]
		public int BatchSize { get; set; }

		/// <summary>Eventcallback that allows people to trigger events off of values being changed.</summary>
		[Parameter, EditorRequired]
		public EventCallback<int> OnChange { get; set; }

		/// <summary>The total number of results.</summary>
		[Parameter]
		public int ResultCount { get; set; }

		/// <summary>The page number (indexed by 0).</summary>
		[Parameter]
		public int Value { get; set; }

		/// <summary>Eventcallback that allows people to bind to the Value parameter passed in.</summary>
		[Parameter]
		public EventCallback<int> ValueChanged { get; set; }

		/// <inheritdoc />
		protected override void OnParametersSet()
		{
			base.OnParametersSet();
			_pageCount = (int)Math.Ceiling(((decimal)ResultCount) / BatchSize);
		}

		private async Task OnNextClick(bool goToEnd = false)
		{
			if (goToEnd)
			{
				Value = _pageCount - 1;
			}
			else
				Value++;
			if (ValueChanged.HasDelegate)
				await ValueChanged.InvokeAsync(Value);
			if (OnChange.HasDelegate)
				await OnChange.InvokeAsync(Value);
		}

		private async Task OnPageNumberClick(int pageNumber)
		{
			Value = pageNumber;
			if (ValueChanged.HasDelegate)
				await ValueChanged.InvokeAsync(Value);
			if (OnChange.HasDelegate)
				await OnChange.InvokeAsync(Value);
		}

		private async Task OnPreviousClick(bool goToStart = false)
		{
			if (goToStart)
				Value = 0;
			else
				Value--;

			if (ValueChanged.HasDelegate)
				await ValueChanged.InvokeAsync(Value);
			if (OnChange.HasDelegate)
				await OnChange.InvokeAsync(Value);
		}
	}
}
