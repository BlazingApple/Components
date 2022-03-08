using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Search
{
    /// <summary>A search box, for searching.</summary>
    public partial class SearchBox : ComponentBase
    {
        private string _clearButtonClasses = "og-clear-seach text-muted hidden";
        private bool _displayClearButton;
        private string? _searchTerm;

        /// <summary>Fired when the user's focus leaves or enter is pressed.</summary>
        [Parameter]
        public EventCallback<ChangeEventArgs> OnSearchChange { get; set; }

        /// <summary>The search term.</summary>
        [Parameter]
        public string? SearchTerm
        {
            get => _searchTerm;
            set
            {
                _searchTerm = value;
                InternalOnSearchChange();
            }
        }

        /// <summary>The title text for the search field.</summary>
        [Parameter]
        public string? TitleText { get; set; }

        /// <summary>Business logic delegate to clear the search string.</summary>
        private void Clear()
            => SearchTerm = "";

        /// <summary>Update whether or not the "x" is shown based on the value.</summary>
        private void InternalOnSearchChange()
        {
            _displayClearButton = !string.IsNullOrEmpty(SearchTerm);
            if (_displayClearButton)
                _clearButtonClasses = "og-clear-seach text-muted";
            else
                _clearButtonClasses = "og-clear-seach text-muted hidden";

            OnSearchChange.InvokeAsync(new ChangeEventArgs() { Value = SearchTerm });
        }

        /// <summary>Click handler for clicking the "Clear" button.</summary>
        private void OnClearClick()
            => Clear();
    }
}
