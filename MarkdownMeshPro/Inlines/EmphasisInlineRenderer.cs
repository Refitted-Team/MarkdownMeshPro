// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Syntax.Inlines;

/// <summary>
/// A Normalize renderer for an <see cref="EmphasisInline"/>.
/// </summary>
/// <seealso cref="MarkdownMeshProObjectRenderer{TObject}" />
public class EmphasisInlineRenderer : MarkdownMeshProObjectRenderer<EmphasisInline>
{
    protected override void Write(MarkdownMeshProRenderer renderer, EmphasisInline obj)
    {
        string tags = "<b>";
        string endTags = "</b>";

        if (obj.DelimiterChar == '*')
        {
            if (obj.DelimiterCount == 1)
            {
                tags = "<i>";
                endTags = "</i>";
            } else if (obj.DelimiterCount == 2)
            {
                tags = "<b>";
                endTags = "</b>";
            } else if (obj.DelimiterCount == 3)
            {
                tags = "<b><i>";
                endTags = "</i></b>";
            } else
            {
                tags = new string('*', obj.DelimiterCount);
                endTags = new string('*', obj.DelimiterCount);
            }
        } else if (obj.DelimiterChar == '_')
        {
            if (obj.DelimiterCount == 1)
            {
                tags = "<i>";
                endTags = "</i>";
            } else
            {
                tags = new string('_', obj.DelimiterCount);
                endTags = new string('_', obj.DelimiterCount);
            }
        }

        renderer.Write(tags);
        renderer.WriteChildren(obj);
        renderer.Write(endTags);
        
        /*renderer.Write(obj.DelimiterChar, obj.DelimiterCount);
        renderer.WriteChildren(obj);
        renderer.Write(obj.DelimiterChar, obj.DelimiterCount);*/
    }
}