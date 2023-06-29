using BlazingAppleConsumer.Components.Data;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace BlazingAppleConsumer.Components.Pages.Forms;

public partial class FormPage : ComponentBase
{
	private List<DisplayValuePair<UserRole>> _roleOptions = null!;

	/// <summary>The model holding all the properties for the form fields.</summary>
	private FormModel? Model { get; set; }

	private List<UserRole>? SelectedRoles { get; set; }

	/// <inheritdoc />
	[MemberNotNull(nameof(_roleOptions))]
	protected override void OnInitialized()
	{
		base.OnInitialized();

		Model ??= new FormModel()
		{
			Roles = new List<UserRole>(),
		};

		SelectedRoles = Model.Roles;

		Validate();

		_roleOptions = new List<DisplayValuePair<UserRole>>();

		UserRole[] enumVals = (UserRole[])Enum.GetValues(typeof(UserRole));
		foreach (UserRole enumValue in enumVals)
		{
			DisplayValuePair<UserRole> listValue = new(enumValue.ToString(), enumValue);

			_roleOptions.Add(listValue);
		}

		_roleOptions.Sort();
	}

	/// <summary>Validate the state of the component.</summary>
	/// <exception cref="ArgumentNullException">Thrown if data is missing.</exception>
	[MemberNotNull(nameof(Model))]
	[MemberNotNull(nameof(SelectedRoles))]
	protected void Validate()
	{
		if (Model is null)
		{
			throw new ArgumentNullException(nameof(Model));
		}

		if (SelectedRoles is null)
		{
			throw new ArgumentNullException(nameof(SelectedRoles));
		}
	}

	private void OnChange(object? sender, EventArgs args)
	{
		Validate();
		Model.Roles = SelectedRoles;
	}

	private enum UserRole
	{
		Basic,
		Admin,
		Owner
	}

	private class FormModel
	{
		public List<UserRole>? Roles { get; set; }

		public UserRole SelectedRole { get; set; }
		public UserRole SelectedRole2 { get; set; }
		public UserRole SelectedRole3 { get; set; }
	}
}
