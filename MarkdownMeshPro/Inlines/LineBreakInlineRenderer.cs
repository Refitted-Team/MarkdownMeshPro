// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax.Inlines;

/// <summary>
/// A MarkdownMeshPro renderer for a <see cref="LineBreakInline"/>.
/// </summary>
/// <seealso cref="MarkdownMeshProObjectRenderer{TObject}" />
public class LineBreakInlineRenderer : MarkdownMeshProObjectRenderer<LineBreakInline>
{
    /// <summary>
    /// Gets or sets a value indicating whether to render this softline break as a MarkdownMeshPro hardline break tag (&lt;br /&gt;)
    /// </summary>
    public bool RenderAsHardlineBreak { get; set; }

    protected override void Write(MarkdownMeshProRenderer renderer, LineBreakInline obj)
    {
        if (obj.IsHard)
        {
            renderer.Write(obj.IsBackslash ? "\\" : "  ");
        }
        renderer.WriteLine();
    }
}