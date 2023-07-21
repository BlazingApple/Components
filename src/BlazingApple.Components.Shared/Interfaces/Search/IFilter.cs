namespace BlazingApple.Components.Shared.Interfaces.Search;

/// <summary>Filter for searching.</summary>
public interface IFilter
{
	/// <summary>Determines whether the filter has data stored that can be used to search. If not, consumers will typically load default data.</summary>
	/// <param name="ignoreSearchString">
	///     Determines whether to ignore the search string when determining whether the Filter has discriminating data in it.
	/// </param>
	/// <returns><c>true</c> if there is *no* discriminating data, and <c>false</c> otherwise.</returns>
	bool IsEmpty(bool ignoreSearchString = false);
}
