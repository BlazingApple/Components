using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Records
{
    public partial class RecordAction : ComponentBase
    {
        private string _deleteRoute;
        private string _detailsRoute;
        private string _editRoute;
        private string _idForRoute;
        private string vertBar = "|";

        /// <summary>If true, the links will be shown as disabled.</summary>
        [Parameter]
        public bool Disabled { get; set; }

        /// <summary>If passed, this will show content on the disabled link.</summary>
        [Parameter]
        public string? DisabledTooltip { get; set; }

        /// <summary>
        ///     If this is set to true, then the edit button will always be an icon. If it is not set or set to false the edit button is not
        ///     guaranteed to be text, it could still be an icon, based on the default styles.
        /// </summary>
        [Parameter]
        public bool DisplayEditAsIcon { get; set; }

        /// <summary>Hides the edit button.</summary>
        [Parameter]
        public bool HideEditButton { get; set; }

        /// <summary>Describes what action to take upon clicking the delete link.</summary>
        [Parameter]
        public EventCallback<string> OnDeleteClick { get; set; }

        /// <summary>If true, we don't show the details button, since the action links are already displayed here.</summary>
        [Parameter]
        public bool OnDetailsPage { get; set; }

        /// <summary>The action to take upon clicking the edit button.</summary>
        [Parameter]
        public EventCallback<string> OnEditClick { get; set; }

        /// <summary>True if on the edit page, will hide the edit button.</summary>
        [Parameter]
        public bool OnEditPage { get; set; }

        /// <summary>The record to render links/actions for.</summary>
        [Parameter]
        public dynamic record { get; set; }

        /// <summary>The route for the record.</summary>
        [Parameter]
        public string route { get; set; }

        /// <summary>If record is not populated, we use this as the route Identifier.</summary>
        [Parameter]
        public string slug { get; set; }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            if (record != null)
            {
                _idForRoute = record.Id.ToString();
            }
            else
            {
                _idForRoute = slug;
            }
            _editRoute = route + "/edit/" + _idForRoute;
            _detailsRoute = route + "/" + _idForRoute;
            _deleteRoute = "/api" + route + "/" + _idForRoute; // Route starts with /
        }

        private void _OnDeleteClick()
        {
            if (OnDeleteClick.HasDelegate && !Disabled)
                OnDeleteClick.InvokeAsync(_idForRoute);
        }

        private void _OnEditClick()
        {
            if (OnEditClick.HasDelegate && !Disabled)
                OnEditClick.InvokeAsync(_idForRoute);
        }
    }
}
