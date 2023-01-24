function init(id, options) {
    return monaco.editor.create(document.getElementById(id), options)
}
function getValue(e) {
    return e.getValue()
}
function setValue(e, n) {
    e.setValue(n)
}
function setTheme(e) {
    monaco.editor.setTheme(e)
}
function getModels() {
    return monaco.editor.getModels()
}
function getModel(e) {
    return e.getModel()
}
function setModelLanguage(e, n) {
    monaco.editor.setModelLanguage(e.getModel(), n)
}
function remeasureFonts() {
    monaco.editor.remeasureFonts()
}
function addKeybindingRules(e) {
    monaco.editor.addKeybindingRules(e)
}
function addKeybindingRule(e)
{
    monaco.editor.addKeybindingRule(e)
}

function registerCompletionItemProvider(language, triggerCharacters, suggestions) {
    console.log('language', language, 'triggerCharacters', triggerCharacters, "suggestions", suggestions)
    monaco.languages.registerCompletionItemProvider(language, {
        provideCompletionItems: function (model, position) {
            console.log('model', model, 'position', position)
            return {
                suggestions: suggestions
            };
        }, triggerCharacters:triggerCharacters
    });
}

export {
    addKeybindingRule,
    addKeybindingRules,
    getModel,
    getModels,
    getValue,
    init,
    remeasureFonts,
    setModelLanguage,
    setTheme,
    setValue,
    registerCompletionItemProvider
};