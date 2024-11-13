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
 * bool_exp             |   Done
 * bool_term            |   Done
 * bool_not             |   Done
 * bool_comp            |   Done
 * bool_parens          |   Done?
 * num_comp             |   Done
 * expression           |   Done
 * term                 |   Divide needs to check if divisor is a zero
 * negation             |   Done
 * parenthetical_exp    |   Done? Not really tested though
 * operand              |   Done
 * literal              |   Done           
 * param_declarations   |   Needs more work
 * param_declaration    |   Needs more work
 * statements           |   Done
 * statement            |   Done
 * var_dec              |   Done
 * opt_assignment       |   ?
 * funct_call           |   Needs more work
 * call_params          |   Needs more work
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
        // File
        // --------------------------------------------------------
        public override void OutAFile(AFile node){}


        // --------------------------------------------------------
        //Const Delcarations
        // --------------------------------------------------------

        public override void OutASomeConstDeclarations(ASomeConstDeclarations node)
        {
            // Get the type name
            string typeName = node.GetRwType().Text;
            Definition typeDef;

            if (!globalSymbolTable.TryGetValue(typeName, out typeDef))
            {
                PrintWarning(node.GetRwType(), "Type '" + typeName + "' is not declared.");
            }
            else if (!(typeDef is TypeDefinition))
            {
                PrintWarning(node.GetRwType(), "'" + typeName + "' is not a valid type.");
            }
            else
            {
                // Get the constant name
                string constName = node.GetId().Text;
                if (globalSymbolTable.ContainsKey(constName))
                {
                    PrintWarning(node.GetId(), "Constant '" + constName + "' is already declared.");
                }
                else
                {
                    // Get the expression's type
                    Definition exprDef;
                    if (!decoratedParseTree.TryGetValue(node.GetExpression(), out exprDef))
                    {
                        // Expression error already reported
                    }
                    else if (exprDef.name != typeDef.name)
                    {
                        PrintWarning(node.GetId(), "Type mismatch: Cannot assign '" + exprDef.name + "' to '" + typeDef.name + "'.");
                    }
                    else
                    {
                        // Create and add the constant definition
                        ConstDefinition constDef = new ConstDefinition();
                        constDef.name = constName;
                        constDef.constType = (TypeDefinition)typeDef;

                        globalSymbolTable.Add(constName, constDef);
                        decoratedParseTree.Add(node, constDef);
                    }
                }
            }

            // No need to process const_declarations recursively as the visitor pattern handles it
        }

        public override void OutANoneConstDeclarations(ANoneConstDeclarations node)
        {
            // No action needed for empty const declarations
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
        // Bool_parens
        // --------------------------------------------------------

        public override void OutASomeBoolParens(ASomeBoolParens node)
        {
            Definition boolExpDef;

            if(!decoratedParseTree.TryGetValue(node.GetBoolExp(), out boolExpDef))
            {
                // Error already printed
            }
            else
            {
                decoratedParseTree.Add(node, boolExpDef);
            }
        }

        public override void OutANoneBoolParens(ANoneBoolParens node)
        {
            Definition numCompDef;

            if(!decoratedParseTree.TryGetValue(node.GetNumComp(), out  numCompDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, numCompDef);
            }
        }

        // --------------------------------------------------------
        // Bool_Comp
        // --------------------------------------------------------
        public override void OutASoloBoolComp(ASoloBoolComp node)
        {
            Definition boolParensDef;

            if (!decoratedParseTree.TryGetValue(node.GetBoolParens(), out boolParensDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, boolParensDef);
            }
        }

        public override void OutAEqualBoolComp(AEqualBoolComp node)
        {
            Definition boolCompDef;
            Definition boolParensDef;

            if(!decoratedParseTree.TryGetValue(node.GetBoolComp(), out boolCompDef))
            {
                // Error already printed above
            }
            else if(!decoratedParseTree.TryGetValue(node.GetBoolParens(), out boolParensDef))
            {
                // Error already printed above
            }
            else if(boolCompDef.name != boolParensDef.name)
            {
                PrintWarning(node.GetEqSign(), "Cannot compare different types");
            }
            else
            {
                decoratedParseTree.Add(node, boolCompDef);
            }
        }

        public override void OutANotEqualBoolComp(ANotEqualBoolComp node)
        {
            Definition boolCompDef;
            Definition boolParensDef;

            if(!decoratedParseTree.TryGetValue(node.GetBoolComp(), out boolCompDef))
            {
                // Error already printed above
            }
            else if(!decoratedParseTree.TryGetValue(node.GetBoolParens(), out boolParensDef))
            {
                // Error already printed above
            }
            else if(boolCompDef.name != boolParensDef.name)
            {
                PrintWarning(node.GetNeqSign(), "Cannot compare different types");
            }
            else
            {
                decoratedParseTree.Add(node, boolCompDef);
            }
        }

        // --------------------------------------------------------
        // Bool_Not
        // --------------------------------------------------------

        public override void OutANegBoolNot(ANegBoolNot node)
        {
            Definition boolCompDef;

            if(!decoratedParseTree.TryGetValue(node.GetBoolComp(), out boolCompDef))
            {
                // Error already printed above
            }
            else if(!((boolCompDef is NumberDefinition) || (boolCompDef is FloatDefinition)))
            {
                PrintWarning(node.GetNotSign(), "Can only not numbers and floats");
            }
            else
            {
                decoratedParseTree.Add(node, boolCompDef);
            }
        }

        public override void OutAPosBoolNot(APosBoolNot node)
        {
            Definition boolCompDef;

            if(!decoratedParseTree.TryGetValue(node.GetBoolComp(), out boolCompDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, boolCompDef);
            }
        }

        // --------------------------------------------------------
        // Bool_Term
        // --------------------------------------------------------

        public override void OutASingleBoolTerm(ASingleBoolTerm node)
        {
            Definition boolNotDef;

            if(!decoratedParseTree.TryGetValue(node.GetBoolNot(), out boolNotDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, boolNotDef);
            }
        }

        public override void OutAMultBoolTerm(AMultBoolTerm node)
        {
            Definition boolTermDef;
            Definition boolNotDef;

            if(!decoratedParseTree.TryGetValue(node.GetBoolTerm(), out boolTermDef))
            {
                // Error already printed above
            }
            else if(!decoratedParseTree.TryGetValue(node.GetBoolNot(), out boolNotDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, boolTermDef);
            }
        }

        // --------------------------------------------------------
        // Bool_Exp
        // --------------------------------------------------------

        public override void OutASingleBoolExp(ASingleBoolExp node)
        {
            Definition boolTermDef;

            if(!decoratedParseTree.TryGetValue(node.GetBoolTerm(), out boolTermDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, boolTermDef);
            }
        }

        public override void OutAMultBoolExp(AMultBoolExp node)
        {
            Definition boolExpDef;
            Definition boolTermDef;

            if(!decoratedParseTree.TryGetValue(node.GetBoolExp(), out boolExpDef))
            {
                // Error already printed above
            }
            else if(!decoratedParseTree.TryGetValue(node.GetBoolTerm(), out boolTermDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, boolExpDef);
            }
        }

        // --------------------------------------------------------
        // Param Declarations
        // --------------------------------------------------------

        public override void OutASomeParamDeclarations(ASomeParamDeclarations node)
        {
            Definition paramDeclarationsDef;
            Definition paramDeclarationDef;

            if(!decoratedParseTree.TryGetValue(node.GetParamDeclarations(), out paramDeclarationsDef))
            {
                // Error already printed above
            }
            else if(!decoratedParseTree.TryGetValue(node.GetParamDeclaration(), out paramDeclarationDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, paramDeclarationsDef);
            }
        }

        public override void OutAOneParamDeclarations(AOneParamDeclarations node)
        {
            Definition paramDeclarationDef;

            if(!decoratedParseTree.TryGetValue(node.GetParamDeclaration(), out paramDeclarationDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, paramDeclarationDef);
            }
        }

        // --------------------------------------------------------
        // Param Declaration
        // --------------------------------------------------------

        public override void OutAParamDeclaration(AParamDeclaration node)
        {
            Definition typeDef;
            Definition idDef;

            if (!globalSymbolTable.TryGetValue(node.GetRwType().Text, out typeDef))
            {
                PrintWarning(node.GetRwType(), "Type " + node.GetType().Name + " does not exist");
            }
            else if (!(typeDef is TypeDefinition))
            {
                PrintWarning(node.GetRwType(), "Identifier " + node.GetRwType().Text + " is not a recognized data type");
            }
            else if (localSymbolTable.TryGetValue(node.GetId().Text, out idDef))
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
        // Statements
        // --------------------------------------------------------

        public override void OutASomeStatements(ASomeStatements node)
        {
            Definition statementsDef;
            Definition statementDef;

            if(!decoratedParseTree.TryGetValue(node.GetStatements(), out statementsDef))
            {
                // Error already printed above
            }
            else if(!decoratedParseTree.TryGetValue(node.GetStatement(), out statementDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, statementsDef);
            }
        }

        // --------------------------------------------------------
        // Statement
        // --------------------------------------------------------

        public override void OutADeclarationStatement(ADeclarationStatement node)
        {
            Definition varDecDef;

            if(!decoratedParseTree.TryGetValue(node.GetVarDec(), out varDecDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, varDecDef);
            }
        }

        public override void OutACallStatement(ACallStatement node)
        {
            Definition funcCallDef;

            if(!decoratedParseTree.TryGetValue(node.GetFunctCall(), out  funcCallDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, funcCallDef);
            }
        }

        public override void OutAAssignmentStatement(AAssignmentStatement node)
        {
            Definition assignmentDef;

            if(!decoratedParseTree.TryGetValue(node.GetAssignment(), out assignmentDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, assignmentDef);
            }
        }

        public override void OutAIfStatement(AIfStatement node)
        {
            Definition ifStmtDef;

            if(!decoratedParseTree.TryGetValue(node.GetIfStmt(), out ifStmtDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, ifStmtDef);
            }
        }

        public override void OutALoopStatement(ALoopStatement node)
        {
            Definition loopStmtDef;

            if(!decoratedParseTree.TryGetValue(node.GetLoopStmt(), out loopStmtDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, loopStmtDef);
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
        // Function Call
        // --------------------------------------------------------

        public override void OutAFunctCall(AFunctCall node)
        {
            Definition idDef;
            Definition callParamsDef;

            if(!decoratedParseTree.TryGetValue(node.GetId(), out idDef))
            {
                // Error already printed above
            }
            else if(!decoratedParseTree.TryGetValue(node.GetCallParams(), out  callParamsDef))
            {
                //Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, idDef);
            }
        }

        // --------------------------------------------------------
        // Call Params
        // --------------------------------------------------------

        public override void OutASomeCallParams(ASomeCallParams node)
        {
            Definition callParamsDef;
            Definition expressionDef;

            if(!decoratedParseTree.TryGetValue(node.GetCallParams(), out callParamsDef))
            {
                // Error already printed above
            }
            else if(!decoratedParseTree.TryGetValue(node.GetExpression(), out  expressionDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, callParamsDef);
            }
        }

        public override void OutAOneCallParams(AOneCallParams node)
        {
            Definition expressionDef;

            if(!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                // Error already printed above
            }
            else
            {
                decoratedParseTree.Add(node, expressionDef);
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