.assembly extern mscorlib {}
.assembly PEX4CodeGen
{
	.ver 1:0:1:0
}

.method static void main() cil managed
{
	.maxstack 128
	.entrypoint
	.locals init (int32 x )
	ldc.i4 1
	stloc x

	.locals init (string z )
	ldstr "works"
	stloc z

	brtrue True
	br False
	True:
	beq Equal
		ldc.i4 0
		br NotEqual
	Equal:
		ldc.i4 1
	NotEqual:

	ldloc x
	ldc.i4 1
	ldloc x
	call void [mscorlib]System.Console::Write(int32)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	False:
	ldloc z
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	Continue:
		br Continue
	ret
}
