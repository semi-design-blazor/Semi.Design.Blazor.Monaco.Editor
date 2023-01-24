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

</div>



# Semi Design Blazor Monaco Editor 
  * 封装`Monaco` `Blazor`版本
  * 支持语法提示 
  * 支持自定义语法提示
  * 支持语法高亮
  * 支持自定义扩展


## 基本使用

添加css 和 js 引用

`server`模式 需要将引用添加到`_Host.cshtml` 文件中 `wasm`模式需要添加到`index.html`中
```
<script>
        var require = { paths: { 'vs': 'https://cdn.masastack.com/npm/monaco-editor/0.34.1/min/vs' } };
</script>
<script src="https://cdn.masastack.com/npm/monaco-editor/0.34.1/min/vs/loader.js"></script>
<script src="https://cdn.masastack.com/npm/monaco-editor/0.34.1/min/vs/editor/editor.main.nls.js"></script>
<script src="https://cdn.masastack.com/npm/monaco-editor/0.34.1/min/vs/editor/editor.main.js"></script>
```

```html
<SMonacoEditor @ref="_monacoEditor"/>

<code>
    @Code
</code>

@code{
    private SMonacoEditor? _monacoEditor;
    private string Code;

    private void Init(){
        Code = _monacoEditor.Module.GetValue()
    }

}
```

# 🎈 协议

Semi UI 使用 [MIT 协议](LICENSE)
