using CS426.node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/* TODO:
 * file                 |
 * const_declarations   |
 * funct_declarations   |
 * main_declaration     |
 * bool_exp             |
 * bool_term            |
 * bool_not             |
 * bool_comp            |
 * bool_parens          |
 * num_comp             |   Done
 * expression           |   Done
 * term                 |   Divide needs to check if divisor is a zero
 * negation             |   Done
 * parenthetical_exp    |   Done
 * operand              |   Done
 * literal              |   Done           
 * param_declarations   |
 * param_declaration    |
 * statements           |
 * statement            |
 * var_dec              |   Done
 * opt_assignment       |
 * funct_call           |
 * call_params          |
 * assignment           |   Done
 * if_stmt              |
 * else_stmt            |
 * loop_stmt            |
 */

namespace CS426.analysis
{
    class SemanticAnalyzer : DepthFirstAdapter
    {
        // Global Symbol Table: Keep track of global stuff
        // Such as: Function defs, data types, constants
        Dictionary<string, Definition> globalSymbolTable = new Dictionary<string, Definition>();

        // Local Symbol Table: Keep track of local stuff
        // Such as: local vars
        Dictionary<string, Definition> localSymbolTable = new Dictionary<string, Definition>();

        // This is out decorated parse tree
        Dictionary<Node, Definition> decoratedParseTree = new Dictionary<Node, Definition>();

        public void PrintWarning(Token t, String message)
        {
            Console.WriteLine("Line " + t.Line + ", Col " + t.Pos + ": " + message);
        }

        public override void InAFile(AFile node)
        {
            // Create a definition for Ints
            Definition intDef = new NumberDefinition();
            intDef.name = "int";

            // Create a definition for Strings
            Definition strDef = new StringDefinition();
            strDef.name = "str";

            // Create a definition for Floats
            Definition floatDef = new FloatDefinition();
            floatDef.name = "float";

            // Register the definitions with the global symbol table
            globalSymbolTable.Add("int", intDef);
            globalSymbolTable.Add("str", strDef);
            globalSymbolTable.Add("float", floatDef);
        }


        // --------------------------------------------------------
        // Literals
        // --------------------------------------------------------
        public override void OutAIntLiteral(AIntLiteral node)
        {
            // Create the definition
            Definition intDef = new NumberDefinition();
            intDef.name = "int";

            decoratedParseTree.Add(node, intDef);
        }

        public override void OutAStrLiteral(AStrLiteral node)
        {
            // Create the defintion
            Definition strDef = new StringDefinition();
            strDef.name = "str";

            decoratedParseTree.Add(node, strDef);
        }

        public override void OutAFloatLiteral(AFloatLiteral node)
        {
            // Create the definition
            Definition floatDef = new FloatDefinition();
            floatDef.name = "float";

            decoratedParseTree.Add(node, floatDef);
        }

        // --------------------------------------------------------
        // Operands
        // --------------------------------------------------------
        public override void OutAVarOperand(AVarOperand node)
        {
            // Get the name of the ID
            String varName = node.GetId().Text;

            Definition varDef;

            // Test if varName is in symbol table
            if (!localSymbolTable.TryGetValue(varName, out varDef))
            {
                PrintWarning(node.GetId(), varName + " does not exist");
            }

            // Test if varDefinition is actually a variable
            else if (!(varDef is VariableDefinition))
            {
                PrintWarning(node.GetId(), varName + " is not a variable");
            }

            // Variable is a variable
            else
            {
                VariableDefinition v = (VariableDefinition)varDef;

                // Decorating node with type of variable
                decoratedParseTree.Add(node, v.variableType);
            }
        }

        public override void OutALitOperand(ALitOperand node)
        {
            Definition litDefintion;

            if (!decoratedParseTree.TryGetValue(node.GetLiteral(), out litDefintion))
            {
                Console.WriteLine("Literal does not exist");
            }

            decoratedParseTree.Add(node, litDefintion);
        }

        // --------------------------------------------------------
        // Parenthetical Expression
        // --------------------------------------------------------
        public override void OutANoneParentheticalExp(ANoneParentheticalExp node)
        {
            Definition operandDefinition;

            if (!decoratedParseTree.TryGetValue(node.GetOperand(), out operandDefinition))
            {
                // The error was already printed at a higher level
            }
            else
            {
                decoratedParseTree.Add(node, operandDefinition);
            }
        }

        public override void OutASomeParentheticalExp(ASomeParentheticalExp node)
        {
            Definition expression;

            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expression))
            {
                // The error was already printed at a higher level
            }
            else
            {
                decoratedParseTree.Add(node, expression);
            }
        }

        // --------------------------------------------------------
        // Negation
        // --------------------------------------------------------
        public override void OutAPosNegation(APosNegation node)
        {
            Definition parentheticalExp;

            if (!decoratedParseTree.TryGetValue(node.GetParentheticalExp(), out parentheticalExp))
            {
                // The error was already printed at a higher level
            }
            else
            {
                decoratedParseTree.Add(node, parentheticalExp);
            }
        }

        public override void OutANegNegation(ANegNegation node)
        {
            Definition parentheticalExp;

            if (!decoratedParseTree.TryGetValue(node.GetParentheticalExp(), out parentheticalExp))
            {
                // The error was already printed at a higher level
            }
            else if (!((parentheticalExp is NumberDefinition) || (parentheticalExp is FloatDefinition)))
            {
                PrintWarning(node.GetMinusSign(), "Only a number or float can be negated!");
            }
            else
            {
                decoratedParseTree.Add(node, parentheticalExp);
            }
        }

        // --------------------------------------------------------
        // Term
        // --------------------------------------------------------
        public override void OutASingleTerm(ASingleTerm node)
        {
            Definition negationDefinition;

            if (!decoratedParseTree.TryGetValue(node.GetNegation(), out negationDefinition))
            {
                // The error was already printed at a higher level
            }
            else
            {
                decoratedParseTree.Add(node, negationDefinition);
            }
        }

        public override void OutAMultTerm(AMultTerm node)
        {
            Definition termDef;
            Definition negationDef;

            // Check if term expression is already in the decorated tree
            if (!decoratedParseTree.TryGetValue(node.GetTerm(), out termDef))
            {
                // Error already printed
            }
            // Check if negation expression is already in the decorated tree
            else if (!decoratedParseTree.TryGetValue(node.GetNegation(), out negationDef))
            {
                // Error already printed
            }
            // Check if the types of the expressions match
            else if ((termDef.name == "str") || (negationDef.name == "str"))
            {
                PrintWarning(node.GetStar(), "Cannot multiply " + termDef.name + " by " + negationDef.name);
            }
            // Check if the expressions are numbers
            else if (!((termDef is NumberDefinition) || (termDef is FloatDefinition) || (negationDef is NumberDefinition) || (negationDef is FloatDefinition)))
            {
                PrintWarning(node.GetStar(), "You can only multiply numbers or floats");
            }
            else
            {
                decoratedParseTree.Add(node, termDef);
            }
        }

        public override void OutADivTerm(ADivTerm node)
        {
            Definition termDef;
            Definition negationDef;

            // Check if term expression is already in the decorated tree
            if (!decoratedParseTree.TryGetValue(node.GetTerm(), out termDef))
            {
                // Error already printed
            }
            // Check if negation expression is already in the decorated tree
            else if (!decoratedParseTree.TryGetValue(node.GetNegation(), out negationDef))
            {
                // Error already printed
            }
            // Check if the types of the expressions match
            else if ((termDef.name == "str") || (negationDef.name == "str"))
            {
                PrintWarning(node.GetSlash(), "Cannot divide " + termDef.name + " by " + negationDef.name);
            }
            // TODO: Check if the negation term is not zero
            else if (negationDef.Equals(0))
            {
                PrintWarning(node.GetSlash(), "You can't divide by zero");
            }
            // Check if the expressions are numbers
            else if (!((termDef is NumberDefinition) || (termDef is FloatDefinition) || (negationDef is NumberDefinition) || (negationDef is FloatDefinition)))
            {
                PrintWarning(node.GetSlash(), "You can only divide numbers");
            }
            else
            {
                decoratedParseTree.Add(node, termDef);
            }
        }

        // --------------------------------------------------------
        // Expression
        // --------------------------------------------------------
        public override void OutASoloExpression(ASoloExpression node)
        {
            Definition expressionDefinition;

            if (!decoratedParseTree.TryGetValue(node.GetTerm(), out expressionDefinition))
            {
                // The error was already printed at a higher level
            }
            else
            {
                decoratedParseTree.Add(node, expressionDefinition);
            }
        }

        public override void OutAPlusExpression(APlusExpression node)
        {
            Definition expressionDef;
            Definition termDef;

            // Check if expression is already in the decorated tree
            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                // Error already printed
            }
            // Check if term expression is already in the decorated tree
            else if (!decoratedParseTree.TryGetValue(node.GetTerm(), out termDef))
            {
                // Error already printed
            }
            // Check if any type is a string
            else if ((termDef.name == "str") || (expressionDef.name == "str"))
            {
                PrintWarning(node.GetPlusSign(), "Cannot add " + expressionDef.name + " by " + termDef.name);
            }
            // Check if the expressions are numbers
            else if (!((termDef is NumberDefinition) || (termDef is FloatDefinition) || (expressionDef is NumberDefinition) || (expressionDef is FloatDefinition)))
            {
                PrintWarning(node.GetPlusSign(), "You can only add numbers or floats");
            }
            else
            {
                decoratedParseTree.Add(node, expressionDef);
            }
        }

        public override void OutAMinusExpression(AMinusExpression node)
        {
            Definition expressionDef;
            Definition termDef;

            // Check if expression is already in the decorated tree
            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                // Error already printed
            }
            // Check if term expression is already in the decorated tree
            else if (!decoratedParseTree.TryGetValue(node.GetTerm(), out termDef))
            {
                // Error already printed
            }
            // Check if any type is a string
            else if ((termDef.name == "str") || (expressionDef.name == "str"))
            {
                PrintWarning(node.GetMinusSign(), "Cannot subtract " + expressionDef.name + " by " + termDef.name);
            }
            // Check if the expressions are numbers
            else if (!((termDef is NumberDefinition) || (termDef is FloatDefinition) || (expressionDef is NumberDefinition) || (expressionDef is FloatDefinition)))
            {
                PrintWarning(node.GetMinusSign(), "You can only subtract numbers or floats");
            }
            else
            {
                decoratedParseTree.Add(node, expressionDef);
            }
        }

        // --------------------------------------------------------
        // Number Comparison
        // --------------------------------------------------------
        public override void OutANotEqualNumComp(ANotEqualNumComp node)
        {
            Definition LHSExpressionDef;
            Definition RHSExpressionDef;

            // Check if lhs is already in decorated tree
            if (!decoratedParseTree.TryGetValue(node.GetLhs(), out LHSExpressionDef))
            {
                // Error already printed
            }
            // Check if rhs is already in decorated tree
            else if(!decoratedParseTree.TryGetValue(node.GetRhs(), out RHSExpressionDef))
            {
                // Error already printed
            }
            // Check is the lhs and rhs are the same types
            else if(LHSExpressionDef.name != RHSExpressionDef.name)
            {
                PrintWarning(node.GetNeqSign(), "Cannot compare different types");
            }
            else
            {
                decoratedParseTree.Add(node, LHSExpressionDef);
            }
        }

        public override void OutAEqualNumComp(AEqualNumComp node)
        {
            Definition LHSExpressionDef;
            Definition RHSExpressionDef;

            // Check if lhs is already in decorated tree
            if (!decoratedParseTree.TryGetValue(node.GetLhs(), out LHSExpressionDef))
            {
                // Error already printed
            }
            // Check if rhs is already in decorated tree
            else if (!decoratedParseTree.TryGetValue(node.GetRhs(), out RHSExpressionDef))
            {
                // Error already printed
            }
            // Check is the lhs and rhs are the same types
            else if (LHSExpressionDef.name != RHSExpressionDef.name)
            {
                PrintWarning(node.GetEqSign(), "Cannot compare different types");
            }
            else
            {
                decoratedParseTree.Add(node, LHSExpressionDef);
            }
        }

        public override void OutAGreaterEqualNumComp(AGreaterEqualNumComp node)
        {
            Definition LHSExpressionDef;
            Definition RHSExpressionDef;

            // Check if lhs is already in decorated tree
            if (!decoratedParseTree.TryGetValue(node.GetLhs(), out LHSExpressionDef))
            {
                // Error already printed
            }
            // Check if rhs is already in decorated tree
            else if (!decoratedParseTree.TryGetValue(node.GetRhs(), out RHSExpressionDef))
            {
                // Error already printed
            }
            // Check is the lhs and rhs are the same types
            else if (LHSExpressionDef.name != RHSExpressionDef.name)
            {
                PrintWarning(node.GetGeqSign(), "Cannot compare different types");
            }
            else
            {
                decoratedParseTree.Add(node, LHSExpressionDef);
            }
        }

        public override void OutAGreaterNumComp(AGreaterNumComp node)
        {
            Definition LHSExpressionDef;
            Definition RHSExpressionDef;

            // Check if lhs is already in decorated tree
            if (!decoratedParseTree.TryGetValue(node.GetLhs(), out LHSExpressionDef))
            {
                // Error already printed
            }
            // Check if rhs is already in decorated tree
            else if (!decoratedParseTree.TryGetValue(node.GetRhs(), out RHSExpressionDef))
            {
                // Error already printed
            }
            // Check is the lhs and rhs are the same types
            else if (LHSExpressionDef.name != RHSExpressionDef.name)
            {
                PrintWarning(node.GetGtSign(), "Cannot compare different types");
            }
            else
            {
                decoratedParseTree.Add(node, LHSExpressionDef);
            }
        }

        public override void OutALessEqualNumComp(ALessEqualNumComp node)
        {
            Definition LHSExpressionDef;
            Definition RHSExpressionDef;

            // Check if lhs is already in decorated tree
            if (!decoratedParseTree.TryGetValue(node.GetLhs(), out LHSExpressionDef))
            {
                // Error already printed
            }
            // Check if rhs is already in decorated tree
            else if (!decoratedParseTree.TryGetValue(node.GetRhs(), out RHSExpressionDef))
            {
                // Error already printed
            }
            // Check is the lhs and rhs are the same types
            else if (LHSExpressionDef.name != RHSExpressionDef.name)
            {
                PrintWarning(node.GetLeqSign(), "Cannot compare different types");
            }
            else
            {
                decoratedParseTree.Add(node, LHSExpressionDef);
            }
        }

        public override void OutALessNumComp(ALessNumComp node)
        {
            Definition LHSExpressionDef;
            Definition RHSExpressionDef;

            // Check if lhs is already in decorated tree
            if (!decoratedParseTree.TryGetValue(node.GetLhs(), out LHSExpressionDef))
            {
                // Error already printed
            }
            // Check if rhs is already in decorated tree
            else if (!decoratedParseTree.TryGetValue(node.GetRhs(), out RHSExpressionDef))
            {
                // Error already printed
            }
            // Check is the lhs and rhs are the same types
            else if (LHSExpressionDef.name != RHSExpressionDef.name)
            {
                PrintWarning(node.GetLtSign(), "Cannot compare different types");
            }
            else
            {
                decoratedParseTree.Add(node, LHSExpressionDef);
            }
        }

        // --------------------------------------------------------
        // Variable Declaration
        // --------------------------------------------------------
        public override void OutAVarDec(AVarDec node)
        {
            Definition typeDef;
            Definition idDef;

            if(!globalSymbolTable.TryGetValue(node.GetRwType().Text, out typeDef))
            {
                PrintWarning(node.GetRwType() , "Type " + node.GetType().Name + " does not exist");
            }
            else if(!(typeDef is TypeDefinition))
            {
                PrintWarning(node.GetRwType(), "Identifier " + node.GetRwType().Text + " is not a recognized data type");
            }
            else if(localSymbolTable.TryGetValue(node.GetId().Text, out idDef))
            {
                PrintWarning(node.GetId(), "Identifier " + node.GetId().Text + " is already being used");
            }
            else if (globalSymbolTable.TryGetValue(node.GetId().Text, out idDef))
            {
                PrintWarning(node.GetId(), "Identifier " + node.GetId().Text + " is already being used");
            }
            else
            {
                VariableDefinition newVarDef = new VariableDefinition();
                newVarDef.name = node.GetId().Text;
                newVarDef.variableType = (TypeDefinition)typeDef;

                localSymbolTable.Add(node.GetId().Text, newVarDef);
            }
        }

        // --------------------------------------------------------
        // Assignment
        // --------------------------------------------------------
        public override void OutAAssignment(AAssignment node)
        {
            Definition idDef;
            Definition expressionDef;

            if(!localSymbolTable.TryGetValue(node.GetId().Text, out idDef))
            {
                PrintWarning(node.GetId(), "Identifier " + node.GetId().Text + " does not exist");
            }
            else if(!(idDef is VariableDefinition))
            {
                PrintWarning(node.GetId(), "Identifier " + node.GetId().Text + " is not a variable");
            }
            else if(!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                // Error would have already been printed
            }
            else if(((VariableDefinition)idDef).variableType.name != expressionDef.name)
            {
                PrintWarning(node.GetId(), "Types don't match");
            }
            else
            {
                // No need to decorate parse tree
            }

        }

    }
}