using BlazingApple.Components.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components
{
    /// <summary>A collection of icons rendered as buttons for a user to choose from.</summary>
    public partial class IconChooser : ComponentBase
    {
        private string? _searchString = null;

        /// <summary>Additional attributes to put on each button.</summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object>? AdditionalAttributes { get; set; }

        /// <summary>Additional classes to put on the button. Uses <c>btn-light</c> if not provided.</summary>
        [Parameter]
        public string? ButtonClasses { get; set; } = "btn-light";

        /// <summary>A dictionary, keyed by the icon display name, and valued by the icon class names to also render.</summary>
        [Parameter]
        public IReadOnlyDictionary<string, string>? CustomIcons { get; set; }

        /// <summary>Default is "Search for an icon!" if not passed. Displays when the search box field is empty.</summary>
        [Parameter]
        public string SearchGhostText { get; set; } = "Search for an icon!";

        /// <summary>The selected button's classes to put on the button. Uses <c>btn-primary</c> if not provided.</summary>
        [Parameter]
        public string? SelectedButtonClasses { get; set; } = "btn-primary";

        /// <summary>The selected IconType</summary>
        [Parameter]
        public IconData? Value { get; set; }

        /// <summary>The callback to invoke when the value changed.</summary>
        [Parameter]
        public EventCallback<IconData?> ValueChanged { get; set; }

        /// <summary>The value that the component is bound to.</summary>
        private IconData? BoundValue
        {
            get => Value;
            set
            {
                ValueChanged.InvokeAsync(value);
                Value = value;
            }
        }

        private void OnSearchChange(ChangeEventArgs args)
        {
            _searchString = (string?)args.Value;

            if (_searchString != null)
                _searchString = _searchString.ToLower();
        }

        private void Set(IconData icon) => BoundValue = icon;
    }
}
