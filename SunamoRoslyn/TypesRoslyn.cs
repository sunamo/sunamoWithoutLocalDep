namespace SunamoRoslyn;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class TypesRoslyn
{
    public static readonly Type Class = typeof(ClassDeclarationSyntax);
    public static readonly Type Interface = typeof(InterfaceDeclarationSyntax);
    public static readonly Type Enum = typeof(EnumDeclarationSyntax);
    public static readonly Type Delegate = typeof(DelegateDeclarationSyntax);
    public static readonly Type Record = typeof(RecordDeclarationSyntax);