using System.Diagnostics;

string text = @"
# Markdown syntax guide

## Headers

# This is a Heading h1
## This is a Heading h2
###### This is a Heading h6

## Emphasis

*This text will be italic*  
_This will also be italic_

**This text will be bold**  
__This will also be bold__

_You **can** combine them_

## Lists

### Unordered

* Item 1
* Item 2
* Item 2a
* Item 2b

### Ordered

1. Item 1
2. Item 2
3. Item 3
    1. Item 3a
    2. Item 3b

## Images

![This is an alt text.](/image/sample.webp ""This is a sample image."")

## Links

You may be using [Markdown Live Preview](https://markdownlivepreview.com/).

## Blockquotes

> Markdown is a lightweight markup language with plain-text-formatting syntax, created in 2004 by John Gruber with Aaron Swartz.
>
>> Markdown is often used to format readme files, for writing messages in online discussion forums, and to create rich text using a plain text editor.

## Tables

| Left columns  | Right columns |
| ------------- |:-------------:|
| left foo      | right foo     |
| left bar      | right bar     |
| left baz      | right baz     |

## Blocks of code

```
let message = 'Hello world';
alert(message);
```

## Inline code

This web site is using `markedjs/marked`.

# meow
## meow
### meow
#### meow
meow

1. one 
1. two

- one
- two

```cs
GAY
```

https://meow.com

`This is code!`

[Google](https://google.com/)

> I quote thee!!

_I_
*I*
**B**
***IB***
".Trim('\n');

MarkdownMeshProOptions options = new() { MonospaceFont = "Miracode SDF" };
string convertedText = MarkdownMeshProRenderer.MarkdownToRichTags(text, options);
Console.WriteLine(convertedText);
File.WriteAllText("meow.txt", convertedText); // command prompt cant display bullets
if (Console.ReadKey().Key == ConsoleKey.O) Process.Start("notepad.exe", "meow.txt");