// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax;

public class HtmlBlockRenderer : MarkdownMeshProObjectRenderer<HtmlBlock>
{
    protected override void Write(MarkdownMeshProRenderer renderer, HtmlBlock obj)
    {
        renderer.WriteLeafRawLines(obj, true, false);
    }
}