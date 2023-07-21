using BlazingApple.Components.Shared.Interfaces.Search;
using System.ComponentModel;

namespace BlazingApple.Components.Shared.Models.Search;

/// <summary>Data model used in requesting data from the server.</summary>
internal class SearchRequest<TFilter> : ISearchRequest<TFilter> where TFilter : class, IFilter, new()
{
	/// <inheritdoc cref="Filter" />
	public TFilter Filter { get; init; }

	/// <summary>How many models to skip.</summary>
	public int Skip { get; init; }

	/// <summary>How many models to retrieve.</summary>
	public int Take { get; init; }

	/// <inheritdoc cref="ListSortDirection"/>
	public ListSortDirection SortDirection { get; init; }

	/// <summary>Constructor</summary>
	public SearchRequest(TFilter filter, int skip, int take, ListSortDirection sortDirection = ListSortDirection.Ascending)
	{
		Filter = filter;
		Skip = skip;
		Take = take;
		SortDirection = sortDirection;
	}

	/// <summary>Constructor</summary>
	public SearchRequest(TFilter filter, int loadBatchSize = 25)
	{
		Filter = filter;
		Take = loadBatchSize;
	}

	/// <summary>Default constructor.</summary>
	public SearchRequest()
		: this(new TFilter())
	{
	}

	/// <summary>
	/// 	<c>True</c> if <see cref="Filter"/> is empty, and <see cref="SortDirection"/> is <see cref="ListSortDirection.Ascending"/>.
	/// </summary>
	/// <returns>Whether request is empty.</returns>
	public bool IsEmpty()
		=> SortDirection == ListSortDirection.Ascending && Filter.IsEmpty() && Take == 0;
}
