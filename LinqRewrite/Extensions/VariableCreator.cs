using System.Linq;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.Extensions
{
    public static class VariableCreator
    {
        public static int VariableIndex;
        public static LocalVariable SuperGlobalVariable(RewriteParameters p, TypeSyntax type, ValueBridge initial)
        {
            var variable = "v" + VariableIndex++ % 10_000;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            p.Variables.Add(created);
            
            p.InitialAdd(LocalVariableCreation(variable, type));
            p.InitialAdd(((ValueBridge)variable).Assign(initial));
            p.SimpleEnumeration = false;
            return created;
        }
        
        public static LocalVariable GlobalVariable(RewriteParameters p, TypeSyntax type)
        {
            var variable = "v" + VariableIndex++ % 10_000;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            p.Variables.Add(created);
            
            p.InitialAdd(LocalVariableCreation(variable, type));
            p.SimpleEnumeration = false;
            return created;
        }
        
        public static LocalVariable GlobalVariable(RewriteParameters p, TypeSyntax type, ValueBridge initial, IteratorParameters iterator)
        {
            var variable = "v" + VariableIndex++ % 10_000;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            p.Variables.Add(created);
            
            p.InitialAdd(LocalVariableCreation(variable, type));
            iterator.PreFor.Add((StatementBridge)((ValueBridge)variable).Assign(initial));
            p.SimpleEnumeration = false;
            return created;
        }
        
        public static LocalVariable GlobalVariable(RewriteParameters p, TypeSyntax type, ValueBridge initial)
        {
            var variable = "v" + VariableIndex++ % 10_000;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            p.Variables.Add(created);
            
            p.InitialAdd(LocalVariableCreation(variable, type));
            p.PreUseAdd(((ValueBridge)variable).Assign(initial));
            p.SimpleEnumeration = false;
            return created;
        }

        public static LocalVariable LocalVariable(RewriteParameters p, TypedValueBridge value)
            => LocalVariable(p, value.Type, value);
        
        public static LocalVariable LocalVariable(RewriteParameters p, TypeBridge type, ValueBridge initial)
        {
            var variable = "v" + VariableIndex++ % 10_000;
            var stringType = type.ToString();
            var found = p.Variables.FirstOrDefault(x => stringType == x.Type.ToString() && !x.IsGlobal && !x.IsUsed);
            if (found != null)
            {
                found.IsUsed = true;
                return found;
            }
            var created = new LocalVariable(variable, type);
            p.Variables.Add(created);
            
            p.InitialAdd(LocalVariableCreation(variable, type));
            p.PreUseAdd(((ValueBridge)variable).Assign(initial));
            p.SimpleEnumeration = false;
            return created;
        }
        
        public static LocalVariable LocalVariable(RewriteParameters p, TypeBridge type)
        {
            var stringType = type.ToString();
            var found = p.Variables.FirstOrDefault(x => stringType == x.Type.ToString() && !x.IsGlobal && !x.IsUsed);
            if (found != null)
            {
                found.IsUsed = true;
                return found;
            }
            var variable = "v" + VariableIndex++ % 10_000;
            var created = new LocalVariable(variable, type);
            p.Variables.Add(created);

            p.InitialAdd(LocalVariableCreation(variable, type));
            p.SimpleEnumeration = false;
            return created;
        }
    }
}