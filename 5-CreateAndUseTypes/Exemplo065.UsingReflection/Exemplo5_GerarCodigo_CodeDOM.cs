using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exemplo065.UsingReflection
{
    // Exemplo mostra o uso do Code DOM (Documento Object Model)
    // CodeDOM pode ser usado p/ criar um objeto "graph" que pode ser convertido
    // para um "source file" ou um assembly binário que pode ser executado
    public static class Exemplo5_GerarCodigo_CodeDOM
    {
        public static void ExecutarExemplo()
        {
            string myNameSpace = "Exemplo065.UsingReflection";

            // CodeCompileUnit representa o "container" de nível mais alto do CodeDOM
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            CodeNamespace myNamespace = new CodeNamespace(myNameSpace);     // Cria um namespace
            myNamespace.Imports.Add(new CodeNamespaceImport(myNameSpace));  // Importa o namespace

            CodeTypeDeclaration myClass = new CodeTypeDeclaration("MyClass"); // Cria uma classe

            CodeEntryPointMethod start = new CodeEntryPointMethod();        // Cria ponto de entrada (método Main)
            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("Console"),
                "WriteLine", new CodePrimitiveExpression("Hello World!")
            );

            compileUnit.Namespaces.Add(myNamespace);
            myNamespace.Types.Add(myClass);
            myClass.Members.Add(start);
            start.Statements.Add(cs1);

            // Cria um arquivo fonte a partir do CodeCompileUnit
            CSharpCodeProvider provider = new CSharpCodeProvider();
            using (StreamWriter sw = new StreamWriter("HelloWorld.cs", false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, " ");
                provider.GenerateCodeFromCompileUnit(compileUnit, tw,
                new CodeGeneratorOptions());
                tw.Close();
            }
        }
    }
}
