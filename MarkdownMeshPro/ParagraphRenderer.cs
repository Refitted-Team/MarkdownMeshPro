// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax;

/// <summary>
/// A Normalize renderer for a <see cref="ParagraphBlock"/>.
/// </summary>
/// <seealso cref="MarkdownMeshProObjectRenderer{TObject}" />
public class ParagraphRenderer : MarkdownMeshProObjectRenderer<ParagraphBlock>
{
    protected override void Write(MarkdownMeshProRenderer renderer, ParagraphBlock obj)
    {
        renderer.WriteLeafInline(obj);
        renderer.FinishBlock(!renderer.CompactParagraph);
    }
}