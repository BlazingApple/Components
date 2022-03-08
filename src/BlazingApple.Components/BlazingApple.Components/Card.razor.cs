﻿using BlazingApple.Components.Interfaces;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components
{
	public partial class Card : ComponentBase
	{
		private Colors _colors;

		private string _titleStyle;
		private string? _tooltipGuid;
		private bool isDismissed;

		[Parameter]
		public string BadgeTitle { get; set; }

		/// <summary>If passed, a complex tooltip will be rendered when the user hovers over the badge.</summary>
		[Parameter]
		public RenderFragment? BadgeTooltipContent { get; set; }

		[Parameter]
		public RenderFragment ChildContent { get; set; }

		/// <summary>The color to use for the badge</summary>
		[Parameter]
		public dynamic Color { get; set; }

		/// <summary>Appears on the right hand side of the card header, left of the dismiss button (if dismissable).</summary>
		[Parameter]
		public RenderFragment HeaderContent { get; set; }

		[Parameter]
		public bool IsDismissable { get; set; }

		/// <summary>Defaults to open on click. Pass this to modify when the tooltip opens (click or hover).</summary>
		[Parameter]
		public TooltipOpenOn OpenTooltipOn { get; set; } = TooltipOpenOn.Click;

		[Parameter]
		public string Title { get; set; }

		/// <summary>If passed, the title will be made a link to the provided URL.</summary>
		[Parameter]
		public string TitleUrl { get; set; }

		/// <summary>The classes to apply to the tooltip, if not passed, none.</summary>
		[Parameter]
		public string? TooltipClasses { get; set; }

		/// <summary>The width for the tooltip, if any. If not passed, it will be defaulted by the content.</summary>
		[Parameter]
		public string? TooltipWidth { get; set; }

		/// <inheritdoc />
		protected override void OnParametersSet()
		{
			base.OnParametersSet();
			isDismissed = false;
			SetColorIfNull();
			_titleStyle = "color: " + Color.HexCode + ";";
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

		private void SetColorIfNull()
		{
			if (Color == null)
			{
				_colors = new Colors();
				Color = _colors.GetRandomThemeColor();
			}
		}
	}
}
