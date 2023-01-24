using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Semi.Design.Blazor.Monaco.Editor;
using Semi.Design.CodeRendering;

namespace Semi.Design.Blazor;

public partial class SMonacoEditor : IAsyncDisposable
{
    [Inject] public MonacoEditorJSModule Module { get; set; }

    [Parameter] public EditorOptions EditorOptions { get; set; } = new();

    [Parameter] public string Width { get; set; } = "100%";

    [Parameter] public string Height { get; set; } = "500px";

    /// <summary>
    /// 提示触发关键字
    /// </summary>
    [Parameter]
    public MonacoRegisterCompletionItemOptions[]? MonacoRegisterCompletionItemOptions { get; set; }

    private ElementReference _ref;

    private ElementReference? _prevRef;

    private bool _elementReferenceChanged;

    /// <summary>
    /// 渲染区的Css和Style提供程序
    /// </summary>
    [Parameter]
    public string? Class { get; set; }

    [Parameter] public string? Style { get; set; }

    [Parameter] public string? Id { get; set; }

    [Parameter] public SemiDesignBlazorDelegate.InitMonacoHandler? InitMonacoHandler { get; set; }

    /// <summary>
    /// 初始化完成回调
    /// </summary>
    [Parameter]
    public SemiDesignBlazorDelegate.InitMonacoComplete? InitMonacoComplete { get; set; }

    public virtual ElementReference Ref
    {
        get => _ref;
        set
        {
            if (_prevRef.HasValue)
            {
                if (_prevRef.Value.Id != value.Id)
                {
                    _prevRef = value;
                    _elementReferenceChanged = true;
                }
            }
            else
            {
                _prevRef = value;
            }

            _ref = value;
        }
    }

    /// <summary>
    /// monaco
    /// </summary>
    private IJSObjectReference _monaco;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await InitMonaco();
        }

        await base.OnAfterRenderAsync(firstRender);
    }

    protected override void OnInitialized()
    {
        Id ??= Guid.NewGuid().ToString("N");

        base.OnInitialized();
    }

    private async Task InitMonaco()
    {
        foreach (var itemOption in MonacoRegisterCompletionItemOptions)
        {
            await Module.RegisterCompletionItemProvider(itemOption.Language, itemOption.TriggerCharacters,
                itemOption.items);
        }

        var value = await InitMonacoHandler?.Invoke();
        if (value != null)
        {
            _monaco = await Module.Init(Id, value);
        }
        else
        {
            _monaco = await Module.Init(Id, EditorOptions);
        }

        InitMonacoComplete?.Invoke();
    }

    public async ValueTask DisposeAsync()
    {
        await Task.CompletedTask;
    }
}