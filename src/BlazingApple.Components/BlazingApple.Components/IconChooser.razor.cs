using BlazingApple.FontAwesome.Models;
using BlazingApple.FontAwesome.Services;

namespace BlazingApple.Components
{
    /// <summary>A collection of icons rendered as buttons for a user to choose from.</summary>
    public partial class IconChooser : ComponentBase
    {
        private bool _isLoading;
        private IReadOnlyDictionary<string, string>? _searchResultIcons;
        private string? _searchString = null;

        /// <summary>Additional attributes to put on each button.</summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object>? AdditionalAttributes { get; set; }

        /// <summary>Additional classes to put on the button. Uses <c>btn-light</c> if not provided.</summary>
        [Parameter]
        public string ButtonClasses { get; set; } = "btn-light";

        /// <summary>A dictionary, keyed by the icon display name, and valued by the icon class names to also render.</summary>
        [Parameter]
        public IReadOnlyDictionary<string, string>? CustomIcons { get; set; }

        /// <summary>The callback to invoke when the user's search query has changed.</summary>
        [Parameter]
        public EventCallback<string?> OnSearchChanged { get; set; }

        /// <summary>Default is "Search for an icon!" if not passed. Displays when the search box field is empty.</summary>
        [Parameter]
        public string SearchGhostText { get; set; } = "Search for an icon!";

        /// <summary>The selected button's classes to put on the button. Uses <c>btn-primary</c> if not provided.</summary>
        [Parameter]
        public string SelectedButtonClasses { get; set; } = "btn-primary";

        /// <summary>The selected IconType</summary>
        [Parameter]
        public IconData? Value { get; set; }

        /// <summary>The callback to invoke when the value changed.</summary>
        [Parameter]
        public EventCallback<IconData?> ValueChanged { get; set; }

        /// <summary>
        ///     If passed, this route will be appended with a "?query={searchQuery}" and the invoked callback on a search change will use this
        ///     endpoint to load icon data.
        /// </summary>
        [Parameter]
        public string? WebRoute { get; set; }

        [Inject]
        private FontSearchService SearchService { get; set; } = null!;

        private async Task DoSearch(string? searchQuery)
        {
            _isLoading = true;
            IEnumerable<FontAwesomeIcon>? results = await SearchService.Search(searchQuery);
            if (results == null)
            {
                _searchResultIcons = null;
            }
            else
            {
                _searchResultIcons = results.ToDictionary(i => i.Label ?? "", i => i.GetCode().Trim());
            }
            _isLoading = false;
        }

        private async Task OnSearchChange(ChangeEventArgs args)
        {
            _searchString = (string?)args.Value;

            if (!string.IsNullOrEmpty(_searchString))
                _searchString = _searchString.ToLower();

            await DoSearch(_searchString);

            if (OnSearchChanged.HasDelegate)
                await OnSearchChanged.InvokeAsync(_searchString);
        }

        private async Task Set(IconData icon)
        {
            if (Value is not null && Value.IconClasses == icon.IconClasses)
                Value = null;
            else
                Value = icon;

            if (ValueChanged.HasDelegate)
                await ValueChanged.InvokeAsync(Value);
        }

        private bool IsSelectedButton(IconData icon)
            => Value is not null && icon == Value;

        private string GetClassesForButton(IconData buttonIcon)
            => IsSelectedButton(buttonIcon) ? SelectedButtonClasses : ButtonClasses;
    }
}
