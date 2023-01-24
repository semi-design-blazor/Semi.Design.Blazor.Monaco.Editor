using Microsoft.JSInterop;
using Semi.Design.Blazor;

namespace Semi.Design.CodeRendering;

public class MonacoEditorJSModule : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public MonacoEditorJSModule(IJSRuntime jsRuntime)
    {
        moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Semi.Design.CodeRendering/js/editor.js").AsTask());
    }

    public async ValueTask<IJSObjectReference> Init(string id, object options)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<IJSObjectReference>("init", id, options);
    }

    public async ValueTask<string> GetValue(IJSObjectReference id)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<string>("getValue", id);
    }

    public async ValueTask SetValue(IJSObjectReference id, string value)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("setValue", id, value);
    }

    public async ValueTask SetTheme(string theme)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("setTheme", theme);
    }

    public async ValueTask<TextModelOptions[]> GetModels()
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<TextModelOptions[]>("getModels");
    }

    public async ValueTask<TextModelOptions> GetModel(IJSObjectReference id)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<TextModelOptions>("getModel", id);
    }

    public async ValueTask SetModelLanguage(IJSObjectReference id, string languageId)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("setModelLanguage", id, languageId);
    }

    public async ValueTask RemeasureFonts()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("remeasureFonts");
    }

    public async ValueTask AddKeybindingRules(KeybindingRule[] rules)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("addKeybindingRules", rules);
    }

    public async ValueTask AddKeybindingRule(KeybindingRule rule)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("addKeybindingRules", rule);
    }

    /// <summary>
    /// 添加智能提示
    /// </summary>
    /// <param name="language"></param>
    /// <param name="triggerCharacters"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    public async ValueTask RegisterCompletionItemProvider(string language, string[] triggerCharacters,
        CompletionItem[] items)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("registerCompletionItemProvider", language, triggerCharacters, items);
    }

    public async ValueTask DisposeAsync()
    {
        moduleTask.Value.Dispose();
        await Task.CompletedTask;
    }
}