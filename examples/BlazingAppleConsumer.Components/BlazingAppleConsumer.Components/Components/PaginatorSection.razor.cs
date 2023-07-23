using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Components.Components;

public partial class PaginatorSection : ComponentBase
{
	private int _currentPage = 0;
	private int _resultCount = 500;
	private int _batchSize = 25;
}
