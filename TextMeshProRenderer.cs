using Markdig;
using Markdig.Helpers;
using Markdig.Renderers;
using Markdig.Renderers.Html;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

public class TextMeshProRenderer: TextRendererBase<TextMeshProRenderer> {
    public static List<TMPItem> RenderToTMPItems(string markdownText)
    {
        var pipeline = new MarkdownPipelineBuilder().Build();
        var renderer = new TextMeshProRenderer();
        var document = Markdown.Parse(markdownText, pipeline);
        return renderer.Render(document);
    }

    public static string RenderToTMPString(string markdownText)
    {
        List<TMPItem> tMPItems = RenderToTMPItems(markdownText);

        string text = "";

        // Collect all Text items and combine all the text inside
        foreach (var tMPItem in tMPItems)
        {
            if (tMPItem is TMPTextItem textItem)
            {
                text += textItem.Text;
            }
        }

        return text;
    }

    public List<TMPItem> Items = [];

    public TextMeshProRenderer(): base(new StringWriter()) {
        // Block renderers
        ObjectRenderers.Add(new HeadingRenderer());
        ObjectRenderers.Add(new ParagraphRenderer());
        ObjectRenderers.Add(new ListRenderer());
        ObjectRenderers.Add(new CodeRenderer());
        ObjectRenderers.Add(new QuoteRenderer());

        // Inline renderers
        ObjectRenderers.Add(new LiteralInlineRenderer());
        ObjectRenderers.Add(new AutolinkInlineRenderer());
        ObjectRenderers.Add(new LinkInlineRenderer());
        ObjectRenderers.Add(new CodeInlineRenderer());
        ObjectRenderers.Add(new DelimiterInlineRenderer());
        ObjectRenderers.Add(new EmphasisInlineRenderer());
    }
    
    public override List<TMPItem> Render(MarkdownObject markdownObject)
    {
        object value = base.Render(markdownObject);

        //return Items;

        List<TMPItem> items = [];

        string text = "";

        foreach (var item in Items)
        {

            if (item is TMPTextItem textItem)
                text += textItem.Text + "\n";
            else if (item is TMPImageItem imageItem)
            {
                if (text != "")
                {
                    items.Add(new TMPTextItem(text));
                    text = "";
                }
                items.Add(imageItem);
            }
        }

        if (text != "") items.Add(new TMPTextItem(text));

        return items;
    }

    public TextMeshProRenderer WriteLeafRawLines(LeafBlock leafBlock, bool writeEndOfLines)
    {
        if (leafBlock is null) throw new ArgumentNullException("leafBlock is null.");

        var slices = leafBlock.Lines.Lines;
        if (slices is not null)
        {
            for (int i = 0; i < slices.Length; i++)
            {
                ref StringSlice slice = ref slices[i].Slice;
                if (slice.Text is null)
                {
                    break;
                }

                if (!writeEndOfLines && i > 0)
                {
                    WriteLine();
                }

                ReadOnlySpan<char> span = slice.AsSpan();
                Write(span);

                if (writeEndOfLines)
                {
                    WriteLine();
                }
            }
        }

        return this;
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

        renderer.Write("<b><size=+" + sizeIncrease.ToString() + ">");
        renderer.WriteLeafInline(obj);
        renderer.Write("</size></b><br>");

        renderer.AddItem();
    }
}

public class LiteralInlineRenderer : TextMeshProObjectRenderer<LiteralInline>
{
    protected override void Write(TextMeshProRenderer renderer, LiteralInline obj)
    {
        renderer.Write(ref obj.Content);

        renderer.AddItem();
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
        if (obj.BulletType.Equals('1'))
        {
            foreach (ListItemBlock listItemBlock in obj)
            {
                renderer.Write((obj.IndexOf(listItemBlock) + 1).ToString() + ")  ");
                renderer.Write(listItemBlock);
                renderer.Write("<br>");
            }
        } else
        {
            foreach (ListItemBlock listItemBlock in obj)
            {
                renderer.Write(obj.BulletType + ")  ");
                renderer.Write(listItemBlock);
                renderer.Write("<br>");
            }
        }
    }
}

public class CodeRenderer : TextMeshProObjectRenderer<CodeBlock>
{
    protected override void Write(TextMeshProRenderer renderer, CodeBlock obj)
    {

        //renderer.Write("<font=\"MonospaceFont\">");
        renderer.WriteLeafRawLines(obj, true);
        //renderer.Write("</font>");

        renderer.AddItem();
    }
}

public class CodeInlineRenderer : TextMeshProObjectRenderer<CodeInline>
{
    protected override void Write(TextMeshProRenderer renderer, CodeInline obj)
    {

        //renderer.Write("<font=\"MonospaceFont\">");
        renderer.Write(obj.ContentSpan);
        //renderer.Write("</font>");

        renderer.AddItem();
    }
}

public class AutolinkInlineRenderer : TextMeshProObjectRenderer<AutolinkInline>
{
    protected override void Write(TextMeshProRenderer renderer, AutolinkInline obj)
    {
        renderer.Write("<color=#1D7CEAFF>");
        renderer.Write("<link=\"" + obj.Url + "\">");
        renderer.Write(obj.Url);
        renderer.Write("</link></color>");

        renderer.AddItem();
    }
}

public class LinkInlineRenderer : TextMeshProObjectRenderer<LinkInline>
{
    protected override void Write(TextMeshProRenderer renderer, LinkInline obj)
    {
        renderer.Write("<color=#1D7CEAFF>");
        renderer.Write("<link=\"" + obj.Url + "\">");
        renderer.WriteChildren(obj);
        renderer.Write("</link></color>");

        renderer.AddItem();
    }
}

public class QuoteRenderer : TextMeshProObjectRenderer<QuoteBlock>
{
    protected override void Write(TextMeshProRenderer renderer, QuoteBlock obj)
    {
        renderer.Write("<space=1rem>");
        renderer.WriteChildren(obj);

        renderer.AddItem();
    }
}

public class DelimiterInlineRenderer : TextMeshProObjectRenderer<DelimiterInline>
{
    protected override void Write(TextMeshProRenderer renderer, DelimiterInline obj)
    {
        renderer.Write(obj.ToLiteral());
        renderer.WriteChildren(obj);
    }
}

public class EmphasisInlineRenderer : TextMeshProObjectRenderer<EmphasisInline>
{
    protected override void Write(TextMeshProRenderer renderer, EmphasisInline obj)
    {
        string tags = "<b>";
        string endTags = "</b>";

        if (obj.DelimiterChar == '*')
        {
            if (obj.DelimiterCount == 1)
            {
                tags = "<i>";
                endTags = "</i>";
            } else if (obj.DelimiterCount == 2)
            {
                tags = "<b>";
                endTags = "</b>";
            } else if (obj.DelimiterCount == 3)
            {
                tags = "<b><i>";
                endTags = "</i></b>";
            } else
            {
                tags = new string('*', obj.DelimiterCount);
                endTags = new string('*', obj.DelimiterCount);
            }
        } else if (obj.DelimiterChar == '_')
        {
            if (obj.DelimiterCount == 1)
            {
                tags = "<i>";
                endTags = "</i>";
            } else
            {
                tags = new string('_', obj.DelimiterCount);
                endTags = new string('_', obj.DelimiterCount);
            }
        }

        renderer.Write(tags);
        renderer.WriteChildren(obj);
        renderer.Write(endTags);

        renderer.AddItem();
    }
}