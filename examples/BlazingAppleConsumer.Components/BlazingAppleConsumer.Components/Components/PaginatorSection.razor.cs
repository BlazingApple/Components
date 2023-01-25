using BlazingApple.Components.Services;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Components.Components;

public partial class PaginatorSection : ComponentBase
{
	private int _currentPage = 0;
	private int _resultCount = 500;
}
