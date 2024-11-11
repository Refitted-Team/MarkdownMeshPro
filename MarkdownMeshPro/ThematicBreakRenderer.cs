// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax;

/// <summary>
/// A MarkdownMeshPro renderer for a <see cref="ThematicBreakBlock"/>.
/// </summary>
/// <seealso cref="MarkdownMeshProObjectRenderer{TObject}" />
public class ThematicBreakRenderer : MarkdownMeshProObjectRenderer<ThematicBreakBlock>
{
    protected override void Write(MarkdownMeshProRenderer renderer, ThematicBreakBlock obj)
    {
        renderer.WriteLine(new string(obj.ThematicChar, obj.ThematicCharCount));

        renderer.FinishBlock(renderer.Options.EmptyLineAfterThematicBreak);
    }
}