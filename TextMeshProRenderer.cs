using Markdig.Renderers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

public class TextMeshProRenderer: TextRendererBase<TextMeshProRenderer> {

    public TextMeshProRenderer(TextWriter writer): base(writer) {

        // Block renderers
        ObjectRenderers.Add(new HeadingRenderer());

        // Inline renderers
        ObjectRenderers.Add(new LiteralInlineRenderer());
    }
}

public abstract class TextMeshProObjectRenderer<TObject>: MarkdownObjectRenderer<TextMeshProRenderer, TObject> where TObject: MarkdownObject {
}

public class HeadingRenderer : TextMeshProObjectRenderer<HeadingBlock> {

    protected override void Write(TextMeshProRenderer renderer, HeadingBlock obj) {

        int sizeIncrease = obj.Level * 2;

        renderer.Write("<size=+" + sizeIncrease.ToString() + ">");
        renderer.WriteLeafInline(obj);
        renderer.Write("</size>");

        renderer.EnsureLine();
    }
}

public class LiteralInlineRenderer : TextMeshProObjectRenderer<LiteralInline>
{
    protected override void Write(TextMeshProRenderer renderer, LiteralInline obj)
    {
            renderer.Write(ref obj.Content);
    }
}