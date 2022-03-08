using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Lists
{
    public partial class RecordList<TItem> : ComponentBase
    {
        private bool awaitingLoadMoreResponse;

        /// <summary>The extra attributes to show on a page.</summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object>? AdditionalAttributes { get; set; }

        /// <summary>Tbe column grouping to use, if any.</summary>
        [Parameter]
        public RenderFragment? ColGroup { get; set; }

        /// <summary>
        ///     If this is set to true, rather than a table, an unordered list element will be used. If this is set to true, HeadRow is rendered as
        ///     is, not as a <thead></thead> element.
        /// </summary>
        [Parameter]
        public bool FormatAsList { get; set; }

        /// <summary>The render fragment that displays the table heading columns.</summary>
        [Parameter]
        public RenderFragment? HeadRow { get; set; }

        /// <summary>The item models to render.</summary>
        [Parameter]
        public ICollection<TItem> Items { get; set; }

        /// <summary>Used to provide a more data to the row.</summary>
        [Parameter]
        public EventCallback LoadMoreCallback { get; set; }

        /// <summary>Whether or not the list has a maximum height to render, for virtualization purposes.</summary>
        [Parameter]
        public bool NoMaxHeight { get; set; }

        /// <summary>The remplate for each row.</summary>
        [Parameter, EditorRequired]
        public RenderFragment<TItem> RowTemplate { get; set; } = null!;

        private string RootDivStyles => NoMaxHeight ? "" : "max-height: 100vh; overflow: auto; overflow-x: hidden;";

        private async void OnLoadMoreClicked()
        {
            awaitingLoadMoreResponse = true;
            await LoadMoreCallback.InvokeAsync();
            awaitingLoadMoreResponse = false;
            StateHasChanged();
        }
    }
}
