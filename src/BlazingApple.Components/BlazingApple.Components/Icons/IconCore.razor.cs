using BlazingApple.Components.Services;
using Blazorise;
using Blazorise.Icons.FontAwesome;

namespace BlazingApple.Components.Icons;

/// <summary>Core rendering logic for an icon.</summary>
public partial class IconCore : Icon
{
    private string? customIconString;

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (!string.IsNullOrEmpty(CustomIcon))
            customIconString = CustomIcon;
    }

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
            IconType.About => GetIcon(FontAwesomeIcons.InfoCircle, IconType.About),
            IconType.Add => GetIcon(FontAwesomeIcons.Plus, IconType.Add),
            IconType.Affiliation => GetIcon(FontAwesomeIcons.Handshake, IconType.Affiliation),
            IconType.Agriculture => GetIcon(FontAwesomeIcons.Tractor, IconType.Agriculture),
            IconType.Amend => GetIcon(FontAwesomeIcons.UserEdit, IconType.Amend),
            IconType.Analytics => GetIcon(FontAwesomeIcons.ProjectDiagram, IconType.Analytics),
            IconType.Apple => GetIcon(FontAwesomeIcons.AppleAlt, IconType.Apple),
            IconType.Arctic => GetIcon(FontAwesomeIcons.Skating, IconType.Arctic),
            IconType.Art => GetIcon(FontAwesomeIcons.Palette, IconType.Art),
            IconType.Back => GetIcon(FontAwesomeIcons.ArrowLeft, IconType.Back),
            IconType.Beach => GetIcon(FontAwesomeIcons.UmbrellaBeach, IconType.Beach),
            IconType.Blog => GetIcon(FontAwesomeIcons.Bullhorn, IconType.Blog),
            IconType.Bird => GetIcon(FontAwesomeIcons.Dove, IconType.Bird),
            IconType.Birthday => GetIcon(FontAwesomeIcons.BirthdayCake, IconType.Birthday),
            IconType.Branch => GetIcon("fab fa-pagelines", IconType.Branch),
            IconType.Building => GetIcon(FontAwesomeIcons.Building, IconType.Building),
            IconType.Calendar => GetIcon(FontAwesomeIcons.CalendarDay, IconType.Calendar),
            IconType.Cancel => GetIcon(FontAwesomeIcons.Times, IconType.Cancel),
            IconType.Career => GetIcon(FontAwesomeIcons.GraduationCap, IconType.Career),
            IconType.ChartArea => GetIcon(FontAwesomeIcons.ChartArea, "Area Chart", null, IconStyle.Solid),
            IconType.ChartBar => GetIcon(FontAwesomeIcons.ChartBar, "Bar Chart", null, IconStyle.Solid),
            IconType.ChartLine => GetIcon(FontAwesomeIcons.ChartLine, "Line Chart", null, IconStyle.Solid),
            IconType.ChartPie => GetIcon(FontAwesomeIcons.ChartPie, "Pie Chart", null, IconStyle.Solid),
            IconType.Check => GetIcon(FontAwesomeIcons.Check, IconType.Check),
            IconType.Checklist => GetIcon(FontAwesomeIcons.Tasks, IconType.Checklist),
            IconType.Circle => GetIcon(FontAwesomeIcons.Circle, IconType.Circle),
            IconType.City => GetIcon(FontAwesomeIcons.City, IconType.City),
            IconType.CityChicago => GetIcon(FontAwesomeIcons.PizzaSlice, "Chicago", null, IconStyle.Solid),
            IconType.CityNewYork => GetIcon(FontAwesomeIcons.City, "New York", null, IconStyle.Solid),
            IconType.Comments => GetIcon(FontAwesomeIcons.Comments, IconType.Comments),
            IconType.Commercial => GetIcon(FontAwesomeIcons.MoneyBillWave, IconType.Commercial),
            IconType.ContactCard => GetIcon(FontAwesomeIcons.AddressCard, IconType.ContactCard),
            IconType.Create => GetIcon(FontAwesomeIcons.Plus, IconType.Create),
            IconType.Customer => GetIcon(FontAwesomeIcons.Building, IconType.Customer),
            IconType.Dashboard => GetIcon(FontAwesomeIcons.TachometerAlt, IconType.Dashboard),
            IconType.Database => GetIcon(FontAwesomeIcons.Database, IconType.Database),
            IconType.Delete => GetIcon(FontAwesomeIcons.Times, IconType.Delete),
            IconType.Democrat => GetIcon(FontAwesomeIcons.Democrat, IconType.Democrat),
            IconType.Desert => GetIcon(FontAwesomeIcons.Sun, IconType.Desert),
            IconType.Details => GetIcon(FontAwesomeIcons.ClipboardList, IconType.Details),
            IconType.Dislike => GetIcon(FontAwesomeIcons.ThumbsDown, IconType.Dislike),
            IconType.Dollar => GetIcon(FontAwesomeIcons.DollarSign, IconType.Dollar),
            IconType.Download => GetIcon(FontAwesomeIcons.Download, IconType.Download),
            IconType.Edit => GetIcon(FontAwesomeIcons.Pen, IconType.Edit),
            IconType.Email => GetIcon(FontAwesomeIcons.Envelope, IconType.Email),
            IconType.EmojiWinkHeart => GetIcon(FontAwesomeIcons.KissWinkHeart, "Wink", null, IconStyle.Solid),
            IconType.End => GetIcon(FontAwesomeIcons.HourglassEnd, IconType.End),
            IconType.Facebook => GetIcon("fab fa-facebook-f", "Facebook"),
            IconType.Fish => GetIcon(FontAwesomeIcons.Fish, IconType.Fish),
            IconType.FlagUSA => GetIcon(FontAwesomeIcons.FlagUsa, "United States", null, IconStyle.Solid),
            IconType.Flower => GetIcon(FontAwesomeIcons.Seedling, IconType.Flower),
            IconType.Fruit => GetIcon(FontAwesomeIcons.Lemon, IconType.Fruit),
            IconType.Glasses => GetIcon(FontAwesomeIcons.Glasses, IconType.Glasses),
            IconType.Glossary => GetIcon(FontAwesomeIcons.Book, IconType.Glossary),
            IconType.Government => GetIcon(FontAwesomeIcons.Landmark, IconType.Government),
            IconType.Hospitality => GetIcon(FontAwesomeIcons.Hotel, IconType.Hospitality),
            IconType.Igloo => GetIcon(FontAwesomeIcons.Igloo, IconType.Igloo),
            IconType.Image => GetIcon(FontAwesomeIcons.Image, IconType.Image),
            IconType.Incoming => GetIcon(FontAwesomeIcons.LongArrowAltLeft, "Arrow Left", null, IconStyle.Solid),
            IconType.Independent => GetIcon(FontAwesomeIcons.Dove, IconType.Independent),
            IconType.Info => GetIcon(FontAwesomeIcons.InfoCircle, IconType.Info),
            IconType.Landmark => GetIcon(FontAwesomeIcons.Archway, IconType.Landmark),
            IconType.Leaf => GetIcon(FontAwesomeIcons.Leaf, IconType.Leaf),
            IconType.Legislation => GetIcon(FontAwesomeIcons.Atlas, IconType.Legislation),
            IconType.Letter => GetIcon(FontAwesomeIcons.Envelope, IconType.Letter),
            IconType.Libertarian => GetIcon(FontAwesomeIcons.FeatherAlt, IconType.Libertarian),
            IconType.Like => GetIcon(FontAwesomeIcons.ThumbsUp, IconType.Like),
            IconType.Loading => GetIcon(FontAwesomeIcons.Spinner, "Loading", "ba-loading-subtle og-color-primary", IconStyle.Solid),
            IconType.LoadingFullPage => GetIcon(FontAwesomeIcons.Spinner, "Loading", "ba-loading-default og-color-primary", IconStyle.Solid),
            IconType.Lobbying => GetIcon(FontAwesomeIcons.Handshake, IconType.Lobbying),
            IconType.Locked => GetIcon(FontAwesomeIcons.Lock, IconType.Locked),
            IconType.Love => GetIcon(FontAwesomeIcons.Heart, IconType.Love),
            IconType.Map => GetIcon(FontAwesomeIcons.Map, IconType.Map),
            IconType.MembershipType => GetIcon(FontAwesomeIcons.DollarSign, IconType.MembershipType),
            IconType.MessageOpen => GetIcon(FontAwesomeIcons.EnvelopeOpenText, "Read", null, IconStyle.Solid),
            IconType.Money => GetIcon(FontAwesomeIcons.MoneyBill, IconType.Money),
            IconType.Mountains => GetIcon(FontAwesomeIcons.Mountain, IconType.Mountains),
            IconType.Name => GetIcon(FontAwesomeIcons.Signature, IconType.Name),
            IconType.Neighborhood => GetIcon(FontAwesomeIcons.PeopleCarry, IconType.Neighborhood),
            IconType.Newspaper => GetIcon(FontAwesomeIcons.Newspaper, IconType.Newspaper, null, IconStyle.Regular),
            IconType.NonProfit => GetIcon(FontAwesomeIcons.Peace, IconType.NonProfit),
            IconType.NotifDaily => GetIcon(FontAwesomeIcons.CalendarDay, "Notify Daily", null, IconStyle.Solid),
            IconType.Notification => GetIcon(FontAwesomeIcons.Bell, IconType.Notification),
            IconType.NotifImmediately => GetIcon(FontAwesomeIcons.Exclamation, "Notify Immediately", null, IconStyle.Solid),
            IconType.NotifNever => GetIcon(FontAwesomeIcons.BellSlash, "Notify Never", null, IconStyle.Solid),
            IconType.NotifWeekly => GetIcon(FontAwesomeIcons.CalendarWeek, "Notify Weekly", null, IconStyle.Solid),
            IconType.Null => GetIcon("", " No Icon "),
            IconType.Outdoors => GetIcon(FontAwesomeIcons.Hiking, IconType.Outdoors),
            IconType.Outgoing => GetIcon(FontAwesomeIcons.LongArrowAltRight, "Arrow Right", null, IconStyle.Solid),
            IconType.PatternShortline => GetIcon(FontAwesomeIcons.Stream, "Pattern Shortline", null, IconStyle.Solid),
            IconType.PatternWiggles => GetIcon(FontAwesomeIcons.Braille, "Pattern Wiggles", null, IconStyle.Solid),
            IconType.Phone => GetIcon(FontAwesomeIcons.Phone, IconType.Phone),
            IconType.Pin => GetIcon(FontAwesomeIcons.MapPin, IconType.Pin),
            IconType.Planet => GetIcon(FontAwesomeIcons.Meteor, IconType.Planet),
            IconType.PostedDate => GetIcon(FontAwesomeIcons.FileAlt, "Posted On", null, IconStyle.Solid),
            IconType.Preferences => GetIcon(FontAwesomeIcons.Palette, IconType.Preferences),
            IconType.Question => GetIcon(FontAwesomeIcons.Question, IconType.Question),
            IconType.Representative => GetIcon(FontAwesomeIcons.UserTie, IconType.Representative),
            IconType.Republican => GetIcon(FontAwesomeIcons.Republican, IconType.Republican),
            IconType.Rule => GetIcon(FontAwesomeIcons.Ruler, IconType.Rule),
            IconType.Science => GetIcon(FontAwesomeIcons.Vial, IconType.Science),
            IconType.Search => GetIcon(FontAwesomeIcons.Search, IconType.Search),
            IconType.SearchData => GetIcon("fab fa-searchengin", "Search Engine"),
            IconType.Settings => GetIcon(FontAwesomeIcons.Cog, IconType.Settings),
            IconType.Shapes => GetIcon(FontAwesomeIcons.Shapes, IconType.Shapes),
            IconType.Shoes => GetIcon(FontAwesomeIcons.ShoePrints, IconType.Shoes),
            IconType.Signature => GetIcon(FontAwesomeIcons.PenFancy, IconType.Signature),
            IconType.SocialMedia => GetIcon(FontAwesomeIcons.Hashtag, "Social Media", null, IconStyle.Solid),
            IconType.Spa => GetIcon(FontAwesomeIcons.Spa, IconType.Spa),
            IconType.Space => GetIcon(FontAwesomeIcons.Meteor, IconType.Space),
            IconType.SpaceShip => GetIcon(FontAwesomeIcons.SpaceShuttle, IconType.SpaceShip),
            IconType.Start => GetIcon(FontAwesomeIcons.HourglassStart, IconType.Start),
            IconType.Sun => GetIcon(FontAwesomeIcons.Sun, IconType.Sun),
            IconType.Tags => GetIcon(FontAwesomeIcons.Tags, IconType.Tags),
            IconType.Texas => GetIcon(FontAwesomeIcons.HatCowboySide, IconType.Texas),
            IconType.Timeline => GetIcon(FontAwesomeIcons.History, IconType.Timeline),
            IconType.Tree => GetIcon(FontAwesomeIcons.Tree, IconType.Tree),
            IconType.Twitter => GetIcon("fab fa-twitter", "Twitter"),
            IconType.Undecided => GetIcon(FontAwesomeIcons.SignLanguage, IconType.Undecided),
            IconType.Undo => GetIcon(FontAwesomeIcons.UndoAlt, IconType.Undo),
            IconType.User => GetIcon(FontAwesomeIcons.User, IconType.User),
            IconType.UserRole => GetIcon(FontAwesomeIcons.UserTag, "User Tag", null, IconStyle.Solid),
            IconType.Users => GetIcon(FontAwesomeIcons.Users, IconType.Users),
            IconType.UserSettings => GetIcon(FontAwesomeIcons.UserCog, "Settings Personal", null, IconStyle.Solid),
            IconType.Verified => GetIcon(FontAwesomeIcons.Certificate, IconType.Verified),
            IconType.Video => GetIcon(FontAwesomeIcons.Video, IconType.Video),
            IconType.Visualizations => GetIcon(FontAwesomeIcons.Eye, IconType.Visualizations),
            IconType.Water => GetIcon(FontAwesomeIcons.Water, IconType.Water),
            IconType.Website => GetIcon(FontAwesomeIcons.Wifi, IconType.Website),
            _ => throw new ArgumentOutOfRangeException(nameof(type), "Unexpected Icon Type"),
        };
    }

    private static IconData GetIcon(string icon, string name, string? additionalClasses = null, IconStyle? style = null)
    {
        string classes = GetIconClasses(icon, additionalClasses, style);
        return new IconData(classes.Trim(), name);
    }

    private static IconData GetIcon(string icon, IconType type, string? additionalClasses = null, IconStyle? style = IconStyle.Solid)
    {
        string classes = GetIconClasses(icon, additionalClasses, style);
        return new IconData(classes.Trim(), type.ToString(), type);
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
