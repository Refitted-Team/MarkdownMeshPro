// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax.Inlines;

/// <summary>
/// A MarkdownMeshPro renderer for a <see cref="DelimiterInline"/>.
/// </summary>
/// <seealso cref="MarkdownMeshProObjectRenderer{TObject}" />
public class DelimiterInlineRenderer : MarkdownMeshProObjectRenderer<DelimiterInline>
{
    protected override void Write(MarkdownMeshProRenderer renderer, DelimiterInline obj)
    {
        renderer.Write(obj.ToLiteral());
        renderer.WriteChildren(obj);
    }
}