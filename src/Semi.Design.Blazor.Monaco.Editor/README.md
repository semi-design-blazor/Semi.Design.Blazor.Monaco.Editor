<p align="center">
  <a href="http://semi-design-blazor.cn/" target="_blank">
    <img alt="Semi Design Blazor" width="150" src="./logo.png">
  </a>
</p>

<h1 align="center">Semi Design Blazor</h1>

<div align="center">

[![Semi Design Blazor](https://img.shields.io/badge/license-MIT-informational)](https://github.com/semi-design-blazor/Semi.Design.Blazor.Monaco.Editor/blob/develop/LICENSE)
[![Nuget](https://img.shields.io/nuget/v/Semi.Design.Blazor.Monaco.Editor)](https://www.nuget.org/packages/Semi.Design.Blazor.Monaco.Editor)
[![Nuget](https://img.shields.io/nuget/dt/Semi.Design.Blazor.Monaco.Editor)](https://www.nuget.org/packages/Semi.Design.Blazor.Monaco.Editor)

# Monaco editor

[English](./README.md) | 简体中文

## sample

```html
<script>
        var require = { paths: { 'vs': 'https://cdn.masastack.com/npm/monaco-editor/0.34.1/min/vs' } };
</script>
<script src="https://cdn.masastack.com/npm/monaco-editor/0.34.1/min/vs/loader.js"></script>
<script src="https://cdn.masastack.com/npm/monaco-editor/0.34.1/min/vs/editor/editor.main.nls.js"></script>
<script src="https://cdn.masastack.com/npm/monaco-editor/0.34.1/min/vs/editor/editor.main.js"></script>
```

Inject the MasaBlazorMonacoEditor service

```
builder.Services.AddSemiDesignBlazorMonacoEditor();
```

Basic sample code

```csharp
@using Masa.Blazor

<div style="height:95vh;width:50%;float:left">
    <SMonacoEditor EditorOptions="Options" @ref="_monacoEditor" />
</div>
<button @onclick="GetValue" style="margin:5px;height:25px;font-size:18px;background-color:cornflowerblue;">Get Code</button>
<code>
    @Code
</code>

@code{
    private SMonacoEditor? _monacoEditor;
    private string Code;
    private object Options;
    protected override void OnInitialized()
    {
        Options = new
        {
            value = """{"value":"masa"}""", // Initial code
            language = "json", // Syntactic support language
            automaticLayout = true, // Automatically ADAPTS to parent container size
            theme = "vs-dark" // monaco theme 
        };
        base.OnInitialized();
    }

    private async Task GetValue()
    {
        Code = await _monacoEditor.GetValue();
    }
}
```
