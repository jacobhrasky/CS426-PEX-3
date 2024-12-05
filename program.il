.assembly extern mscorlib {}
.assembly PEX4CodeGen
{
	.ver 1:0:1:0
}

.method static void Test9 () cil managed
{
	.maxstack 128
	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "Nested While Loop Test"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	.locals init (int32 x )
	ldc.i4 0
	stloc x

	.locals init (int32 y )
	ldc.i4 0
	stloc y

	Label_0:
	ldloc y
	ldc.i4 3
	blt Label_2
		ldc.i4 0
		br Label_3
	Label_2:
		ldc.i4 1
	Label_3:

	brzero Label_1
	Label_4:
	ldloc x
	ldc.i4 3
	blt Label_6
		ldc.i4 0
		br Label_7
	Label_6:
		ldc.i4 1
	Label_7:

	brzero Label_5
	ldstr "  "
	call void [mscorlib]System.Console::Write(string)

	ldloc x
	call void [mscorlib]System.Console::Write(int32)

	ldstr ", "
	call void [mscorlib]System.Console::Write(string)

	ldloc y
	call void [mscorlib]System.Console::Write(int32)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldloc x
	ldc.i4 1
	add

	stloc x

	br Label_4
	Label_5:
	ldc.i4 0
	stloc x

	ldloc y
	ldc.i4 1
	add

	stloc y

	br Label_0
	Label_1:
	ldstr "  Loop Complete"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ret
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint
	call void Test9()

	ret
}
