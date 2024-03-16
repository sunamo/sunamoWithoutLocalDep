using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunamoRoslyn2_LaterMergeToSunamoRoslyn.Collectors;
internal class DelegatesCollector : CSharpSyntaxWalker
{
    public List<DelegateDeclarationSyntax> Delegates = new List<DelegateDeclarationSyntax>();
    public List<ClassDeclarationSyntax> Classes = new List<ClassDeclarationSyntax>();
    public List<InterfaceDeclarationSyntax> Interfaces = new List<InterfaceDeclarationSyntax>();
    public List<RecordDeclarationSyntax> Records = new List<RecordDeclarationSyntax>();
    public List<StructDeclarationSyntax> Structs = new List<StructDeclarationSyntax>();
    public List<EnumDeclarationSyntax> Enums = new List<EnumDeclarationSyntax>();

    public override void VisitDelegateDeclaration(DelegateDeclarationSyntax node)
    {
        Delegates.Add(node);
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        Classes.Add(node);
    }

    public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
    {
        Interfaces.Add(node);
    }

    public override void VisitRecordDeclaration(RecordDeclarationSyntax node)
    {
        Records.Add(node);
    }

    public override void VisitStructDeclaration(StructDeclarationSyntax node)
    {
        Structs.Add(node);
    }

    public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
    {
        Enums.Add(node);
    }
}
