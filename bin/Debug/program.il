.assembly extern mscorlib {}
.assembly PEX4CodeGen
{
	.ver 1:0:1:0
}

.method static void Test9 () cil managed
{
	.maxstack 128
.method static void Test8 () cil managed
{
	.maxstack 128
.method static void Test7 () cil managed
{
	.maxstack 128
.method static void Test6 () cil managed
{
	.maxstack 128
.method static void Test5 () cil managed
{
	.maxstack 128
.method static void Test4 () cil managed
{
	.maxstack 128
.method static void Test3 () cil managed
{
	.maxstack 128
.method static void Test2 () cil managed
{
	.maxstack 128
.method static void Test1 () cil managed
{
	.maxstack 128
	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "Variable Declaration Test"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	.locals init (int32 i )
	ldc.i4 1
	stloc i

	.locals init (float32 f1 )
	ldc.r8 2.3
	neg

	stloc f1

	.locals init (float32 f2 )
	ldc.r8 3.4e5
	stloc f2

	.locals init (string s )
	ldstr "hello world"
	stloc s

	ldstr "i = "
	call void [mscorlib]System.Console::Write(string)

	ldloc i
	call void [mscorlib]System.Console::Write(int32)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "f1 = "
	call void [mscorlib]System.Console::Write(string)

	ldloc f1
	call void [mscorlib]System.Console::Write(float32)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "f2 = "
	call void [mscorlib]System.Console::Write(string)

	ldloc f2
	call void [mscorlib]System.Console::Write(float32)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "s = "
	call void [mscorlib]System.Console::Write(string)

	ldloc s
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ret
}

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "Variable Assignment Test"
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

	.locals init (float32 y )
	ldc.r8 1.2
	stloc y

	.locals init (string s )
	ldstr "original string"
	stloc s

	ldstr "  x (before): "
	call void [mscorlib]System.Console::Write(string)

	ldloc x
	call void [mscorlib]System.Console::Write(int32)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "  y (before): "
	call void [mscorlib]System.Console::Write(string)

	ldloc y
	call void [mscorlib]System.Console::Write(float32)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "  s (before): "
	call void [mscorlib]System.Console::Write(string)

	ldloc s
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldc.i4 12345
	stloc x

	ldc.r8 6.789
	neg

	stloc y

	ldstr "dog goes \"woof\", cat goes \"meow\", but what does the fox say \\sarcasm"
	stloc s

	ldstr "  x (after): "
	call void [mscorlib]System.Console::Write(string)

	ldloc x
	call void [mscorlib]System.Console::Write(int32)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "  y (after): "
	call void [mscorlib]System.Console::Write(string)

	ldloc y
	call void [mscorlib]System.Console::Write(float32)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "  s (after): "
	call void [mscorlib]System.Console::Write(string)

	ldloc s
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ret
}

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "Math Operation Test"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	.locals init (int32 x )
	ldc.i4 5
	ldc.i4 4
	sub

	ldc.i4 4
	add

	stloc x

	ldloc x
	ldc.i4 2
	mul

	ldc.i4 2
	div

	stloc x

	ldloc x
	ldloc x
	mul

	ldc.i4 5
	ldc.i4 5
	sub

	mul

	stloc x

	ldstr "  x = "
	call void [mscorlib]System.Console::Write(string)

	ldloc x
	call void [mscorlib]System.Console::Write(int32)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	.locals init (float32 y )
	ldc.r8 10.44
	ldc.r8 9.79
	add

	ldc.r8 10.115
	sub

	stloc y

	ldloc y
	ldc.r8 2.0
	ldc.r8 1.0
	div

	mul

	neg

	stloc y

	ldstr "  y = "
	call void [mscorlib]System.Console::Write(string)

	ldloc y
	call void [mscorlib]System.Console::Write(float32)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ret
}

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "Relational Operator Test"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	// Bool Expression
	ldc.i4 5
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
	ldstr "  Greater than works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_2
	Label_1:
	Label_2:
	// Bool Expression
	ldc.i4 2
	ldc.i4 5
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
	ldstr "  Less than works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_7
	Label_6:
	Label_7:
	// Bool Expression
	ldc.i4 4
	ldc.i4 4
	bge Label_13
		ldc.i4 0
		br Label_14
	Label_13:
		ldc.i4 1
	Label_14:

	// If statement
	brtrue Label_10
	br Label_11
	Label_10:
	ldstr "  Greater than or equal works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_12
	Label_11:
	Label_12:
	// Bool Expression
	ldc.i4 4
	ldc.i4 4
	ble Label_18
		ldc.i4 0
		br Label_19
	Label_18:
		ldc.i4 1
	Label_19:

	// If statement
	brtrue Label_15
	br Label_16
	Label_15:
	ldstr "  Less than or equal works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_17
	Label_16:
	Label_17:
	// Bool Expression
	ldc.r8 5.0
	ldc.r8 5.0
	beq Label_23
		ldc.i4 0
		br Label_24
	Label_23:
		ldc.i4 1
	Label_24:

	// If statement
	brtrue Label_20
	br Label_21
	Label_20:
	ldstr "  Equals works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_22
	Label_21:
	Label_22:
	// Bool Expression
	ldc.r8 2.5
	ldc.r8 3.0
	bne.un Label_28
		ldc.i4 0
		br Label_29
	Label_28:
		ldc.i4 1
	Label_29:

	// If statement
	brtrue Label_25
	br Label_26
	Label_25:
	ldstr "  Not Equals works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_27
	Label_26:
	Label_27:
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ret
}

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
	ldc.i4 4
	blt Label_33
		ldc.i4 0
		br Label_34
	Label_33:
		ldc.i4 1
	Label_34:

	blt Label_35
		ldc.i4 0
		br Label_36
	Label_35:
		ldc.i4 1
	Label_36:

	and

	// If statement
	brtrue Label_30
	br Label_31
	Label_30:
	ldstr "  And works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_32
	Label_31:
	Label_32:
	// Bool Expression
	ldc.i4 2
	ldc.i4 1
	ldc.i4 2
	ldc.i4 2
	bgt Label_40
		ldc.i4 0
		br Label_41
	Label_40:
		ldc.i4 1
	Label_41:

	bgt Label_42
		ldc.i4 0
		br Label_43
	Label_42:
		ldc.i4 1
	Label_43:

	or

	// If statement
	brtrue Label_37
	br Label_38
	Label_37:
	ldstr "  Or works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_39
	Label_38:
	Label_39:
	// Bool Expression
	ldc.i4 2
	ldc.i4 1
	ble Label_47
		ldc.i4 0
		br Label_48
	Label_47:
		ldc.i4 1
	Label_48:

	ldc.i4 0
	ceq

	// If statement
	brtrue Label_44
	br Label_45
	Label_44:
	ldstr "  Not works"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_46
	Label_45:
	Label_46:
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ret
}

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "If Statement Test"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	// Bool Expression
	ldc.r8 1.0
	ldc.r8 1.0
	add

	ldc.r8 3.0
	blt Label_52
		ldc.i4 0
		br Label_53
	Label_52:
		ldc.i4 1
	Label_53:

	// If statement
	brtrue Label_49
	br Label_50
	Label_49:
	ldstr "  If (true) Statement Passes"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_51
	Label_50:
	ldstr "  If (true) Statement Fails"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	Label_51:
	// Bool Expression
	ldc.r8 5.0
	ldc.r8 3.0
	mul

	ldc.i4 1
	blt Label_57
		ldc.i4 0
		br Label_58
	Label_57:
		ldc.i4 1
	Label_58:

	// If statement
	brtrue Label_54
	br Label_55
	Label_54:
	ldstr "  If (false) Statement Fails"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_56
	Label_55:
	ldstr "  If (false) Statement Passes"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	Label_56:
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	call void Test7()

	ret
}

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
	bgt Label_62
		ldc.i4 0
		br Label_63
	Label_62:
		ldc.i4 1
	Label_63:

	// If statement
	brtrue Label_59
	br Label_60
	Label_59:
	// Bool Expression
	ldc.i4 5
	ldc.i4 4
	blt Label_67
		ldc.i4 0
		br Label_68
	Label_67:
		ldc.i4 1
	Label_68:

	// If statement
	brtrue Label_64
	br Label_65
	Label_64:
	ldstr "  Nested If Statement Fails"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

		br Label_66
	Label_65:
	ldstr "  Nested If Statement Passes"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	Label_66:
		br Label_61
	Label_60:
	Label_61:
	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ret
}

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "While Loop Test"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "--------------------------------------------------"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	.locals init (int32 i )
	ldc.i4 0
	stloc i

	Label_69:
	ldloc i
	ldc.i4 10
	blt Label_71
		ldc.i4 0
		br Label_72
	Label_71:
		ldc.i4 1
	Label_72:

	brzero Label_70
	ldstr "  "
	ldloc i
	add

	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldloc i
	ldc.i4 1
	add

	stloc i

	br Label_69
	Label_70:
	ldstr "  Loop Complete"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	ldstr "\n"
	call void [mscorlib]System.Console::Write(string)

	call void Test9()

	ret
}

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

	Label_73:
	ldloc y
	ldc.i4 3
	blt Label_75
		ldc.i4 0
		br Label_76
	Label_75:
		ldc.i4 1
	Label_76:

	brzero Label_74
	Label_77:
	ldloc x
	ldc.i4 3
	blt Label_79
		ldc.i4 0
		br Label_80
	Label_79:
		ldc.i4 1
	Label_80:

	brzero Label_78
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

	br Label_77
	Label_78:
	ldc.i4 0
	stloc x

	ldloc y
	ldc.i4 1
	add

	stloc y

	br Label_73
	Label_74:
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
	call void Test1()

	call void Test2()

	call void Test3()

	call void Test4()

	call void Test5()

	call void Test6()

	call void Test8()

	ret
}
