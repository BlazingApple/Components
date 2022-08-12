namespace BlazingAppleConsumer.Components.Data.Base
{
    /// <summary>Default implementation of <see cref="IComparable{T}" /></summary>
    /// <typeparam name="TModel">The model type to compare against.</typeparam>
    /// <typeparam name="TKey">The type of the key member.</typeparam>
    public abstract class ComparableModelBase<TModel, TKey> : IComparable<ComparableModelBase<TModel, TKey>>
        where TModel : ComparableModelBase<TModel, TKey>
    {
        public static bool operator !=(ComparableModelBase<TModel, TKey>? left, ComparableModelBase<TModel, TKey>? right)
            => !(left == right);

        public static bool operator <(ComparableModelBase<TModel, TKey> left, ComparableModelBase<TModel, TKey> right)
            => left.CompareTo(right) < 0;

        public static bool operator <=(ComparableModelBase<TModel, TKey> left, ComparableModelBase<TModel, TKey> right)
            => left.CompareTo(right) <= 0;

        public static bool operator ==(ComparableModelBase<TModel, TKey>? left, ComparableModelBase<TModel, TKey>? right)
                    => left?.Equals(right) ?? right is null;

        public static bool operator >(ComparableModelBase<TModel, TKey> left, ComparableModelBase<TModel, TKey> right)
                => left.CompareTo(right) > 0;

        public static bool operator >=(ComparableModelBase<TModel, TKey> left, ComparableModelBase<TModel, TKey> right)
                => left.CompareTo(right) >= 0;

        /// <inheritdoc cref="IComparable{T}" />
        public int CompareTo(ComparableModelBase<TModel, TKey>? other)
        {
            if (other is null)
                return 1;
            else if (GetKeyValue() is Enum enumValue)
                return enumValue.CompareTo(other.GetKeyValue());
            else if (GetKeyValue() is IComparable<TKey> key)
                return key.CompareTo(other.GetKeyValue());
            else
                throw new ArgumentOutOfRangeException(nameof(other), "Unsupported value type provided");
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            else if (obj is not ComparableModelBase<TModel, TKey> other)
                return false;
            else
                return GetKeyValue()!.Equals(other.GetKeyValue());
        }

        /// <inheritdoc />
        public override int GetHashCode()
            => GetKeyValue()?.GetHashCode() ?? 0;

        /// <summary>Expression to provide the sort by property.</summary>
        /// <returns>Returns the member to use in the compare to.</returns>
        protected abstract TKey GetKeyValue();
    }
}
