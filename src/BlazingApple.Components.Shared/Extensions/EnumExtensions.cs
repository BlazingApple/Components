using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace BlazingApple.Components;

/// <summary>Extensions for <see cref="Enum"/></summary>
public static class EnumExtensions
{
	/// <summary>Using reflection, get the display name of the enum value.</summary>
	/// <param name="value">The enum value.</param>
	/// <returns>The <see cref="DisplayAttribute.Name" /> of the enum value.</returns>
	public static string ToDisplayName(this Enum value)
	{
		DisplayAttribute? attribute = GetAttribute<DisplayAttribute>(value);
		return attribute?.Name ?? value.ToString();
	}

	private static TAttrib? GetAttribute<TAttrib>(Enum value)
	where TAttrib : Attribute
	{
		IEnumerable<TAttrib> attributes = GetAttributes<TAttrib>(value);
		return attributes.SingleOrDefault();
	}

	private static IEnumerable<TAttrib> GetAttributes<TAttrib>(Enum value)
		where TAttrib : Attribute
	{
		Type type = value.GetType();
		string name = value.ToString();

		FieldInfo? field = type.GetField(name) ?? throw new ArgumentException("The provided value was not found", nameof(value));

		IEnumerable<TAttrib> attributes = field.GetCustomAttributes<TAttrib>(false);
		return attributes;
	}
}
