<h1 align="center">NAT.PY Editor</h1>

<div align="center">

![OpenSourse](https://img.shields.io/badge/NAT.PY%20Editor-v0.1.1-blueviolet)
  
</div>

> ### Perhaps interesting
> This editor is based on regular expressions and chocolate chip cookies 🍪
<br>
You can try something like this too. An example of our implementation
<br><br>

``` csharp
// Find matches in a string
Regex regex = new Regex(@"\b(for|while|def\b)");
MatchCollection keyWordsMatсhes = regex.Matches(text);

// Keyword coloring
foreach (Match match in keyWordsMatсhes)
{
    Editor.Selection.Select(GetTextPointerAtOffset(Editor, match.Index), GetTextPointerAtOffset(Editor, match.index)));
    Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Color.FromRgb(236, 95, 100)));
}

```

### Example of work

<img width="800" height="500" src="https://github.com/xoheveras/xoheveras/blob/master/Readme/Images/2021-11-21-21-37-02.gif">
