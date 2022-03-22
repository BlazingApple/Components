using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazingApple.Components
{
    /// <summary>Automatically determines to open content in a new tab or not.</summary>
    public partial class BrowserLink : ComponentBase
    {
        private NavigationManager? _navManager;

        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> AdditionalAttributes { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public string className { get; set; }

        [Parameter]
        public string href { get; set; }

        /// <inheritdoc cref="IServiceProvider" />
        [Inject]
        public IServiceProvider ServiceProvider { get; set; } = null!;

        [Parameter]
        public string title { get; set; }

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
            catch (Exception e)
            {
                // We know this is a relative path if this operation fails
                return false;
            }

            Regex internalLinkRegex = new Regex("^((((http:\\/\\/|https:\\/\\/)(www\\.)?)?"
                                    + currentHost
                                    + ")|(localhost:\\d{4})|(\\/.*))(\\/.*)?$");

            MatchCollection matches = internalLinkRegex.Matches(linkUrl);
            if (matches.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
