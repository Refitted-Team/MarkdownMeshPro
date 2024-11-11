// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

#nullable enable
/// <summary>
/// Defines the options used by <see cref="MarkdownMeshProRenderer"/>
/// </summary>
public class MarkdownMeshProOptions
{
    /// <summary>
    /// Initialize a new instance of <see cref="MarkdownMeshProOptions"/>
    /// </summary>
    public MarkdownMeshProOptions()
    {
        SpaceAfterQuoteBlock = true;
        EmptyLineAfterCodeBlock = true;
        EmptyLineAfterHeading = true;
        EmptyLineAfterThematicBreak = true;
        ListItemCharacter = '•';
        OrderedListDelimiter = null;
        MonospaceFont = null;
    }

    /// <summary>
    /// Adds a space after a QuoteBlock &gt;. Default is <c>true</c>
    /// </summary>
    public bool SpaceAfterQuoteBlock { get; set; }

    /// <summary>
    /// Adds an empty line after a code block (fenced and tabbed). Default is <c>true</c>
    /// </summary>
    public bool EmptyLineAfterCodeBlock { get; set; }

    /// <summary>
    /// Adds an empty line after an heading. Default is <c>true</c>
    /// </summary>
    public bool EmptyLineAfterHeading { get; set; }

    /// <summary>
    /// Adds an empty line after an thematic break. Default is <c>true</c>
    /// </summary>
    public bool EmptyLineAfterThematicBreak { get; set; }

    /// <summary>
    /// The bullet character used for list items. Default is <c>•</c>, change to null to leave the original bullet character as-is.
    /// </summary>
    public char? ListItemCharacter { get; set; }

    /// <summary>
    /// the delimiter character used after the ordered list number eg: <c>.</c>, <c>)</c> or <c>:</c>. Default is <c>null</c> to use the original character.
    /// </summary>
    public char? OrderedListDelimiter { get; set; }
    
    /// <summary>
    /// path of the TMP font used for monospace. Default is <c>null</c> not using a monospace font.
    /// </summary>
    public string? MonospaceFont { get; set; }
}