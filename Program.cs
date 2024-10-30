using Markdig;

List<TMPItem> items = TextMeshProRenderer.RenderToTMPItems(@"# meow
## meow
### meow
#### meow
meow

1. one // doesnt work
2. two
3. three

- one // WORKS
- two
- three

```
GAY
```

`This is code!`

[Google](https://google.com/)

> I quote thee!!

_I_
*I*
**B**
***IB***
");

foreach (var item in items) {
    Console.WriteLine(item);
}