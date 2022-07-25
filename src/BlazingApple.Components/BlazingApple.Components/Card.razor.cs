using BlazingApple.Components.Interfaces;

namespace BlazingApple.Components
{
    /// <summary>A "card" component, modeled after the Bootstrap card with various enhanced stylings.</summary>
    public partial class Card : ComponentBase
    {
        private Colors _colors = null!;

        private string _titleStyle = null!;
        private string? _tooltipGuid;
        private bool isDismissed;

        /// <summary>The string content to pass to the badge. If empty, then the <see cref="Title" /> property is used.</summary>
        [Parameter]
        public string BadgeTitle { get; set; } = null!;

        /// <summary>If passed, a complex tooltip will be rendered when the user hovers over the badge.</summary>
        [Parameter]
        public RenderFragment? BadgeTooltipContent { get; set; }

        /// <summary>Custom content to inject into the body of the card.</summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        /// <summary>The color to use for the badge</summary>
        [Parameter]
        public dynamic? Color { get; set; }

        /// <summary>Appears on the right hand side of the card header, left of the dismiss button (if dismissable).</summary>
        [Parameter]
        public RenderFragment? HeaderContent { get; set; }

        /// <summary>Whether or not the user can dismiss the card. If <c>true</c>, then a cancel "x" button is added.</summary>
        [Parameter]
        public bool IsDismissable { get; set; }

        /// <summary>Defaults to open on click. Pass this to modify when the tooltip opens (click or hover).</summary>
        [Parameter]
        public TooltipOpenOn OpenTooltipOn { get; set; } = TooltipOpenOn.Click;

        /// <summary>The title/header of the card.</summary>
        [Parameter, EditorRequired]
        public string Title { get; set; } = null!;

        /// <summary>If passed, the title will be made a link to the provided URL.</summary>
        [Parameter]
        public string? TitleUrl { get; set; }

        /// <summary>The classes to apply to the tooltip, if not passed, none.</summary>
        [Parameter]
        public string? TooltipClasses { get; set; }

        /// <summary>The width for the tooltip, if any. If not passed, it will be defaulted by the content.</summary>
        [Parameter]
        public string? TooltipWidth { get; set; }

        /// <summary>
        ///     By default, we use the badge name to determine the color of the badge. If this is true, the component just selects a color randomly.
        /// </summary>
        [Parameter]
        public bool UseRandomColor { get; set; }

        /// <summary>Get a theme color based on the name provided.</summary>
        /// <returns>A deterministically determined color.</returns>
        public static IThemeColor GetColorForName(IReadOnlyList<IThemeColor> colors, string name)
        {
            int colorCount = colors.Count - 1;
            int nameHash = name.GetHashCode();
            int dateHash = DateTime.Now.Date.GetHashCode();
            int colorIndex = unchecked(Math.Abs(nameHash + dateHash) % colorCount);

            return colors[colorIndex];
        }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            isDismissed = false;
            SetColorIfNull();
            _titleStyle = "color: " + Color.ForegroundHexCode + ";";
            if (string.IsNullOrEmpty(BadgeTitle))
            {
                BadgeTitle = Title;
            }
            if (BadgeTooltipContent is not null)
                _tooltipGuid = Guid.NewGuid().ToString();
        }

        private void DismissCard()
        {
            isDismissed = true;
        }

        [MemberNotNull(nameof(Color))]
        private void SetColorIfNull()
        {
            if (Color == null)
            {
                _colors = new Colors();
                if (UseRandomColor)
                    Color = _colors.GetRandomThemeColor();
                else
                    Color = GetColorForName(_colors, BadgeTitle);
            }
        }
    }
}
