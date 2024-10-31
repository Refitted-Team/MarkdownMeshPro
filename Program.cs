using Markdig;

static string ConvertMarkdownToTMP(string markdownText) {
    var pipeline = new MarkdownPipelineBuilder().Build();
    using var writer = new StringWriter();
    var renderer = new MarkdownMeshProRenderer(writer);
    var document = Markdown.Parse(markdownText, pipeline);
    renderer.Render(document);
    return writer.ToString();
}

Console.WriteLine(ConvertMarkdownToTMP(@"# meow
## meow
### meow
#### meow
meow

1. one 
1. two

- one
- two

```cs
GAY
```

https://meow.com

`This is code!`

[Google](https://google.com/)

> I quote thee!!

_I_
*I*
**B**
***IB***
"));