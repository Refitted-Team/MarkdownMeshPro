// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using System;
using Markdig.Extensions.Alerts;
using Markdig.Syntax;

/// <summary>
/// A MarkdownMeshPro renderer for a <see cref="AlertBlock"/>.
/// </summary>
/// <seealso cref="MarkdownMeshProObjectRenderer{TObject}" />
public class AlertRenderer : MarkdownMeshProObjectRenderer<AlertBlock>
{
    protected override void Write(MarkdownMeshProRenderer renderer, AlertBlock obj)
    {
        renderer.EnsureLine();
        renderer.WriteLine("<mark=#0000003C padding=\"0,20000,3.26,0\">\u200b");
        if (obj.Kind.Length <= 16)
        {
            Span<char> upperKind = stackalloc char[obj.Kind.Length];
            obj.Kind.AsSpan().ToUpperInvariant(upperKind);

            (string, string) kind = upperKind.ToString() switch { // colors from github of course
                "NOTE" => ("#1f6feb", "Note"),
                "TIP" => ("#238636", "Tip"),
                "IMPORTANT" => ("#8957e5", "Important"),
                "WARNING" => ("#9e6a03", "Warning"),
                "CAUTION" => ("#da3633", "Caution"),
                _ => ("#ffffff", upperKind.ToString())
            };
            
            renderer.PushIndent($"<mark={kind.Item1} padding=\"2,2,110,110\">\u2006</mark>  ");
            renderer.WriteLine($"<b><color={kind.Item1}>{kind.Item2}</color></b>");
        }

        renderer.WriteChildren(obj);
        renderer.PopIndent();
        renderer.WriteLine("\n\u200b</mark>");
        renderer.EnsureLine();
        renderer.WriteLine();
    }
}