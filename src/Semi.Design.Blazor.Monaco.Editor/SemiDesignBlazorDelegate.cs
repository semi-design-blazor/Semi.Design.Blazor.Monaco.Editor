namespace Semi.Design.Blazor.Monaco.Editor;

public class SemiDesignBlazorDelegate
{
    /// <summary>
    /// Monaco初始化事件
    /// </summary>
    /// <returns>不为空将传递到monac js初始参数</returns>
    public delegate Task<object?> InitMonacoHandler();
    
    /// <summary>
    /// 初始化成功回调
    /// </summary>
    /// <returns></returns>
    public delegate Task InitMonacoComplete();
}