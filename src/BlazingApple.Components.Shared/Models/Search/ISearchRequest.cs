using BlazingApple.Components.Shared.Interfaces.Search;
using System.ComponentModel;

namespace BlazingApple.Components.Shared.Models.Search
{
	/// <summary>Data model used in requesting data from the server.</summary>
	public interface ISearchRequest<TFilter> where TFilter : class, IFilter, new()
	{
		/// <inheritdoc cref="IFilter"/>
		TFilter Filter { get; init; }

		/// <summary>How many models to skip.</summary>
		int Skip { get; init; }

		/// <inheritdoc cref="ListSortDirection"/>
		ListSortDirection SortDirection { get; init; }

		/// <summary>How many models to retrieve.</summary>
		int Take { get; init; }

		/// <summary>
		/// 	<c>True</c> if <see cref="Filter"/> is empty, and <see cref="SortDirection"/> is <see cref="ListSortDirection.Ascending"/>.
		/// </summary>
		/// <returns>Whether request is empty.</returns>
		bool IsEmpty();
	}
}