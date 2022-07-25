using BlazingApple.Components.Services;
using Blazorise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blazorise.Icons.FontAwesome;
using fa = Blazorise.Icons.FontAwesome.FontAwesomeIcons;

using s = BlazingApple.Components.Services;

namespace BlazingApple.Components
{
    /// <summary>Renders an icon using the FontAwesome library.</summary>
    public partial class Icon : ComponentBase
    {
        private string? customIconString;

        /// <summary>Any additional attributes to apply to the icon, like an id etc.</summary>
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object>? AdditionalAttributes { get; set; }

        /// <summary>Any additional classes to apply to the icon.</summary>
        [Parameter]
        public string? AdditionalClasses { get; set; }

        /// <summary>Used for the icon's title text</summary>
        [Parameter]
        public string? AltText { get; set; }

        /// <summary>
        ///     Pass this if you want a custom icon from FontAwesome that's not in the icon list. Can use <see cref="FontAwesomeIcons" /> to source them.
        /// </summary>
        [Parameter]
        public string? CustomIcon { get; set; }

        /// <summary>IconType enumeration requesting a specific</summary>
        [Parameter]
        public s.IconType I { get; set; }

        /// Get
        /// <see cref="IconData" />
        /// about an icon, including its display name, the classes, etc.
        /// <param name="customIcon">The custom icon classes to use.</param>
        /// <param name="name">Get the name</param>
        /// <returns><inheritdoc cref="IconData" /></returns>
        public static IconData Get(string customIcon, string name)
            => GetIcon(customIcon, name);

        /// <summary>Get <see cref="IconData" /> about an icon, including its display name, the classes, etc.</summary>
        /// <param name="type">The icon to retrieve.</param>
        /// <returns><inheritdoc cref="IconData" /></returns>
        /// <exception cref="ArgumentOutOfRangeException">If unsupported icon type is requested. Basically anything not fontawesome.</exception>
        public static IconData Get(IconType type)
        {
            return type switch
            {
                IconType.About => GetIcon(fa.InfoCircle, IconType.About),
                IconType.Add => GetIcon(fa.Plus, IconType.Add),
                IconType.Affiliation => GetIcon(fa.Handshake, IconType.Affiliation),
                IconType.Agriculture => GetIcon(fa.Tractor, IconType.Agriculture),
                IconType.Amend => GetIcon(fa.UserEdit, IconType.Amend),
                IconType.Analytics => GetIcon(fa.ProjectDiagram, IconType.Analytics),
                IconType.Apple => GetIcon(fa.AppleAlt, IconType.Apple),
                IconType.Arctic => GetIcon(fa.Skating, IconType.Arctic),
                IconType.Art => GetIcon(fa.Palette, IconType.Art),
                IconType.Back => GetIcon(fa.ArrowLeft, IconType.Back),
                IconType.Beach => GetIcon(fa.UmbrellaBeach, IconType.Beach),
                IconType.Blog => GetIcon(fa.Bullhorn, IconType.Blog),
                IconType.Bird => GetIcon(fa.Dove, IconType.Bird),
                IconType.Birthday => GetIcon(fa.BirthdayCake, IconType.Birthday),
                IconType.Branch => GetIcon("fab fa-pagelines", IconType.Branch),
                IconType.Building => GetIcon(fa.Building, IconType.Building),
                IconType.Calendar => GetIcon(fa.CalendarDay, IconType.Calendar),
                IconType.Cancel => GetIcon(fa.Times, IconType.Cancel),
                IconType.Career => GetIcon(fa.GraduationCap, IconType.Career),
                IconType.ChartArea => GetIcon(fa.ChartArea, "Area Chart", null, IconStyle.Solid),
                IconType.ChartBar => GetIcon(fa.ChartBar, "Bar Chart", null, IconStyle.Solid),
                IconType.ChartLine => GetIcon(fa.ChartLine, "Line Chart", null, IconStyle.Solid),
                IconType.ChartPie => GetIcon(fa.ChartPie, "Pie Chart", null, IconStyle.Solid),
                IconType.Check => GetIcon(fa.Check, IconType.Check),
                IconType.Checklist => GetIcon(fa.Tasks, IconType.Checklist),
                IconType.Circle => GetIcon(fa.Circle, IconType.Circle),
                IconType.City => GetIcon(fa.City, IconType.City),
                IconType.CityChicago => GetIcon(fa.PizzaSlice, "Chicago", null, IconStyle.Solid),
                IconType.CityNewYork => GetIcon(fa.City, "New York", null, IconStyle.Solid),
                IconType.Comments => GetIcon(fa.Comments, IconType.Comments),
                IconType.Commercial => GetIcon(fa.MoneyBillWave, IconType.Commercial),
                IconType.ContactCard => GetIcon(fa.AddressCard, IconType.ContactCard),
                IconType.Create => GetIcon(fa.Plus, IconType.Create),
                IconType.Customer => GetIcon(fa.Building, IconType.Customer),
                IconType.Dashboard => GetIcon(fa.TachometerAlt, IconType.Dashboard),
                IconType.Database => GetIcon(fa.Database, IconType.Database),
                IconType.Delete => GetIcon(fa.Times, IconType.Delete),
                IconType.Democrat => GetIcon(fa.Democrat, IconType.Democrat),
                IconType.Desert => GetIcon(fa.Sun, IconType.Desert),
                IconType.Details => GetIcon(fa.ClipboardList, IconType.Details),
                IconType.Dislike => GetIcon(fa.ThumbsDown, IconType.Dislike),
                IconType.Dollar => GetIcon(fa.DollarSign, IconType.Dollar),
                IconType.Download => GetIcon(fa.Download, IconType.Download),
                IconType.Edit => GetIcon(fa.Pen, IconType.Edit),
                IconType.Email => GetIcon(fa.Envelope, IconType.Email),
                IconType.EmojiWinkHeart => GetIcon(fa.KissWinkHeart, "Wink", null, IconStyle.Solid),
                IconType.End => GetIcon(fa.HourglassEnd, IconType.End),
                IconType.Facebook => GetIcon("fab fa-facebook-f", "Facebook"),
                IconType.Fish => GetIcon(fa.Fish, IconType.Fish),
                IconType.FlagUSA => GetIcon(fa.FlagUsa, "United States", null, IconStyle.Solid),
                IconType.Flower => GetIcon(fa.Seedling, IconType.Flower),
                IconType.Fruit => GetIcon(fa.Lemon, IconType.Fruit),
                IconType.Glasses => GetIcon(fa.Glasses, IconType.Glasses),
                IconType.Glossary => GetIcon(fa.Book, IconType.Glossary),
                IconType.Government => GetIcon(fa.Landmark, IconType.Government),
                IconType.Hospitality => GetIcon(fa.Hotel, IconType.Hospitality),
                IconType.Igloo => GetIcon(fa.Igloo, IconType.Igloo),
                IconType.Image => GetIcon(fa.Image, IconType.Image),
                IconType.Incoming => GetIcon(fa.LongArrowAltLeft, "Arrow Left", null, IconStyle.Solid),
                IconType.Independent => GetIcon(fa.Dove, IconType.Independent),
                IconType.Info => GetIcon(fa.InfoCircle, IconType.Info),
                IconType.Landmark => GetIcon(fa.Archway, IconType.Landmark),
                IconType.Leaf => GetIcon(fa.Leaf, IconType.Leaf),
                IconType.Legislation => GetIcon(fa.Atlas, IconType.Legislation),
                IconType.Letter => GetIcon(fa.Envelope, IconType.Letter),
                IconType.Libertarian => GetIcon(fa.FeatherAlt, IconType.Libertarian),
                IconType.Like => GetIcon(fa.ThumbsUp, IconType.Like),
                IconType.Loading => GetIcon(fa.Spinner, "Loading", "ba-loading-subtle og-color-primary", IconStyle.Solid),
                IconType.LoadingFullPage => GetIcon(fa.Spinner, "Loading", "ba-loading-default og-color-primary", IconStyle.Solid),
                IconType.Lobbying => GetIcon(fa.Handshake, IconType.Lobbying),
                IconType.Locked => GetIcon(fa.Lock, IconType.Locked),
                IconType.Love => GetIcon(fa.Heart, IconType.Love),
                IconType.Map => GetIcon(fa.Map, IconType.Map),
                IconType.MembershipType => GetIcon(fa.DollarSign, IconType.MembershipType),
                IconType.MessageOpen => GetIcon(fa.EnvelopeOpenText, "Read", null, IconStyle.Solid),
                IconType.Money => GetIcon(fa.MoneyBill, IconType.Money),
                IconType.Mountains => GetIcon(fa.Mountain, IconType.Mountains),
                IconType.Name => GetIcon(fa.Signature, IconType.Name),
                IconType.Neighborhood => GetIcon(fa.PeopleCarry, IconType.Neighborhood),
                IconType.Newspaper => GetIcon(fa.Newspaper, IconType.Newspaper, null, IconStyle.Regular),
                IconType.NonProfit => GetIcon(fa.Peace, IconType.NonProfit),
                IconType.NotifDaily => GetIcon(fa.CalendarDay, "Notify Daily", null, IconStyle.Solid),
                IconType.Notification => GetIcon(fa.Bell, IconType.Notification),
                IconType.NotifImmediately => GetIcon(fa.Exclamation, "Notify Immediately", null, IconStyle.Solid),
                IconType.NotifNever => GetIcon(fa.BellSlash, "Notify Never", null, IconStyle.Solid),
                IconType.NotifWeekly => GetIcon(fa.CalendarWeek, "Notify Weekly", null, IconStyle.Solid),
                IconType.Null => GetIcon("", " No Icon "),
                IconType.Outdoors => GetIcon(fa.Hiking, IconType.Outdoors),
                IconType.Outgoing => GetIcon(fa.LongArrowAltRight, "Arrow Right", null, IconStyle.Solid),
                IconType.PatternShortline => GetIcon(fa.Stream, "Pattern Shortline", null, IconStyle.Solid),
                IconType.PatternWiggles => GetIcon(fa.Braille, "Pattern Wiggles", null, IconStyle.Solid),
                IconType.Phone => GetIcon(fa.Phone, IconType.Phone),
                IconType.Pin => GetIcon(fa.MapPin, IconType.Pin),
                IconType.Planet => GetIcon(fa.Meteor, IconType.Planet),
                IconType.PostedDate => GetIcon(fa.FileAlt, "Posted On", null, IconStyle.Solid),
                IconType.Preferences => GetIcon(fa.Palette, IconType.Preferences),
                IconType.Question => GetIcon(fa.Question, IconType.Question),
                IconType.Representative => GetIcon(fa.UserTie, IconType.Representative),
                IconType.Republican => GetIcon(fa.Republican, IconType.Republican),
                IconType.Rule => GetIcon(fa.Ruler, IconType.Rule),
                IconType.Science => GetIcon(fa.Vial, IconType.Science),
                IconType.Search => GetIcon(fa.Search, IconType.Search),
                IconType.SearchData => GetIcon("fab fa-searchengin", "Search Engine"),
                IconType.Settings => GetIcon(fa.Cog, IconType.Settings),
                IconType.Shapes => GetIcon(fa.Shapes, IconType.Shapes),
                IconType.Shoes => GetIcon(fa.ShoePrints, IconType.Shoes),
                IconType.Signature => GetIcon(fa.PenFancy, IconType.Signature),
                IconType.SocialMedia => GetIcon(fa.Hashtag, "Social Media", null, IconStyle.Solid),
                IconType.Spa => GetIcon(fa.Spa, IconType.Spa),
                IconType.Space => GetIcon(fa.Meteor, IconType.Space),
                IconType.SpaceShip => GetIcon(fa.SpaceShuttle, IconType.SpaceShip),
                IconType.Start => GetIcon(fa.HourglassStart, IconType.Start),
                IconType.Sun => GetIcon(fa.Sun, IconType.Sun),
                IconType.Tags => GetIcon(fa.Tags, IconType.Tags),
                IconType.Texas => GetIcon(fa.HatCowboySide, IconType.Texas),
                IconType.Timeline => GetIcon(fa.History, IconType.Timeline),
                IconType.Tree => GetIcon(fa.Tree, IconType.Tree),
                IconType.Twitter => GetIcon("fab fa-twitter", "Twitter"),
                IconType.Undecided => GetIcon(fa.SignLanguage, IconType.Undecided),
                IconType.Undo => GetIcon(fa.UndoAlt, IconType.Undo),
                IconType.User => GetIcon(fa.User, IconType.User),
                IconType.UserRole => GetIcon(fa.UserTag, "User Tag", null, IconStyle.Solid),
                IconType.Users => GetIcon(fa.Users, IconType.Users),
                IconType.UserSettings => GetIcon(fa.UserCog, "Settings Personal", null, IconStyle.Solid),
                IconType.Verified => GetIcon(fa.Certificate, IconType.Verified),
                IconType.Video => GetIcon(fa.Video, IconType.Video),
                IconType.Visualizations => GetIcon(fa.Eye, IconType.Visualizations),
                IconType.Water => GetIcon(fa.Water, IconType.Water),
                IconType.Website => GetIcon(fa.Wifi, IconType.Website),
                _ => throw new ArgumentOutOfRangeException(nameof(type), "Unexpected Icon Type"),
            };
        }

        /// <inheritdoc />
        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            if (!string.IsNullOrEmpty(CustomIcon))
                customIconString = CustomIcon;
        }

        private static IconData GetIcon(string icon, string name, string? additionalClasses = null, IconStyle? style = null)
        {
            string classes = GetIconClasses(icon, additionalClasses, style);
            return new IconData(classes, name);
        }

        private static IconData GetIcon(string icon, IconType type, string? additionalClasses = null, IconStyle? style = IconStyle.Solid)
        {
            string classes = GetIconClasses(icon, additionalClasses, style);
            return new IconData(classes, type.ToString(), type);
        }

        private static string GetIconClasses(string icon, string? additionalClasses = null, IconStyle? style = IconStyle.Solid)
        {
            if (style.HasValue)
            {
                return style.Value switch
                {
                    IconStyle.Solid => $"fas {icon} {additionalClasses}",
                    IconStyle.Regular => $"far {icon} {additionalClasses}",
                    _ => throw new ArgumentOutOfRangeException(nameof(style), "Unexpected IconStyle"),
                };
            }
            else
            {
                return $"{icon} {additionalClasses}";
            }
        }
    }
}
