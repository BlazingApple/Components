using BlazingApple.Components.Shared.Interfaces.Search;
using System.ComponentModel;

namespace BlazingApple.Components.Shared.Models.Search
{
	public interface ISearchRequest<TFilter> where TFilter : class, IFilter, new()
	{
		TFilter Filter { get; init; }
		int Skip { get; init; }
		ListSortDirection SortDirection { get; init; }
		int Take { get; init; }

		bool IsEmpty();
	}
}