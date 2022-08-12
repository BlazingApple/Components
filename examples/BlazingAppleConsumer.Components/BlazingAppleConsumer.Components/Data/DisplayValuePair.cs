using BlazingAppleConsumer.Components.Data.Base;

namespace BlazingAppleConsumer.Components.Data
{
    /// <summary>
    ///     Used on components like a checkbox, where we display the <see cref="Text" /> property, and the backing value is the <see cref="Value" /> property.
    /// </summary>
    /// <typeparam name="TValue">The value type of the value pair.</typeparam>
    public class DisplayValuePair<TValue> : ComparableModelBase<DisplayValuePair<TValue>, TValue>
    {
        /// <summary>Display text.</summary>
        public string Text { get; }

        /// <summary>The display value</summary>
        public TValue Value { get; }

        /// <summary>Populates the necessary properties.</summary>
        public DisplayValuePair(string text, TValue value)
        {
            Text = text;
            Value = value;
        }

        /// <inheritdoc />
        public override string? ToString() => Value.ToString();

        /// <inheritdoc />
        protected override TValue GetKeyValue() => Value;
    }
}
