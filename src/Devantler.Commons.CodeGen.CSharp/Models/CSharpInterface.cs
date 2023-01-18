using Devantler.Commons.CodeGen.Core;
using Devantler.Commons.CodeGen.Core.Base;
using Devantler.Commons.CodeGen.Core.Interfaces;
using Scriban;
using Scriban.Runtime;

namespace Devantler.Commons.CodeGen.CSharp.Models;

/// <summary>
///     A model representing a C# interface.
/// </summary>
public class CSharpInterface : InterfaceBase
{
    /// <summary>
    ///     Creates a new interface.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="namespace"></param>
    /// <param name="documentation"></param>
    public CSharpInterface(string name, string @namespace, string? documentation = default) : base(name, @namespace)
    {
        if (!string.IsNullOrWhiteSpace(documentation))
            DocBlock = new CSharpDocBlock(documentation);
    }

    /// <inheritdoc />
    public override IDocBlock? DocBlock { get; }

    /// <inheritdoc />
    public override string Compile(string? assemblyPath = default)
    {
        var context = new TemplateContext
        {
            TemplateLoader = new TemplateLoader()
        };
        var script = new ScriptObject();
        script.Import(this);
        context.PushGlobal(script);
        const string interfaceTemplatePath = "templates/interface.sbn-cs";
        string filePath = !string.IsNullOrEmpty(assemblyPath) ?
            $"{assemblyPath}/{interfaceTemplatePath}" :
            interfaceTemplatePath;
        var template = Template.Parse(File.ReadAllText(filePath), filePath);
        return template.Render(context);
    }
}
