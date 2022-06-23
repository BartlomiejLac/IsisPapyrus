using IsisPapyrus.Exceptions;
using IsisPapyrus.InterpreterRuntime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IsisParser;

namespace IsisPapyrus.VisitorClasses
{
    internal class ExpressionEvaluator
    {
        public Dictionary<string, IsisVariable> localVariables;
        public IsisProgram ownerProgram;

        public ExpressionEvaluator(ref Dictionary<string, IsisVariable> localVariables, ref IsisProgram program)
        {
            this.localVariables = localVariables;
            this.ownerProgram = program;
        }
        public object EvaluateExpression(ExpressionContext ctx)
        {
            if (ctx.variable() != null)
            {
                EvaluateModifyVariableExpression(ctx);
                return null;
            }
            if (ctx.declarationVariable() != null)
            {
                EvaluateDeclarationVariableExpression(ctx);
                return null;
            }
            if (ctx.sumExpression() != null)
            {
                return EvaluateSumExpression(ctx.sumExpression());
            }
            if (ctx.boolExpression() != null)
            {
                return EvaluateBoolExpression(ctx.boolExpression());
            }
            throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "This expression cannot be evaluated");
        }

        private void EvaluateDeclarationVariableExpression(ExpressionContext ctx)
        {
            var name = ctx.declarationVariable().variableName().IDENTIFIER().GetText();
            varType type = varType.IsisVoid;
            if (ctx.declarationVariable().type().NUMERIC() != null) type = varType.IsisNumber;
            if (ctx.declarationVariable().type().STRING() != null) type = varType.IsisString;
            object value = null;
            if (ctx.ASSIGN() != null) value = EvaluateSumExpression(ctx.sumExpression());
            if (localVariables.ContainsKey(name)) throw new RuntimeException(ctx.declarationVariable().variableName().Start.Line, 
                ctx.declarationVariable().variableName().Start.Column, 
                "Variable " + name + " already exists in this scope");
            if (ownerProgram.globalVariables.ContainsKey(name)) throw new RuntimeException(ctx.declarationVariable().variableName().Start.Line,
                ctx.declarationVariable().variableName().Start.Column,
                "Variable " + name + " already exists in this scope"); 
            localVariables.Add(name, new IsisVariable(type, value));
        }

        public void EvaluateModifyVariableExpression(ExpressionContext ctx)
        {
            var name = ctx.variable().IDENTIFIER().GetText();
            IsisVariable variable;
            if (!localVariables.ContainsKey(name))
            {
                if (!ownerProgram.globalVariables.ContainsKey(name)) throw new RuntimeException(ctx.variable().Start.Line,
                    ctx.variable().Start.Column,
                    "Variable " + name + " does not exist in this scope");
                variable = ownerProgram.globalVariables[name];
            }
            else
            {
                variable = localVariables[name];
            }
            if (ctx.ASSIGN() != null)
            {
                try
                {
                    variable.setValue(EvaluateSumExpression(ctx.sumExpression()));
                    return;
                } catch(VariableTypeException ex) { throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Variable " + name + " of type " + ex.Message + " cannot be assigned with this type"); } 
            }
            if (variable.type == varType.IsisString) throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "This operation cannot be applied to string");
            if (ctx.INCREMENT() != null)
            {
                try
                {
                    variable.setValue((Number)variable.value + new Number(1, 0, 1));
                    return;
                }
                catch (VariableTypeException ex) { throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Variable " + name + " of type " + ex.Message + " cannot be assigned with this type"); }

            }
            if (ctx.DECREMENT() != null)
            {
                try
                {
                    variable.setValue((Number)variable.value - new Number(1, 0, 1));
                    return;
                }
                catch (VariableTypeException ex) { throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Variable " + name + " of type " + ex.Message + " cannot be assigned with this type"); }
            }
            var r = EvaluateSumExpression(ctx.sumExpression());
            if (!(r is Number)) throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "This operation cannot be applied to string");
            Number result = r as Number;
            if (ctx.INCREMENTBY() != null)
            {
                try
                {
                    variable.setValue((Number)variable.value + result);
                    return;
                }
                catch (VariableTypeException ex) { throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Variable " + name + " of type " + ex.Message + " cannot be assigned with this type"); }
            }
            if (ctx.DECREMENTBY() != null)
            {
                try
                {
                    variable.setValue((Number)variable.value - result);
                    return;
                }
                catch (VariableTypeException ex) { throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Variable " + name + " of type " + ex.Message + " cannot be assigned with this type"); }
            }
            if (ctx.MULTIPLYBY() != null)
            {
                try
                {
                    variable.setValue((Number)variable.value * result);
                    return;
                }
                catch (VariableTypeException ex) { throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Variable " + name + " of type " + ex.Message + " cannot be assigned with this type"); }
            }
            if (ctx.DIVIDEBY() != null)
            {
                try
                {
                    variable.setValue((Number)variable.value / result);
                    return;
                }
                catch (VariableTypeException ex) { throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Variable " + name + " of type " + ex.Message + " cannot be assigned with this type"); }
            }
        }

        public object EvaluateSumExpression(SumExpressionContext ctx)
        {
            if (ctx.sumExpression() == null)
            {
                return EvaluateMultExpression(ctx.multExpression());
            }
            var A = EvaluateSumExpression(ctx.sumExpression());
            var B = EvaluateMultExpression(ctx.multExpression());
            if (A is Number && B is Number)
            {
                if (ctx.sumOperator().PLUS() != null) return (Number)A + (Number)B;
                return (Number)A - (Number)B;
            }
            if (ctx.sumOperator().MINUS() != null) throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "This operation cannot be applied to string");
            if (A is string && B is string)
            {
                return (string)A + (string)B;
            }
            if (A is string && B is Number)
            {
                Number numB = B as Number;
                return (string)A + numB.ToString();
            }
            if (A is Number && B is string)
            {
                Number numA = A as Number;
                return numA.ToString() + (string)B;
            }
            throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "This expression cannot be evaluated");
        }

        public object EvaluateMultExpression(MultExpressionContext ctx)
        {
            if (ctx.multExpression() == null) return EvaluateUnaryExpression(ctx.unaryExpression());
            var A = EvaluateMultExpression(ctx.multExpression());
            var B = EvaluateUnaryExpression(ctx.unaryExpression());
            if (A is Number && B is Number)
            {
                if (ctx.multOperator().MULTSYMBOL() != null) return (Number)A * (Number)B;
                return (Number)A / (Number)B;
            }
            throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "This operation cannot be applied to string");
        }

        public object EvaluateUnaryExpression(UnaryExpressionContext ctx)
        {
            if (ctx.unaryExpression() == null) return EvaluateFactor(ctx.factor());
            var A = EvaluateUnaryExpression(ctx.unaryExpression());
            if (!(A is Number)) throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "This operation cannot be applied to string");
            var numA = A as Number;
            if (ctx.unaryOperator().PLUS() != null) return numA;
            else return -numA;
        }

        public object EvaluateFactor(FactorContext ctx)
        {
            if (ctx.variable() != null)
            {
                var name = ctx.variable().IDENTIFIER().GetText();
                IsisVariable variable;
                if (!localVariables.ContainsKey(name))
                {
                    if (!ownerProgram.globalVariables.ContainsKey(name)) throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Variable " + name + " does not exist in this scope");
                    variable = ownerProgram.globalVariables[name];
                }
                else
                {
                    variable = localVariables[name];
                }
                if (variable.value == null) throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Variable " + name + " was declared but not assigned");
                return variable.value;
            }
            if (ctx.constant() != null)
            {
                if (ctx.constant().STRINGCONST() != null)
                {
                    string text = ctx.constant().STRINGCONST().GetText();
                    return text.Replace("𓎛", "");
                }
                if (ctx.constant().NUMBERCONST() != null)
                {
                    Number num = EgyptianNumberParser.fromEgyptian(ctx.constant().NUMBERCONST().GetText());
                    return num;
                }
                throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "Unrecognized constant");
            }
            if (ctx.sumExpression() != null)
            {
                return EvaluateSumExpression(ctx.sumExpression());
            }
            if (ctx.functionCall() != null)
            {
                return EvaluateFunctionCall(ctx.functionCall());
            }
            throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "This expression cannot be evaluated");
        }

        public object EvaluateFunctionCall(FunctionCallContext ctx)
        {
            var name = ctx.IDENTIFIER().GetText();
            if (!ownerProgram.globalFunctions.ContainsKey(name)) throw new RuntimeException(ctx.Start.Line, ctx.Start.Column,
                "Function " + name + " was not declared");
            var func = ownerProgram.globalFunctions[name];
            var arguments = new List<SumExpressionContext>();
            var sctx = ctx.sumExpressions().sumExpressionsList();
            while (sctx != null)
            {
                var sumEx = sctx.sumExpression();
                if (sumEx != null) arguments.Add(sumEx);
                sctx = sctx.sumExpressionsList();
            }
            var functionExecutor = new FunctionExecutor(ref ownerProgram);
            return functionExecutor.ExecuteFunction(func, arguments);
        }

        public bool EvaluateBoolExpression(BoolExpressionContext ctx)
        {
            if (ctx.boolExpression() == null) return EvaluateAndExpression(ctx.andExpression());
            return EvaluateBoolExpression(ctx.boolExpression()) || EvaluateAndExpression(ctx.andExpression());
        }

        public bool EvaluateAndExpression(AndExpressionContext ctx)
        {
            if (ctx.andExpression() == null) return EvaluateNotExpression(ctx.notExpression());
            return EvaluateAndExpression(ctx.andExpression()) && EvaluateNotExpression(ctx.notExpression());
        }

        public bool EvaluateNotExpression(NotExpressionContext ctx)
        {
            if (ctx.notExpression() == null) return EvaluateCompareExpression(ctx.compareExpression());
            return !EvaluateNotExpression(ctx.notExpression());
        }

        public bool EvaluateCompareExpression(CompareExpressionContext ctx)
        {
            if (ctx.BOOLCONST() != null)
            {
                if (ctx.BOOLCONST().GetText() == "𓀾") return true;
                else return false;
            }
            var A = EvaluateSumExpression(ctx.sumExpression()[0]);
            var B = EvaluateSumExpression(ctx.sumExpression()[1]);
            if (A is Number && B is Number)
            {
                Number numA = A as Number;
                Number numB = B as Number;
                if (ctx.compareOperator().LESSER() != null) return numA < numB;
                if (ctx.compareOperator().GREATER() != null) return numA > numB;
                if (ctx.compareOperator().LESSEREQUAL() != null) return numA <= numB;
                if (ctx.compareOperator().GREATEREQUAL() != null) return numA >= numB;
                if (ctx.compareOperator().EQUALS() != null) return numA == numB;
                if (ctx.compareOperator().NOTEQUALS() != null) return numA != numB;
            }
            if (A is string && B is string)
            {
                if (ctx.compareOperator().EQUALS() != null) return A == B;
                if (ctx.compareOperator().NOTEQUALS() != null) return A != B;
            }
            throw new RuntimeException(ctx.Start.Line, ctx.Start.Column, "This operation cannot be applied to string");
        }
    }
}
