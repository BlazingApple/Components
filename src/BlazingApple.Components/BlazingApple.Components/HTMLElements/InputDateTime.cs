﻿using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace BlazingApple.Components.HTMLElements;

/// <summary>Dropdown for selecting a DateTime value.</summary>
/// <typeparam name="TValue">The type of DateTime object, <see cref="DateTime" /> or <see cref="DateTimeOffset" /></typeparam>
public partial class InputDateTime<TValue> : InputDate<TValue>
{
	private const string DateFormat = "yyyy-MM-ddTHH:mm";

	/// <inheritdoc />
	protected override void BuildRenderTree(RenderTreeBuilder builder)
	{
		builder.OpenElement(0, "input");
		builder.AddMultipleAttributes(1, AdditionalAttributes);
		builder.AddAttribute(2, "type", "datetime-local");
		builder.AddAttribute(3, "class", CssClass);
		builder.AddAttribute(4, "value", BindConverter.FormatValue(CurrentValueAsString));
		builder.AddAttribute(5, "onchange", EventCallback.Factory.CreateBinder<string>(this, __value => CurrentValueAsString = __value, existingValue: CurrentValueAsString!));
		builder.CloseElement();
	}

	/// <inheritdoc />
	protected override string FormatValueAsString(TValue? value)
	{
		return value switch
		{
			DateTime dateTimeValue => BindConverter.FormatValue(dateTimeValue, DateFormat, CultureInfo.InvariantCulture),
			DateTimeOffset dateTimeOffsetValue => BindConverter.FormatValue(dateTimeOffsetValue, DateFormat, CultureInfo.InvariantCulture),
			_ => string.Empty,// Handles null for Nullable<DateTime>, etc.
		};
	}

	/// <inheritdoc />
	protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
	{
		// Unwrap nullable types. We don't have to deal with receiving empty values for nullable types here, because the underlying InputBase already
		// covers that.
		var targetType = Nullable.GetUnderlyingType(typeof(TValue)) ?? typeof(TValue);

		bool success;
		if (targetType == typeof(DateTime))
		{
			success = TryParseDateTime(value, out result);
		}
		else if (targetType == typeof(DateTimeOffset))
		{
			success = TryParseDateTimeOffset(value, out result);
		}
		else
		{
			throw new InvalidOperationException($"The type '{targetType}' is not a supported date type.");
		}

		if (success)
		{
			validationErrorMessage = null;
			if (result is null)
				throw new ArgumentOutOfRangeException(nameof(result));

			return true;
		}
		else
		{
			validationErrorMessage = string.Format(ParsingErrorMessage, FieldIdentifier.FieldName);
			return false;
		}
	}

	private static bool TryParseDateTime(string? value, [MaybeNullWhen(false)] out TValue? result)
	{
		var success = BindConverter.TryConvertToDateTime(value, CultureInfo.InvariantCulture, DateFormat, out var parsedValue);
		if (success)
		{
			result = (TValue)(object)parsedValue;
			return true;
		}
		else
		{
			result = default;
			return false;
		}
	}

	private static bool TryParseDateTimeOffset(string? value, [MaybeNullWhen(false)] out TValue? result)
	{
		var success = BindConverter.TryConvertToDateTimeOffset(value, CultureInfo.InvariantCulture, DateFormat, out var parsedValue);
		if (success)
		{
			result = (TValue)(object)parsedValue;
			return true;
		}
		else
		{
			result = default;
			return false;
		}
	}
}
