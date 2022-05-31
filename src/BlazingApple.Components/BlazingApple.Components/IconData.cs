using BlazingApple.Components.Services;
using BlazingApple.FontAwesome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components
{
    /// <summary>Holds data about an icon displayed on the page.</summary>
    public class IconData : IEquatable<IconData>, IComparable<IconData>
    {
        /// <summary>The resulting class name used to generate the Icon.</summary>
        public string IconClasses { get; }

        /// <summary>The "Display Name" of the icon.</summary>
        public string Name { get; }

        /// <summary>If the icon isn't a "custom" type, what was the <see cref="IconType" /> type</summary>
        public IconType? Source { get; }

        /// <summary>Constructor.</summary>
        /// <param name="icon">The icon classes to apply</param>
        /// <param name="iconName">The icon's display name</param>
        /// <param name="source">The source type, if exists.</param>
        public IconData(string icon, string iconName, IconType? source = null)
        {
            IconClasses = icon;
            Name = iconName;
            Source = source;
        }

        /// <summary>Copies the icon data from a <see cref="FontAwesomeIcon" />.</summary>
        /// <param name="copy">The object to copy from.</param>
        public IconData(FontAwesomeIcon copy)
            : this(copy.GetCode(), copy.Label!)
        { }

        /// <inheritdoc />
        public static bool operator !=(IconData? left, IconData? right)
                        => !(left == right);

        /// <inheritdoc />
        public static bool operator <(IconData left, IconData right)
                    => left.CompareTo(right) < 0;

        /// <inheritdoc />
        public static bool operator <=(IconData left, IconData right)
                    => left.CompareTo(right) <= 0;

        /// <inheritdoc />
        public static bool operator ==(IconData? left, IconData? right)
                    => left?.Equals(right) ?? right is null;

        /// <inheritdoc />
        public static bool operator >(IconData left, IconData right)
                    => left.CompareTo(right) > 0;

        /// <inheritdoc />
        public static bool operator >=(IconData left, IconData right)
                    => left.CompareTo(right) >= 0;

        /// <inheritdoc />
        /// <exception cref="ArgumentOutOfRangeException">If the value of the key doesn't support IComparable or isn't an enum.</exception>
        public int CompareTo(IconData? other)
        {
            if (other is null)
                return 1;
            else
                return (Name, IconClasses).CompareTo((other.Name, other.IconClasses));
        }

        /// <inheritdoc />
        public bool Equals(IconData? other) => Equals((object?)other);

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            else if (obj is not IconData other)
                return false;
            else
                return Name.Equals(other.Name) && IconClasses.Equals(other.IconClasses);
        }

        /// <inheritdoc />
        public override int GetHashCode()
            => HashCode.Combine(Name, IconClasses);

        /// <inheritdoc />
        public override string ToString() => Name;
    }
}
