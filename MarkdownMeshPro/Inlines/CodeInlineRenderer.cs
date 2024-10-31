// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax.Inlines;

/// <summary>
/// A Normalize renderer for a <see cref="CodeInline"/>.
/// </summary>
/// <seealso cref="MarkdownMeshProObjectRenderer{TObject}" />
public class CodeInlineRenderer : MarkdownMeshProObjectRenderer<CodeInline>
{
    protected override void Write(MarkdownMeshProRenderer renderer, CodeInline obj)
    {/*
        @"<space=0.3em><mark=#0000003C padding="25,25,0,0">This is code!</mark><space=0.3em>"*/
        
        renderer.Write("<space=0.3em><mark=#0000003C padding=\"25,25,0,0\">");
        renderer.Write(obj.Content);
        renderer.Write("</mark><space=0.3em>");
        
        /*var delimiterCount = 0;
        string content = obj.Content;
        for (var i = 0; i < content.Length; i++)
        {
            var index = content.IndexOf(obj.Delimiter, i);
            if (index == -1) break;

            var count = 1;
            for (i = index + 1; i < content.Length; i++)
            {
                if (content[i] == obj.Delimiter) count++;
                else break;
            }

            if (delimiterCount < count)
                delimiterCount = count;
        }

        renderer.Write(obj.Delimiter, delimiterCount + 1);
        if (content.Length != 0)
        {
            if (content[0] == obj.Delimiter)
            {
                renderer.Write(' ');
            }
            renderer.Write(content);
            if (content[content.Length - 1] == obj.Delimiter)
            {
                renderer.Write(' ');
            }
        }
        else
        {
            renderer.Write(' ');
        }
        renderer.Write(obj.Delimiter, delimiterCount + 1);*/
    }
}