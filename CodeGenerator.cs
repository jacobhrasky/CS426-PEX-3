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
 * Done - Logical Not
 * Done - Logical And
 * Done - Logical Or
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

        /*public override void CaseAFunctDeclarations(AFunctDeclarations node)
        {
            InAFunctDeclarations(node);
            WriteLine(".method static void " + node.GetId() + "() cil managed");
            WriteLine("{\n\t.maxstack 128");

            OutAFunctDeclarations(node);
            WriteLine("\tret\n}\n");
        }*/

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

        private int _labelCounter = 0;

        private string GetNextLabel()
        {
            return $"Label_{_labelCounter++}";
        }

        public override void CaseAIfStmt(AIfStmt node)
        {
            string labelTrue = GetNextLabel();
            string labelFalse = GetNextLabel();
            string labelContinue = GetNextLabel();

            InAIfStmt(node);

            WriteLine("\t// Bool Expression");
            node.GetBoolExp().Apply(this);

            string boolExp = node.GetBoolExp().ToString();
            if (boolExp.Contains("=") && !(boolExp.Contains(">") || boolExp.Contains("<") || boolExp.Contains("!")))
            { 
                string labelEqual = GetNextLabel();
                string labelNotEqual = GetNextLabel();

                WriteLine("\tbeq " + labelEqual);
                WriteLine("\t\tldc.i4 0");
                WriteLine("\t\tbr " + labelNotEqual);
                WriteLine("\t" + labelEqual + ":");
                WriteLine("\t\tldc.i4 1");
                WriteLine("\t" + labelNotEqual + ":\n");
                
            }
            else if (boolExp.Contains("!="))
            {
                string labelNotEqual = GetNextLabel();
                string labelEqual = GetNextLabel();

                WriteLine("\tbne.un " + labelNotEqual);
                WriteLine("\t\tldc.i4 0");
                WriteLine("\t\tbr " + labelEqual);
                WriteLine("\t" + labelNotEqual + ":");
                WriteLine("\t\tldc.i4 1");
                WriteLine("\t" + labelEqual + ":\n");
            }
            else if (boolExp.Contains("<") && !(boolExp.Contains(">") || boolExp.Contains("=") || boolExp.Contains("!")))
            {
                if (boolExp.Contains("&"))
                {
                    string labelAndLess = GetNextLabel();
                    string labelAndNotLess = GetNextLabel();

                    WriteLine("\tblt " + labelAndLess);
                    WriteLine("\t\tldc.i4 0");
                    WriteLine("\t\tbr " + labelAndNotLess);
                    WriteLine("\t" + labelAndLess + ":");
                    WriteLine("\t\tldc.i4 1");
                    WriteLine("\t" + labelAndNotLess + ":\n");

                    string labelLess2 = GetNextLabel();
                    string labelNotLess2 = GetNextLabel();

                    WriteLine("\tblt " + labelLess2);
                    WriteLine("\t\tldc.i4 0");
                    WriteLine("\t\tbr " + labelNotLess2);
                    WriteLine("\t" + labelLess2 + ":");
                    WriteLine("\t\tldc.i4 1");
                    WriteLine("\t" + labelNotLess2 + ":\n");

                    WriteLine("\tand\n");
                }
                else
                {
                    string labelLess = GetNextLabel();
                    string labelNotLess = GetNextLabel();

                    WriteLine("\tblt " + labelLess);
                    WriteLine("\t\tldc.i4 0");
                    WriteLine("\t\tbr " + labelNotLess);
                    WriteLine("\t" + labelLess + ":");
                    WriteLine("\t\tldc.i4 1");
                    WriteLine("\t" + labelNotLess + ":\n");
                }
            }
            else if (boolExp.Contains("<="))
            {
                if (boolExp.Contains("!"))
                {
                    string labelLessEqual2 = GetNextLabel();
                    string labelLessNotEqual2 = GetNextLabel();

                    WriteLine("\tble " + labelLessEqual2);
                    WriteLine("\t\tldc.i4 0");
                    WriteLine("\t\tbr " + labelLessNotEqual2);
                    WriteLine("\t" + labelLessEqual2 + ":");
                    WriteLine("\t\tldc.i4 1");
                    WriteLine("\t" + labelLessNotEqual2 + ":\n");

                    WriteLine("\tldc.i4 0");
                    WriteLine("\tceq\n");
                }
                else
                { 
                    string labelLessEqual = GetNextLabel();
                    string labelLessNotEqual = GetNextLabel();

                    WriteLine("\tble " + labelLessEqual);
                    WriteLine("\t\tldc.i4 0");
                    WriteLine("\t\tbr " + labelLessNotEqual);
                    WriteLine("\t" + labelLessEqual + ":");
                    WriteLine("\t\tldc.i4 1");
                    WriteLine("\t" + labelLessNotEqual + ":\n");
                }
            }
            else if (boolExp.Contains(">") && !(boolExp.Contains("=") || boolExp.Contains("<") || boolExp.Contains("!")))
            {
                if (boolExp.Contains("|"))
                {
                    string labelGreater2 = GetNextLabel();
                    string labelNotGreater2 = GetNextLabel();

                    WriteLine("\tbgt " + labelGreater2);
                    WriteLine("\t\tldc.i4 0");
                    WriteLine("\t\tbr " + labelNotGreater2);
                    WriteLine("\t" + labelGreater2 + ":");
                    WriteLine("\t\tldc.i4 1");
                    WriteLine("\t" + labelNotGreater2 + ":\n");

                    string labelGreater3 = GetNextLabel();
                    string labelNotGreater3 = GetNextLabel();

                    WriteLine("\tbgt " + labelGreater3);
                    WriteLine("\t\tldc.i4 0");
                    WriteLine("\t\tbr " + labelNotGreater3);
                    WriteLine("\t" + labelGreater3 + ":");
                    WriteLine("\t\tldc.i4 1");
                    WriteLine("\t" + labelNotGreater3 + ":\n");

                    WriteLine("\tor\n");
                }
                else
                {
                    string labelGreater = GetNextLabel();
                    string labelNotGreater = GetNextLabel();

                    WriteLine("\tbgt " + labelGreater);
                    WriteLine("\t\tldc.i4 0");
                    WriteLine("\t\tbr " + labelNotGreater);
                    WriteLine("\t" + labelGreater + ":");
                    WriteLine("\t\tldc.i4 1");
                    WriteLine("\t" + labelNotGreater + ":\n");
                }
            }
            else if (boolExp.Contains(">="))
            {
                string labelGreaterEqual = GetNextLabel();
                string labelGreaterNotEqual = GetNextLabel();

                WriteLine("\tbge " + labelGreaterEqual);
                WriteLine("\t\tldc.i4 0");
                WriteLine("\t\tbr " + labelGreaterNotEqual);
                WriteLine("\t" + labelGreaterEqual + ":");
                WriteLine("\t\tldc.i4 1");
                WriteLine("\t" + labelGreaterNotEqual + ":\n");
            }

            WriteLine("\t// If statement");

            WriteLine("\tbrtrue " + labelTrue);
            WriteLine("\tbr " + labelFalse);

            WriteLine("\t" + labelTrue + ":");
            if (node.GetStatements() != null)
            {
                node.GetStatements().Apply(this);
            }

            WriteLine("\t\tbr " + labelContinue);
            
            WriteLine("\t" + labelFalse + ":");
            if (node.GetElseStmt() is AYesElseElseStmt yesElse)
            {
                yesElse.GetStatements().Apply(this);
            }

            WriteLine("\t" + labelContinue + ":");

            OutAIfStmt(node);
        }

        public override void CaseALoopStmt(ALoopStmt node)
        {
            string labelStart = GetNextLabel();
            string labelEnd = GetNextLabel();

            InALoopStmt(node);

            WriteLine("\t" + labelStart + ":");

            // Evaluate the loop condition
            node.GetBoolExp().Apply(this);

            string boolExp = node.GetBoolExp().ToString();
            if (boolExp.Contains("=") && !(boolExp.Contains(">") || boolExp.Contains("<") || boolExp.Contains("!")))
            {
                string labelEqual = GetNextLabel();
                string labelNotEqual = GetNextLabel();

                WriteLine("\tbeq " + labelEqual);
                WriteLine("\t\tldc.i4 0");
                WriteLine("\t\tbr " + labelNotEqual);
                WriteLine("\t" + labelEqual + ":");
                WriteLine("\t\tldc.i4 1");
                WriteLine("\t" + labelNotEqual + ":\n");
            }
            else if (boolExp.Contains("!="))
            {
                string labelNotEqual = GetNextLabel();
                string labelEqual = GetNextLabel();

                WriteLine("\tbne.un " + labelNotEqual);
                WriteLine("\t\tldc.i4 0");
                WriteLine("\t\tbr " + labelEqual);
                WriteLine("\t" + labelNotEqual + ":");
                WriteLine("\t\tldc.i4 1");
                WriteLine("\t" + labelEqual + ":\n");
            }
            else if (boolExp.Contains("<") && !(boolExp.Contains(">") || boolExp.Contains("=") || boolExp.Contains("!")))
            {
                string labelLess = GetNextLabel();
                string labelNotLess = GetNextLabel();

                WriteLine("\tblt " + labelLess);
                WriteLine("\t\tldc.i4 0");
                WriteLine("\t\tbr " + labelNotLess);
                WriteLine("\t" + labelLess + ":");
                WriteLine("\t\tldc.i4 1");
                WriteLine("\t" + labelNotLess + ":\n");
            }
            else if (boolExp.Contains("<="))
            {
                string labelLessEqual = GetNextLabel();
                string labelLessNotEqual = GetNextLabel();

                WriteLine("\tble " + labelLessEqual);
                WriteLine("\t\tldc.i4 0");
                WriteLine("\t\tbr " + labelLessNotEqual);
                WriteLine("\t" + labelLessEqual + ":");
                WriteLine("\t\tldc.i4 1");
                WriteLine("\t" + labelLessNotEqual + ":\n");
            }
            else if (boolExp.Contains(">") && !(boolExp.Contains("=") || boolExp.Contains("<") || boolExp.Contains("!")))
            {
                string labelGreater = GetNextLabel();
                string labelNotGreater = GetNextLabel();

                WriteLine("\tbgt " + labelGreater);
                WriteLine("\t\tldc.i4 0");
                WriteLine("\t\tbr " + labelNotGreater);
                WriteLine("\t" + labelGreater + ":");
                WriteLine("\t\tldc.i4 1");
                WriteLine("\t" + labelNotGreater + ":\n");
            }
            else if (boolExp.Contains(">="))
            {
                string labelGreaterEqual = GetNextLabel();
                string labelGreaterNotEqual = GetNextLabel();

                WriteLine("\tbge " + labelGreaterEqual);
                WriteLine("\t\tldc.i4 0");
                WriteLine("\t\tbr " + labelGreaterNotEqual);
                WriteLine("\t" + labelGreaterEqual + ":");
                WriteLine("\t\tldc.i4 1");
                WriteLine("\t" + labelGreaterNotEqual + ":\n");
            }
            else
            {
                Console.WriteLine("Bool Operator not found.");
            }

            WriteLine("\tbrzero " + labelEnd);

            if (node.GetStatements() != null)
            {
                node.GetStatements().Apply(this);
            }

            WriteLine("\tbr " + labelStart);
            WriteLine("\t" + labelEnd + ":");

            OutALoopStmt(node);
        }
    }
}