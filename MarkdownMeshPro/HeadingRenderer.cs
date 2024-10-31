// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Syntax;

/// <summary>
/// An Normalize renderer for a <see cref="HeadingBlock"/>.
/// </summary>
/// <seealso cref="MarkdownMeshProObjectRenderer{TObject}" />
public class HeadingRenderer : MarkdownMeshProObjectRenderer<HeadingBlock>
{
    protected override void Write(MarkdownMeshProRenderer renderer, HeadingBlock obj)
    {        
        int sizeIncrease = 50 / obj.Level + 100;

        renderer.Write("<b><size=" + sizeIncrease + "%>");
        renderer.WriteLeafInline(obj);
        renderer.Write("</size></b>\n");

        //renderer.FinishBlock(renderer.Options.EmptyLineAfterHeading);
    }
}