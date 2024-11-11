// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax.Inlines;

/// <summary>
/// A MarkdownMeshPro renderer for an <see cref="AutolinkInline"/>.
/// </summary>
/// <seealso cref="MarkdownMeshProObjectRenderer{AutolinkInline}" />
public class AutolinkInlineRenderer : MarkdownMeshProObjectRenderer<AutolinkInline>
{
    protected override void Write(MarkdownMeshProRenderer renderer, AutolinkInline obj)
    {
        renderer.Write("<color=#1D7CEAFF>");
        renderer.Write("<link=\"" + obj.Url + "\">");
        renderer.Write(obj.Url);
        renderer.Write("</link></color>");
        
        //renderer.Write('<').Write(obj.Url).Write('>');
    }
}