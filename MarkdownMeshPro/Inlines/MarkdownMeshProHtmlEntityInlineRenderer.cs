// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax.Inlines;

/// <summary>
/// A MarkdownMeshPro renderer for a <see cref="HtmlEntityInline"/>.
/// </summary>
public class MarkdownMeshProHtmlEntityInlineRenderer : MarkdownMeshProObjectRenderer<HtmlEntityInline>
{
    protected override void Write(MarkdownMeshProRenderer renderer, HtmlEntityInline obj)
    {
        renderer.Write(obj.Original);
    }
}