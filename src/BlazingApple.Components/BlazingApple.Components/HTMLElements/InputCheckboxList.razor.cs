using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazingApple.Components.HTMLElements
{
    /// <summary>Allows rendering a list of checkboxes bound to the SelectedValue.</summary>
    /// <typeparam name="TItem"></typeparam>
    public partial class InputCheckboxList<TItem, TValue> : ComponentBase
    {
        /// <summary>HTML attributes to apply to the containing div.</summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object>? AdditionalAttributes { get; set; }

        /// <summary>Any child content for the control (if needed)</summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        /// <summary>Data for the Checkbox List</summary>
        [Parameter]
        public IEnumerable<TItem> Data { get; set; } = null!;

        /// <summary>Whether or not the whole list is disabled.</summary>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>Called when any value of the checkbox list is modified.</summary>
        [Parameter]
        public EventHandler? OnChange { get; set; }

        /// <summary>Contains the list of selected checkboxes.</summary>
        [Parameter]
        public List<TValue> SelectedValues { get; set; }

        /// <summary>The display text to be shown adjacent to checkbox</summary>
        [Parameter]
        public Func<TItem, string> TextField { get; set; } = null!;

        /// <summary>The Value which checkbox will return when checked</summary>
        [Parameter]
        public Func<TItem, TValue> ValueField { get; set; } = null!;

        /// <summary>Method to update the selected value on click on checkbox</summary>
        /// <param name="aSelectedId">The selected Id, derived from the ToString() value of the object.</param>
        /// <param name="aChecked">Whether or not the box was checked.</param>
        private void CheckboxClicked(string aSelectedId, object aChecked)
        {
            TValue matchingValue = ValueField.Invoke(Data.First(item => item.ToString() == aSelectedId));
            if ((bool)aChecked)
            {
                if (!SelectedValues.Any(item => item.ToString() == aSelectedId))
                    SelectedValues.Add(matchingValue);
            }
            else
            {
                if (SelectedValues.Any(item => item.ToString() == aSelectedId))
                    SelectedValues.Remove(matchingValue);
            }
            if (OnChange != null)
                OnChange.Invoke(null, null);

            StateHasChanged();
        }
    }
}
