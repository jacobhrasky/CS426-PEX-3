using CS426.node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
            Definition litDefintion = new LiteralDefintion();

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
                // The error was already printed
            }
            else
            {
                decoratedParseTree.Add(node, operandDefinition);
            }
        }

        public override void OutASomeParentheticalExp(ASomeParentheticalExp node)
        {
            Definition expression;

            if(!decoratedParseTree.TryGetValue(node.GetExpression(), out expression))
            {

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

            if(!decoratedParseTree.TryGetValue(node.GetParentheticalExp(), out parentheticalExp))
            {

            }
            else
            {
                decoratedParseTree.Add(node, parentheticalExp);
            }
        }

        public override void OutANegNegation(ANegNegation node)
        {
            Definition parentheticalExp;

            if(!decoratedParseTree.TryGetValue(node.GetParentheticalExp(), out parentheticalExp))
            {

            }
            else if(!(parentheticalExp is FloatDefinition))
            {
                PrintWarning(node.GetMinusSign(), "Only a number can be negated!");
            }
            else
            {
                decoratedParseTree.Add(node, parentheticalExp);
            }
        }

        // --------------------------------------------------------
        // 
        // --------------------------------------------------------
    }
}
