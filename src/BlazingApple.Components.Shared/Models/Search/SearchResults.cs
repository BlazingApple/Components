using BlazingApple.Components.Shared.Interfaces.Search;

namespace BlazingApple.Components.Shared.Models.Search;


/// <inheritdoc cref="ISearchResults{T}"/>
internal class SearchResults<T> : ISearchResults<T>
{
	/// <summary>The list of search results.</summary>
	public IReadOnlyList<T> Results { get; set; } = null!;

	/// <summary>Whether or not the search results supports pagination.</summary>
	public bool SupportsPagination { get; set; }

	/// <summary>
	///     The number of total results for the current search. This is <em>not</em> how many results are returned in the <see cref="Results" /> property.
	/// </summary>
	public int TotalResults { get; set; }

	/// <summary>Serialization constructor.</summary>
	public SearchResults()
	{ }

	/// <summary>Default constructor</summary>
	/// <param name="results">The list of search results.</param>
	/// <param name="totalResults">The total number of results</param>
	private SearchResults(IReadOnlyList<T> results, int totalResults)
	{
		Results = results;
		TotalResults = totalResults;
		SupportsPagination = true;
	}

	/// <summary>Transform a <see cref="IReadOnlyList{T}"/> into an unpaginated <see cref="SearchResults{T}"/></summary>
	/// <param name="source">The search results.</param>
	/// <returns><see cref="SearchResults{T}"/></returns>
	public static SearchResults<T> Create(IReadOnlyList<T> source)
	{
		SearchResults<T> results = new(source, source.Count)
		{
			SupportsPagination = false,
		};
		return results;
	}

	/// <summary>Transform a <see cref="IReadOnlyList{T}"/> into a paginated <see cref="SearchResults{T}"/></summary>
	/// <param name="source">Query source</param>
	/// <param name="skip"><see cref="SearchRequest{TFilter}.Skip"/></param>
	/// <param name="take"><see cref="SearchRequest{TFilter}.Take"/></param>
	/// <returns><see cref="SearchResults{T}"/></returns>
	public static SearchResults<T> Create(IReadOnlyList<T> source, int skip, int take)
	{
		List<T>? resultsForThisSearch = source
			.Skip(skip)
			.Take(take)
			.ToList();

		SearchResults<T> results = new(resultsForThisSearch, source.Count);
		return results;
	}

	/// <summary>Transform the result type to <typeparamref name="TResult"/></summary>
	/// <typeparam name="TResult">Result type</typeparam>
	/// <param name="selector">Function to transform a <typeparamref name="T"/> into a <typeparamref name="TResult"/></param>
	/// <returns><see cref="SearchResults{T}"/></returns>
	public SearchResults<TResult> Select<TResult>(Func<T, TResult> selector)
	{
		IReadOnlyList<TResult> newResults = SelectList(Results, selector);
		return new SearchResults<TResult>(newResults, TotalResults)
		{
			SupportsPagination = SupportsPagination,
		};
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"{Results.Count} results.";

	private static List<TItem> SelectList<TItem, TSource>(IReadOnlyList<TSource>? sourceList, Func<TSource, TItem> convertValue)
	{
		if (sourceList is null || sourceList.Count == 0)
			return new List<TItem>();

		List<TItem> mappedList = new(sourceList.Count);
		foreach (TSource sourceItem in sourceList)
		{
			TItem mappedItem = convertValue(sourceItem);
			mappedList.Add(mappedItem);
		}

		return mappedList;
	}
}
