using Markdig.Renderers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

public class TextMeshProRenderer: TextRendererBase<TextMeshProRenderer> {

    public List<TMPItem> Items = [];

    public TextMeshProRenderer(): base(new StringWriter()) {
        // Block renderers
        ObjectRenderers.Add(new HeadingRenderer());
        ObjectRenderers.Add(new ParagraphRenderer());
        ObjectRenderers.Add(new ListRenderer());

        // Inline renderers
        ObjectRenderers.Add(new LiteralInlineRenderer());
    }

    public override List<TMPItem> Render(MarkdownObject markdownObject)
    {
        object value = base.Render(markdownObject);

        List<TMPItem> items = [];

        string text = "";

        foreach (var item in Items)
        {

            if (item is TMPTextItem textItem)
                text += textItem.Text + "\n";
            else if (item is TMPImageItem imageItem)
            {
                if (text != "") items.Add(new TMPTextItem(text));
                items.Add(imageItem);
            }
        }

        if (text != "") items.Add(new TMPTextItem(text));

        return items;
    }

    public void AddItem()
    {
        Items.Add(new TMPTextItem(Writer.ToString()));

        Writer = new StringWriter();
    }
}

public abstract class TextMeshProObjectRenderer<TObject>: MarkdownObjectRenderer<TextMeshProRenderer, TObject> where TObject: MarkdownObject;

public class HeadingRenderer : TextMeshProObjectRenderer<HeadingBlock> {

    protected override void Write(TextMeshProRenderer renderer, HeadingBlock obj) {

        int sizeIncrease = 50 / obj.Level + 100;

        renderer.Write("<b><size=" + sizeIncrease + "%>");
        renderer.WriteLeafInline(obj);
        renderer.Write("</size></b>");

        renderer.AddItem();
    }
}

public class LiteralInlineRenderer : TextMeshProObjectRenderer<LiteralInline>
{
    protected override void Write(TextMeshProRenderer renderer, LiteralInline obj)
    {
        renderer.Write(ref obj.Content);
    }
}

public class ParagraphRenderer : TextMeshProObjectRenderer<ParagraphBlock>
{
    protected override void Write(TextMeshProRenderer renderer, ParagraphBlock obj)
    {
        renderer.WriteLeafInline(obj);

        renderer.AddItem();
    }
}

public class ListRenderer : TextMeshProObjectRenderer<ListBlock>
{
    protected override void Write(TextMeshProRenderer renderer, ListBlock obj)
    {
        foreach (ListItemBlock listItemBlock in obj)
        {
            renderer.Write("<space=1em>");
            renderer.Write(obj.BulletType + ")  ");
            renderer.Write(listItemBlock);
        }
    }
}