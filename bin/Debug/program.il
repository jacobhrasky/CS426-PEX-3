.assembly extern mscorlib {}
.assembly PEX4CodeGen
{
	.ver 1:0:1:0
}

.method static void Test7 () cil managed
{
	.maxstack 128
	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "Nested If Statement Test"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	// Bool Expression
	ldc.i4 3
	ldc.i4 2
	bgt Label_3
		ldc.i4 0
		br Label_4
	Label_3:
		ldc.i4 1
	Label_4:

	// If statement
	brtrue Label_0
	br Label_1
	Label_0:
	// Bool Expression
	ldc.i4 5
	ldc.i4 4
	blt Label_8
		ldc.i4 0
		br Label_9
	Label_8:
		ldc.i4 1
	Label_9:

	// If statement
	brtrue Label_5
	br Label_6
	Label_5:
	ldstr "  Nested If Statement Fails"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_7
	Label_6:
	ldstr "  Nested If Statement Passes"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	Label_7:
		br Label_2
	Label_1:
	Label_2:
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ret
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint
	call void Test6()

	ret
}
