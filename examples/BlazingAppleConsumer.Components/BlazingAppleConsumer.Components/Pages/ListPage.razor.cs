using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace BlazingAppleConsumer.Components.Pages;

/// <summary>Shows various list components.</summary>
public partial class ListPage : ComponentBase
{
    private int _itemCount = 5;

    [Range(1, 4)]
    public int ColumnCount { get; set; } = 3;

    [Range(1, 100)]
    public int ItemCount { get; set; } = 5;

    private List<int>? _items;

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _items = [];

        for (int i = 0; i < 100; i++)
        {
            _items.Add(i);
        }
    }
}
