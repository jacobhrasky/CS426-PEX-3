.assembly extern mscorlib {}
.assembly PEX4CodeGen
{
	.ver 1:0:1:0
}

.method static void Test5 () cil managed
{
	.maxstack 128
	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "Boolean Operator Test"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	// Bool Expression
	ldc.i4 1
	ldc.i4 4
	ldc.i4 2
	neg

	ldc.i4 4
	blt Label_3
		ldc.i4 0
		br Label_4
	Label_3:
		ldc.i4 1
	Label_4:

	blt Label_5
		ldc.i4 0
		br Label_6
	Label_5:
		ldc.i4 1
	Label_6:

	and

	// If statement
	brtrue Label_0
	br Label_1
	Label_0:
	ldstr "  And works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_2
	Label_1:
	Label_2:
	// Bool Expression
	ldc.i4 2
	ldc.i4 1
	ldc.i4 2
	ldc.i4 2
	bgt Label_10
		ldc.i4 0
		br Label_11
	Label_10:
		ldc.i4 1
	Label_11:

	bgt Label_12
		ldc.i4 0
		br Label_13
	Label_12:
		ldc.i4 1
	Label_13:

	or

	// If statement
	brtrue Label_7
	br Label_8
	Label_7:
	ldstr "  Or works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_9
	Label_8:
	Label_9:
	// Bool Expression
	ldc.i4 2
	ldc.i4 1
	ble Label_17
		ldc.i4 0
		br Label_18
	Label_17:
		ldc.i4 1
	Label_18:

	ldc.i4 0
	ceq

	// If statement
	brtrue Label_14
	br Label_15
	Label_14:
	ldstr "  Not works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_16
	Label_15:
	Label_16:
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ret
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint
	call void Test5()

	ret
}
