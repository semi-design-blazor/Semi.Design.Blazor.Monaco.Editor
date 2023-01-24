<p align="center">
  <a href="http://semi-design-blazor.cn/" target="_blank">
    <img alt="Semi Design Blazor" width="150" src="./logo.png">
  </a>
</p>

[![Semi Design Blazor](https://img.shields.io/badge/license-MIT-informational)](https://github.com/semi-design-blazor/Semi.Design.Blazor.Monaco.Editor/blob/develop/LICENSE)

# Semi Design Blazor Monaco Editor 
  * 封装`Monaco` `Blazor`版本
  * 支持语法提示 
  * 支持自定义语法提示
  * 支持语法高亮
  * 支持自定义扩展

## 基本使用

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