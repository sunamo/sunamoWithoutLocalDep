using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoRoslyn2_LaterMergeToSunamoRoslyn;

public class ModelCollector : CSharpSyntaxWalker
{
    public Dictionary<string, List<string>> Models { get; } = new Dictionary<string, List<string>>();
    public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
    {
        var classnode = node.Parent as ClassDeclarationSyntax;
        if (!Models.ContainsKey(classnode.Identifier.ValueText))
        {
            Models.Add(classnode.Identifier.ValueText, new List<string>());
        }

        Models[classnode.Identifier.ValueText].Add(node.Identifier.ValueText);
    }
}

