using BlazingApple.FontAwesome.Models;
using BlazingApple.FontAwesome.Services;
using Microsoft.AspNetCore.Components;

namespace BlazingAppleConsumer.Components.Pages
{
    /// <summary>The code behind for the home page.</summary>
    public partial class Index : ComponentBase
    {
        private int _currentPage = 0;
        private int _resultCount = 500;
        private string _textToCopy = "You didn't type anything!";
    }
}
