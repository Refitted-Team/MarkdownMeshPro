// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax;

/// <summary>
/// An Normalize renderer for a <see cref="CodeBlock"/> and <see cref="FencedCodeBlock"/>.
/// </summary>
/// <seealso cref="MarkdownMeshProObjectRenderer{TObject}" />
public class CodeBlockRenderer : MarkdownMeshProObjectRenderer<CodeBlock>
{
    public bool OutputAttributesOnPre { get; set; }

    protected override void Write(MarkdownMeshProRenderer renderer, CodeBlock obj)
    {
        //renderer.Write("<font=\"MonospaceFont\">");
        //renderer.WriteLeafRawLines(obj, true); //TODO:
        //renderer.Write("</font>");
        
        if (obj is FencedCodeBlock fencedCodeBlock)
        {
            int fencedCharCount = Math.Min(fencedCodeBlock.OpeningFencedCharCount, fencedCodeBlock.ClosingFencedCharCount);

            renderer.Write(fencedCodeBlock.FencedChar, fencedCharCount);
            if (fencedCodeBlock.Info != null)
            {
                renderer.Write(fencedCodeBlock.Info);
            }
            if (!string.IsNullOrEmpty(fencedCodeBlock.Arguments))
            {
                renderer.Write(' ').Write(fencedCodeBlock.Arguments);
            }

            /* TODO do we need this causes a empty space and would render html attributes to markdown.
            var attributes = obj.TryGetAttributes();
            if (attributes != null)
            {
                renderer.Write(' ');
                renderer.Write(attributes);
            }
            */
            renderer.WriteLine();

            renderer.WriteLeafRawLines(obj, true);
            renderer.Write(fencedCodeBlock.FencedChar, fencedCharCount);
        }
        else
        {
            renderer.WriteLeafRawLines(obj, false, true);
        }

        renderer.FinishBlock(renderer.Options.EmptyLineAfterCodeBlock);
    }
}