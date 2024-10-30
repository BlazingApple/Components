using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.JSInterop;
using System.Globalization;
using System.Text.Json;

namespace BlazingApple.Components;

/// <summary>Downloads an arbitrary data payload.</summary>
public partial class DownloadDataButton : ComponentBase
{
    private static readonly JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
    };

    /// <summary>Data to download.</summary>
    [Parameter]
    public object? Data { get; set; }

    /// <summary>The file name to write.</summary>
    [Parameter, EditorRequired]
    public string? Filename { get; set; }

    /// <summary>The format of the download. Defaults to JSON.</summary>
    [Parameter]
    public DownloadFormat Format { get; set; }

    /// <inheritdoc cref="HttpClient" />
    [Inject]
    public HttpClient Http { get; set; } = null!;

    /// <inheritdoc cref="IJSRuntime" />
    [Inject]
    public IJSRuntime JSRuntime { get; set; } = null!;

    /// <summary>Provide this instead of data if it is desired that the server serialize to a string and that be written to file.</summary>
    [Parameter]
    public string? ServerRoute { get; set; }

    /// <summary>This should probably go to a shared location....But will do at a later date when needed elsewhere.</summary>
    /// <param name="js">The JSRuntime.</param>
    /// <param name="filename">the file name to download as.</param>
    /// <param name="data">The byte data to download.</param>
    /// <returns>Task representing Async operation.</returns>
    public static async Task SaveAs(IJSRuntime js, string filename, string data)
    {
        await js.InvokeAsync<object>(
            "saveAsFile",
            filename,
            data);
    }

    private static string GetCsvData(object downloadObject)
    {
        using MemoryStream stream = new();
        using StreamReader reader = new(stream);
        using StreamWriter writer = new(stream);
        using CsvWriter csv = new(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = false,
            IgnoreReferences = true,
            IgnoreBlankLines = true,
        });

        if (downloadObject is IEnumerable<object> objectList)
        {
            csv.WriteRecords(objectList);
        }
        else
        {
            csv.WriteRecord(downloadObject);
        }

        writer.Flush();
        stream.Position = 0;
        string text = reader.ReadToEnd();

        return text;
    }

    private static string GetJsonData(object downloadObject)
    {
        string userData = JsonSerializer.Serialize(downloadObject, _options);
        return userData;
    }

    private async Task OnDownloadClick()
    {
        if (Data is null && string.IsNullOrEmpty(ServerRoute))
        {
            throw new InvalidOperationException("DataToDownload is null");
        }
        else if (Data is not null || !string.IsNullOrEmpty(ServerRoute))
        {
            string file = Format switch
            {
                DownloadFormat.Json => $"{Filename}.json",
                DownloadFormat.Csv => $"{Filename}.csv",
                DownloadFormat.Ics => $"{Filename}.ics",
                _ => throw new ArgumentOutOfRangeException("Unexpected Format"),
            };

            string data = "";
            if (!string.IsNullOrEmpty(ServerRoute))
            {
                data = await Http.GetStringAsync(ServerRoute);
            }
            else if (Data is not null)
            {
                data = Format switch
                {
                    DownloadFormat.Json => GetJsonData(Data),
                    DownloadFormat.Csv => GetCsvData(Data),
                    DownloadFormat.Ics => (string)Data,
                    _ => throw new ArgumentOutOfRangeException("Unexpected Format"),
                };
            }

            await SaveAs(JSRuntime, file, data);
        }
    }
}

/// <summary>The format of the data to download.</summary>
public enum DownloadFormat
{
    /// <summary>Javascript object notation</summary>
    Json,
    /// <summary>Comma-separated values</summary>
    Csv,
    /// <summary>Mail event</summary>
    Ics,
}
