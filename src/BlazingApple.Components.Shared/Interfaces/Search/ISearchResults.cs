namespace BlazingApple.Components.Shared.Interfaces.Search;

/// <summary>A search results object, indicating if there are more results to retrieve.</summary>
/// <typeparam name="T">The model type being searched over/returned.</typeparam>
public interface ISearchResults<T>
{
	/// <summary>The list of search results.</summary>
	IReadOnlyList<T> Results { get; set; }

	/// <summary>Whether or not the search results supports pagination.</summary>
	bool SupportsPagination { get; set; }

	/// <summary>
	///     The number of total results for the current search. This is <em>not</em> how many results are returned in the <see cref="Results" /> property.
	/// </summary>
	int TotalResults { get; set; }
}