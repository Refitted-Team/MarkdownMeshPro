using Markdig;

static List<TMPItem> ConvertMarkdownToTMP(string markdownText) {
    var pipeline = new MarkdownPipelineBuilder().Build();
    var renderer = new TextMeshProRenderer();
    var document = Markdown.Parse(markdownText, pipeline);
    return renderer.Render(document);
}

List<TMPItem> items = ConvertMarkdownToTMP(
@"# meow
## meow
##### meow
meow

1. one // doesnt work
2. two

- one // WORKS
- two
");

foreach (var item in items)
    Console.WriteLine(item);
    
//Console.ReadLine();