using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;

namespace BlazingApple.Components
{
    /// <summary>Automatically determines to open content in a new tab or not.</summary>
    public partial class BrowserLink : ComponentBase
    {
        private NavigationManager? _navManager;

        /// <summary>Excess attributes.</summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> AdditionalAttributes { get; set; } = null!;

        /// <summary>The rendered content of the link.</summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; } = null!;

        /// <summary>the class(es) to apply.</summary>
        [Parameter]
        public string? className { get; set; }

        /// <summary>The route/path to the url.</summary>
        [Parameter, EditorRequired]
        public string href { get; set; } = null!;

        /// <summary>Used to indicate when a link is clicked.</summary>
        [Parameter]
        public EventCallback<string> OnClick { get; set; }

        /// <inheritdoc cref="IServiceProvider" />
        [Inject]
        public IServiceProvider ServiceProvider { get; set; } = null!;

        /// <summary>The title attribute/hover text.</summary>
        [Parameter]
        public string? title { get; set; }

        /// <inheritdoc />
        protected override void OnInitialized()
        {
            base.OnInitialized();
            _navManager = ServiceProvider.GetService<NavigationManager>();
        }

        private bool IsExternal(string url)
        {
            if (_navManager is null)
                return false;

            string currentHost = new Uri(_navManager.BaseUri).Host;
            string linkUrl;

            try
            {
                linkUrl = new Uri(url).AbsoluteUri;
            }
            catch (Exception)
            {
                // We know this is a relative path if this operation fails
                return false;
            }

            Regex internalLinkRegex = new("^((((http:\\/\\/|https:\\/\\/)(www\\.)?)?"
                                    + currentHost
                                    + ")|(localhost:\\d{4})|(\\/.*))(\\/.*)?$");

            MatchCollection matches = internalLinkRegex.Matches(linkUrl);
            if (matches.Count > 0)
            {
                return false;
            }
            return true;
        }

        private async Task OnClickInternal()
        {
            if (OnClick.HasDelegate)
                await OnClick.InvokeAsync(href);
        }
    }
}
