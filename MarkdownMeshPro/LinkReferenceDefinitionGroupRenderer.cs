// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax;

public class LinkReferenceDefinitionGroupRenderer : MarkdownMeshProObjectRenderer<LinkReferenceDefinitionGroup>
{
    protected override void Write(MarkdownMeshProRenderer renderer, LinkReferenceDefinitionGroup obj)
    {
        renderer.EnsureLine();
        renderer.WriteChildren(obj);
        renderer.FinishBlock(false);
    }
}