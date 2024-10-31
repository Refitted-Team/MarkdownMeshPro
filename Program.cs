List<TMPItem> items = TextMeshProRenderer.RenderToTMPItems(@"# meow
## meow
### meow
#### meow
meow

1. one 
2. two

- one
- two

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