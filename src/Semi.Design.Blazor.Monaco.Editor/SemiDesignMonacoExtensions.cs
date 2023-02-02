using Microsoft.Extensions.DependencyInjection;
using Semi.Design.CodeRendering;

namespace Semi.Design.Blazor.Monaco.Editor;

public static class SemiDesignMonacoExtensions
{
    public static IServiceCollection AddSemiDesignMonaco(this IServiceCollection services)
    {
        services.AddScoped<MonacoEditorJSModule>();
        
        return services;
    }
}