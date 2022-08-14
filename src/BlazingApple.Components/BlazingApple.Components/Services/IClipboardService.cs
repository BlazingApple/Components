namespace BlazingApple.Components.Services
{
    /// <summary>Programmatically copy text to the clipboard.</summary>
    public interface IClipboardService
    {
        /// <summary>Copy text to the clipboard.</summary>
        /// <param name="text">The text to copy.</param>
        /// <returns>Async op.</returns>
        Task CopyToClipboard(string text);
    }
}
