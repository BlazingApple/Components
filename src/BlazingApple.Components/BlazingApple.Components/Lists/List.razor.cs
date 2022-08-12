using BlazingApple.Components.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazingApple.Components.Lists;

/// <summary></summary>
public partial class List : ComponentBase
{
    private Type _listType = null!;

    private PropertyInfo[] _properties = null!;

    private string recordActionRouteString = string.Empty;

    /// <summary>The list of items to render</summary>
    [Parameter, EditorRequired]
    public List<dynamic> list { get; set; } = null!;

    /// <summary>
    ///     This only needs to be populated if ShowAdminLinks is set to true. Used to send a request to the server to get or delete an object.
    /// </summary>
    [Parameter]
    public string? Route { get; set; }

    /// <summary>Whether to show the Edit/Details/Delete buttons at the end of each row.</summary>
    [Parameter]
    public bool ShowAdminLinks { get; set; } = false; // TODO: Should this just be built in looking at the user?

    /// <inheritdoc />
    protected override void OnParametersSet()
    {
        if (list == null)
        {
            return;
        }
        _listType = list.GetType().GetGenericTypeDefinition();
        _properties = _listType.GetProperties();
        if (ShowAdminLinks)
        {
            recordActionRouteString = "/" + Route;
        }
    }

    /// <summary>Send a web request to delete a record.</summary>
    /// <param name="id">The id to send to the platform to delete.</param>
    private async void DeleteRecord(string id)
    {
        HttpResponseMessage response = await Http.DeleteAsync("api/" + Route + "/" + id);
        if (response.IsSuccessStatusCode)
        {
            list.RemoveAll(obj => obj.Id.ToString() == id);
            this.StateHasChanged();
        }
        else
        {
            ToastService.ShowError(ResponseError.GetResponse(ResponseError.ErrorType.ServerError));
        }
    }
}
