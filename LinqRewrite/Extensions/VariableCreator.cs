using System.Linq;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.Extensions
{
    public static class VariableCreator
    {
        public static int VariableIndex;
        public static LocalVariable SuperGlobalVariable(RewriteDesign design, TypeSyntax type, ValueBridge initial)
        {
            var variable = "v" + VariableIndex++ % 10_000;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            design.Variables.Add(created);
            
            design.InitialAdd(LocalVariableCreation(variable, type));
            design.InitialAdd(((ValueBridge)variable).Assign(initial));
            design.SimpleEnumeration = false;
            return created;
        }
        
        public static LocalVariable GlobalVariable(RewriteDesign design, TypeSyntax type)
        {
            var variable = "v" + VariableIndex++ % 10_000;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            design.Variables.Add(created);
            
            design.InitialAdd(LocalVariableCreation(variable, type));
            design.SimpleEnumeration = false;
            return created;
        }
        
        public static LocalVariable GlobalVariable(RewriteDesign design, TypeSyntax type, ValueBridge initial, IteratorDesign iterator)
        {
            var variable = "v" + VariableIndex++ % 10_000;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            design.Variables.Add(created);
            
            design.InitialAdd(LocalVariableCreation(variable, type));
            iterator.PreFor.Add((StatementBridge)((ValueBridge)variable).Assign(initial));
            design.SimpleEnumeration = false;
            return created;
        }
        
        public static LocalVariable GlobalVariable(RewriteDesign design, TypeSyntax type, ValueBridge initial)
        {
            var variable = "v" + VariableIndex++ % 10_000;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            design.Variables.Add(created);
            
            design.InitialAdd(LocalVariableCreation(variable, type));
            design.PreUseAdd(((ValueBridge)variable).Assign(initial));
            design.SimpleEnumeration = false;
            return created;
        }

        public static LocalVariable LocalVariable(RewriteDesign design, TypedValueBridge value)
            => LocalVariable(design, value.Type, value);
        
        public static LocalVariable LocalVariable(RewriteDesign design, TypeBridge type, ValueBridge initial)
        {
            var variable = "v" + VariableIndex++ % 10_000;
            var stringType = type.ToString();
            var found = design.Variables.FirstOrDefault(x => stringType == x.Type.ToString() && !x.IsGlobal && !x.IsUsed);
            if (found != null)
            {
                found.IsUsed = true;
                return found;
            }
            var created = new LocalVariable(variable, type);
            design.Variables.Add(created);
            
            design.InitialAdd(LocalVariableCreation(variable, type));
            design.PreUseAdd(((ValueBridge)variable).Assign(initial));
            design.SimpleEnumeration = false;
            return created;
        }
        
        public static LocalVariable LocalVariable(RewriteDesign design, TypeBridge type)
        {
            var stringType = type.ToString();
            var found = design.Variables.FirstOrDefault(x => stringType == x.Type.ToString() && !x.IsGlobal && !x.IsUsed);
            if (found != null)
            {
                found.IsUsed = true;
                return found;
            }
            var variable = "v" + VariableIndex++ % 10_000;
            var created = new LocalVariable(variable, type);
            design.Variables.Add(created);

            design.InitialAdd(LocalVariableCreation(variable, type));
            design.SimpleEnumeration = false;
            return created;
        }
    }
}