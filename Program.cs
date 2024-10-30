using Markdig;

static string ConvertMarkdownToTMP(string markdownText) {
    var pipeline = new MarkdownPipelineBuilder().Build();
    using var writer = new StringWriter();
    var renderer = new TextMeshProRenderer(writer);
    var document = Markdown.Parse(markdownText, pipeline);
    renderer.Render(document);
    return writer.ToString();
}

Console.WriteLine( ConvertMarkdownToTMP(@"# meow
meow

1. one // doesnt work
2. two
3. three
"));