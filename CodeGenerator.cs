using CS426.node;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * TODO:
 * Done - Program Initialization
 * Done - Main Func
 * Done - User Funcs
 * Done - Declaring Variable
 * Done - Assigning Variable
 * Done - Printing
 * Done - Calling User Funcs
 * Done - Addition
 * Done - Subtraction
 * Done - Multiplication
 * Done - Division
 * Done - Negation
 * Logical Not
 * Logical And
 * Logical Or
 * Logical Comparison
 * If / Else Stmt
 * Loop
 */


namespace CS426.analysis
{
    class CodeGenerator : DepthFirstAdapter
    {
        StreamWriter _output;

        public CodeGenerator(String outputFilename)
        {
            _output = new StreamWriter(outputFilename); ;
        }

        private void Write(String textToWrite)
        {
            Console.Write(textToWrite);
            _output.Write(textToWrite);
        }

        private void WriteLine(String textToWrite)
        {
            Console.WriteLine(textToWrite);
            _output.WriteLine(textToWrite);
        }

        public override void InAFile(AFile node)
        {
            WriteLine(".assembly extern mscorlib {}");
            WriteLine(".assembly PEX4CodeGen");
            WriteLine("{\n\t.ver 1:0:1:0\n}\n");
        }

        public override void OutAFile(AFile node)
        {
            _output.Close();
        }

        public override void InAMainDeclaration(AMainDeclaration node)
        {
            WriteLine(".method static void main() cil managed");
            WriteLine("{\n\t.maxstack 128\n\t.entrypoint");
        }

        public override void OutAMainDeclaration(AMainDeclaration node)
        {
            WriteLine("\tret\n}");
        }

        public override void InASomeFunctDeclarations(ASomeFunctDeclarations node)
        {
            WriteLine(".method static void " + node.GetId() + "() cil managed");
            WriteLine("{\n\t.maxstack 128");
        }

        public override void OutASomeFunctDeclarations(ASomeFunctDeclarations node)
        {
            WriteLine("\tret\n}\n");
        }

        public override void OutAVarDec(AVarDec node)
        {
            Write("\t.locals init (");

            if (node.GetRwType().Text == "int")
            {
                Write("int32");
            }
            else if (node.GetRwType().Text == "float")
            {
                Write("float32");
            }
            else if(node.GetRwType().Text == "str")
            {
                Write("string");
            }
            else
            {
                Console.WriteLine("Type not found.");
            }

            WriteLine(" " + node.GetId() + ")");
        }

        public override void OutAIntLiteral(AIntLiteral node)
        {
            WriteLine("\tldc.i4 " + node.GetLitInteger().Text);
        }

        public override void OutAFloatLiteral(AFloatLiteral node)
        {
            WriteLine("\tldc.r8 " + node.GetLitFloat().Text);
        }

        public override void OutAStrLiteral(AStrLiteral node)
        {
            WriteLine("\tldstr " + node.GetLitStr().Text);
        }

        public override void OutAVarOperand(AVarOperand node)
        {
            WriteLine("\tldloc " + node.GetId().Text);
        }

        public override void OutAAssignment(AAssignment node)
        {
            WriteLine("\tstloc " + node.GetId().Text + "\n");
        }

        public override void OutAPlusExpression(APlusExpression node)
        {
            WriteLine("\tadd\n");
        }

        public override void OutAMinusExpression(AMinusExpression node)
        {
            WriteLine("\tsub\n");
        }

        public override void OutAMultTerm(AMultTerm node)
        {
            WriteLine("\tmul\n");
        }

        public override void OutADivTerm(ADivTerm node)
        {
            WriteLine("\tdiv\n");
        }

        public override void OutANegNegation(ANegNegation node)
        {
            WriteLine("\tneg\n");
        }

        public override void OutAFunctCall(AFunctCall node)
        {
            if (node.GetId().Text == "printInt")
            {
                WriteLine("\tcall void [mscorlib]System.Console::Write(int32)\n");
            }
            else if (node.GetId().Text == "printFloat")
            {
                WriteLine("\tcall void [mscorlib]System.Console::Write(float32)\n");
            }
            else if (node.GetId().Text == "printString")
            {
                WriteLine("\tcall void [mscorlib]System.Console::Write(string)\n");
            }
            else if (node.GetId().Text == "printLine")
            {
                WriteLine("\tldstr \"\\n\"");
                WriteLine("\tcall void [mscorlib]System.Console::Write(string)\n");
            }
            else
            {
                WriteLine("\tcall void " + node.GetId().Text + "()\n");
            }
        }

        public override void OutANegBoolNot(ANegBoolNot node)
        {
            WriteLine("\tldc.i4 0");
            WriteLine("\tceq\n");
        }

        public override void OutAMultBoolTerm(AMultBoolTerm node)
        {
            WriteLine("\tadd\n");
        }

        public override void OutAMultBoolExp(AMultBoolExp node)
        {
            WriteLine("\tor\n");
        }

        public override void InAEqualNumComp(AEqualNumComp node)
        {
            WriteLine("\tbeq Equal");
            WriteLine("\t\tldc.i4 0");
            WriteLine("\t\tbr NotEqual");
            WriteLine("\tEqual:");
            WriteLine("\t\tldc.i4 1");
            WriteLine("\tNotEqual:\n");
        }

        public override void InAIfStmt(AIfStmt node)
        {
            WriteLine("\tbrtrue True");
            WriteLine("\tbr False");
            WriteLine("\tTrue:");
        }

        public override void OutAIfStmt(AIfStmt node)
        {
            WriteLine("\t\tbr Continue");
        }

        public override void InAYesElseElseStmt(AYesElseElseStmt node)
        {
            WriteLine("\tFalse:");
        }

        public override void OutAYesElseElseStmt(AYesElseElseStmt node)
        {
            WriteLine("\tContinue:");
        }

    }
}
