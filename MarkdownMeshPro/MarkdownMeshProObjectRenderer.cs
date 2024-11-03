// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Renderers;
using Markdig.Syntax;
using Markdig.Syntax.Inlines;

/// <summary>
/// A base class for Normalize rendering <see cref="Block"/> and <see cref="Inline"/> Markdown objects.
/// </summary>
/// <typeparam name="TObject">The type of the object.</typeparam>
/// <seealso cref="IMarkdownObjectRenderer" />
public abstract class MarkdownMeshProObjectRenderer<TObject> : MarkdownObjectRenderer<MarkdownMeshProRenderer, TObject> where TObject : MarkdownObject;