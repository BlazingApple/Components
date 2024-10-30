namespace BlazingApple.Components.Files;

/// <inheritdoc cref="IRenderableFile"/>
public record RenderableFile(string Name, string? IconClass, string Url, string MimeType, bool IsDisabled) : IRenderableFile;
