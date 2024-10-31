// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax;

/// <summary>
/// A Normalize renderer for a <see cref="QuoteBlock"/>.
/// </summary>
/// <seealso cref="MarkdownMeshProObjectRenderer{TObject}" />
public class QuoteBlockRenderer : MarkdownMeshProObjectRenderer<QuoteBlock>
{
    protected override void Write(MarkdownMeshProRenderer renderer, QuoteBlock obj)
    {
        renderer.Write("<space=1rem>");
        renderer.WriteChildren(obj);
        
        /*var quoteIndent = renderer.Options.SpaceAfterQuoteBlock ? obj.QuoteChar + " " : obj.QuoteChar.ToString();
        renderer.PushIndent(quoteIndent);
        renderer.WriteChildren(obj);
        renderer.PopIndent();*/

        renderer.FinishBlock(true);
    }
}