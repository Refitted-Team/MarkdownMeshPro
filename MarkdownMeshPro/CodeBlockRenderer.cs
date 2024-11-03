// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax;

/// <summary>
/// An Normalize renderer for a <see cref="CodeBlock"/> and <see cref="FencedCodeBlock"/>.
/// </summary>
/// <seealso cref="MarkdownMeshProObjectRenderer{TObject}" />
public class CodeBlockRenderer : MarkdownMeshProObjectRenderer<CodeBlock>
{
    public bool OutputAttributesOnPre { get; set; }

    protected override void Write(MarkdownMeshProRenderer renderer, CodeBlock obj)
    {
        if (obj is FencedCodeBlock fencedCodeBlock)
        {
            renderer.Write("<mark=#0000003C padding=\"25,20000,3.26,0\">" 
                           //+ "<font=Miracode SDF>"
                           );
            if (fencedCodeBlock.Info != null)
            {
                renderer.Write(fencedCodeBlock.Info);
            }
            if (!string.IsNullOrEmpty(fencedCodeBlock.Arguments))
            {
                renderer.Write(' ').Write(fencedCodeBlock.Arguments);
            }

            renderer.WriteLine();

            renderer.WriteLeafRawLines(obj, true);
            renderer.Write("</mark>" 
                           //+ "</font>"
                           );
        }
        else
            renderer.WriteLeafRawLines(obj, false, true);

        renderer.FinishBlock(renderer.Options.EmptyLineAfterCodeBlock);
    }
}