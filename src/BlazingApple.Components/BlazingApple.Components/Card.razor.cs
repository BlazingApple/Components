using BlazingApple.Components.Interfaces;
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

		private bool isDismissed;

		[Parameter]
		public string BadgeTitle { get; set; }

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

		[Parameter]
		public string Title { get; set; }

		/// <summary>If passed, the title will be made a link to the provided URL.</summary>
		[Parameter]
		public string TitleUrl { get; set; }

		protected override void OnParametersSet()
		{
			isDismissed = false;
			SetColorIfNull();
			_titleStyle = "color: " + Color.HexCode + ";";
			if (string.IsNullOrEmpty(BadgeTitle))
			{
				BadgeTitle = Title;
			}
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
