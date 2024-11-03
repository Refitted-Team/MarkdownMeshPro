// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig;
using Markdig.Syntax;
using Markdig.Renderers;

/// <summary>
/// Default HTML renderer for a Markdown <see cref="MarkdownDocument"/> object.
/// </summary>
/// <seealso cref="TextRendererBase" />
public class MarkdownMeshProRenderer : TextRendererBase<MarkdownMeshProRenderer>
{
    public static string MarkdownToRichTags(string markdownText) {
        var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        using var writer = new StringWriter();
        var renderer = new MarkdownMeshProRenderer(writer);
        var document = Markdown.Parse(markdownText, pipeline);
        renderer.Render(document);
        return writer.ToString();
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="MarkdownMeshProRenderer"/> class.
    /// </summary>
    /// <param name="writer">The writer.</param>
    /// <param name="options">The MarkdownMeshPro options</param>
    public MarkdownMeshProRenderer(TextWriter writer, MarkdownMeshProOptions? options = null) : base(writer)
    {
        Options = options ?? new MarkdownMeshProOptions();
        // Default block renderers
        ObjectRenderers.Add(new CodeBlockRenderer());
        ObjectRenderers.Add(new ListRenderer());
        ObjectRenderers.Add(new HeadingRenderer());
        ObjectRenderers.Add(new HtmlBlockRenderer());
        ObjectRenderers.Add(new ParagraphRenderer());
        ObjectRenderers.Add(new QuoteBlockRenderer());
        ObjectRenderers.Add(new ThematicBreakRenderer());
        ObjectRenderers.Add(new LinkReferenceDefinitionGroupRenderer());
        ObjectRenderers.Add(new LinkReferenceDefinitionRenderer());

        // Default inline renderers
        ObjectRenderers.Add(new AutolinkInlineRenderer());
        ObjectRenderers.Add(new CodeInlineRenderer());
        ObjectRenderers.Add(new DelimiterInlineRenderer());
        ObjectRenderers.Add(new EmphasisInlineRenderer());
        ObjectRenderers.Add(new LineBreakInlineRenderer());
        ObjectRenderers.Add(new MarkdownMeshProHtmlInlineRenderer());
        ObjectRenderers.Add(new MarkdownMeshProHtmlEntityInlineRenderer());            
        ObjectRenderers.Add(new LinkInlineRenderer());
        ObjectRenderers.Add(new LiteralInlineRenderer());
    }

    public MarkdownMeshProOptions Options { get; }

    public bool CompactParagraph { get; set; }

    public void FinishBlock(bool emptyLine)
    {
        if (!IsLastInContainer)
        {
            WriteLine();
            if (emptyLine)
            {
                WriteLine();
            }
        }
    }

    /// <summary>
    /// Writes the lines of a <see cref="LeafBlock"/>
    /// </summary>
    /// <param name="leafBlock">The leaf block.</param>
    /// <param name="writeEndOfLines">if set to <c>true</c> write end of lines.</param>
    /// <param name="indent">Whether to write indents.</param>
    /// <returns>This instance</returns>
    public MarkdownMeshProRenderer WriteLeafRawLines(LeafBlock leafBlock, bool writeEndOfLines, bool indent = false)
    {
        if (leafBlock is null) throw new ArgumentNullException(nameof(leafBlock));
        if (leafBlock.Lines.Lines != null)
        {
            var lines = leafBlock.Lines;
            var slices = lines.Lines;
            for (int i = 0; i < lines.Count; i++)
            {
                if (!writeEndOfLines && i > 0)
                {
                    WriteLine();
                }

                if (indent)
                {
                    Write("    ");
                }

                Write(ref slices[i].Slice);

                if (writeEndOfLines)
                {
                    WriteLine();
                }
            }
        }
        return this;
    }

    public void Write(char c, int count)
    {
        for (int i = 0; i < count; i++)
        {
            Writer.Write(c);
        }        
    }
}