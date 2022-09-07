using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components
{
    /// <summary>Renders a due date and color codes it based on the proximity to the current date.</summary>
    public partial class DueDate : ComponentBase
    {
        private string? _styleString;

        /// <summary>The date to compare against.</summary>
        [Parameter]
        public DateTime? Date { get; set; }

        /// <summary>The format string to apply to the <see cref="DateTime" /> property.</summary>
        /// <example>Defaults to "Jan 07 '22".</example>
        [Parameter]
        public string DateFormatString { get; set; } = "MMM dd \\'yy";

        /// <summary>A hex code representing a due date that is upcoming. Defaults to <c>#d94e6f</c>.</summary>
        [Parameter]
        public string OverdueColor { get; set; } = "#d94e6f";

        /// <summary>
        ///     The day difference between the current date and the due date. Once this date has been exceeded, the due date text will turn this color.
        /// </summary>
        /// <example>If set to -1, then the text will turn the <see cref="OverdueColor" /> the day <i>after</i> the due date.</example>
        [Parameter]
        public int OverdueDays { get; set; } = -1;

        /// <summary>
        ///     The day difference between the current date and the due date. Once this date has been exceeded, the due date text will turn this color.
        /// </summary>
        /// <example>If set to -3, then the text will become <b>bold</b> 3 day <i>after</i> the due date.</example>
        [Parameter]
        public int ReallyOverdueDays { get; set; } = -3;

        /// <summary>A hex code representing a due date that is upcoming. Defaults to <c>#f4c100</c>.</summary>
        [Parameter]
        public string UpcomingColor { get; set; } = "#f4c100";

        /// <summary>
        ///     The minimum day difference between the current date and the due date. Once this date has been exceeded, the due date text will turn
        ///     this color.
        /// </summary>
        /// <example>If set to 1, then the text will turn the <see cref="UpcomingColor" /> the day <i>before</i> the due date.</example>
        [Parameter]
        public int UpcomingDays { get; set; } = 1;

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Validate();

            int daysBetween = (Date.Value.Date - DateTime.Now.Date).Days;

            if (daysBetween > UpcomingDays)
                return;
            else if (OverdueDays < daysBetween && daysBetween <= UpcomingDays)
                _styleString = GetColorStyle(UpcomingColor);
            else if (daysBetween <= OverdueDays)
                _styleString = GetColorStyle(OverdueColor);

            if (daysBetween <= ReallyOverdueDays && ReallyOverdueDays != OverdueDays)
                _styleString += " font-weight: bold;";
        }

        private static string GetColorStyle(string colorHexCode)
            => $"color: {colorHexCode};";

        [MemberNotNull(nameof(Date))]
        private void Validate()
        {
            if (!Date.HasValue)
                throw new ArgumentException("Date must be provided.", nameof(Date));
            if (UpcomingDays <= OverdueDays)
                throw new ArgumentException("UpcomingDays must be greater than OverdueDays", nameof(UpcomingDays));
            if (OverdueDays < ReallyOverdueDays)
                throw new ArgumentException("OverdueDays must be greater or equal to ReallyOverdueDays", nameof(OverdueDays));
        }
    }
}
