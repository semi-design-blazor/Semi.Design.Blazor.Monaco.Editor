namespace Microsoft.Extensions.DependencyInjection;

public static class SemiDesignBlazorMonacoEditorExtension
{
    public static IServiceCollection AddSemiDesignBlazorMonacoEditor(this IServiceCollection services)
    {
        services.AddScoped<MonacoEditorJSModule>();
        return services;
    }
}
