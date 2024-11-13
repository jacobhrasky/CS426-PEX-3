:: Creates a Variable for the Output File
@SET file="pex3_test_results.txt"

:: Erases Everything Currently In the Output File
type NUL>%file%

:: ----------------------------------------
:: TITLE
:: ----------------------------------------
echo PEX3 TEST CASES >> %file%

:: ----------------------------------------
:: Variable Declarations
:: ----------------------------------------
echo. >> %file%
echo **Variable Declarations** >> %file%
echo. >> %file%

echo *varDeclarationCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\varDeclarationCorrect.txt" >> %file%
echo. >> %file%

echo *varDeclarationWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\varDeclarationWrong.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Parameter Declarations
:: ----------------------------------------
echo. >> %file%
echo **Parameter Declarations** >> %file%
echo. >> %file%

echo *paramDeclarationCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\paramDeclarationCorrect.txt" >> %file%
echo. >> %file%

echo *paramDeclarationWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\paramDeclarationWrong.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Function Calls with Parameters
:: ----------------------------------------
echo. >> %file%
echo **Function Calls with Parameters** >> %file%
echo. >> %file%

echo *funcCallCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\funcCallCorrect.txt" >> %file%
echo. >> %file%

echo *funcCallWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\funcCallWrong.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Assignment Statements
:: ----------------------------------------
echo. >> %file%
echo **Assignment Statements** >> %file%
echo. >> %file%

echo *assignCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\assignCorrect.txt" >> %file%
echo. >> %file%

echo *assignWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\assignWrong.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Arithmetic Operations
:: ----------------------------------------

:: Addition
echo. >> %file%
echo **Addition Operations** >> %file%
echo. >> %file%

echo *plusCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\plusCorrect.txt" >> %file%
echo. >> %file%

echo *plusWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\plusWrong.txt" >> %file%
echo. >> %file%

:: Subtraction
echo. >> %file%
echo **Subtraction Operations** >> %file%
echo. >> %file%

echo *subCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\subCorrect.txt" >> %file%
echo. >> %file%

echo *subWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\subWrong.txt" >> %file%
echo. >> %file%

:: Multiplication
echo. >> %file%
echo **Multiplication Operations** >> %file%
echo. >> %file%

echo *multCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\multCorrect.txt" >> %file%
echo. >> %file%

echo *multWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\multWrong.txt" >> %file%
echo. >> %file%

:: Division
echo. >> %file%
echo **Division Operations** >> %file%
echo. >> %file%

echo *divideCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\divideCorrect.txt" >> %file%
echo. >> %file%

echo *divideWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\divideWrong.txt" >> %file%
echo. >> %file%

:: Negation
echo. >> %file%
echo **Negation Operations** >> %file%
echo. >> %file%

echo *negationCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\negationCorrect.txt" >> %file%
echo. >> %file%

echo *negationWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\negationWrong.txt" >> %file%
echo. >> %file%

:: Parentheses in Expressions
echo. >> %file%
echo **Parentheses in Expressions** >> %file%
echo. >> %file%

echo *parensCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\parensCorrect.txt" >> %file%
echo. >> %file%

echo *parensWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\parensWrong.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Boolean Expressions
:: ----------------------------------------

:: Boolean AND
echo. >> %file%
echo **Boolean AND Operations** >> %file%
echo. >> %file%

echo *boolAndCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolAndCorrect.txt" >> %file%
echo. >> %file%

echo *boolAndWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolAndWrong.txt" >> %file%
echo. >> %file%

:: Boolean OR
echo. >> %file%
echo **Boolean OR Operations** >> %file%
echo. >> %file%

echo *boolOrCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolOrCorrect.txt" >> %file%
echo. >> %file%

echo *boolOrWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolOrWrong.txt" >> %file%
echo. >> %file%

:: Boolean NOT
echo. >> %file%
echo **Boolean NOT Operations** >> %file%
echo. >> %file%

echo *boolNotCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolNotCorrect.txt" >> %file%
echo. >> %file%

echo *boolNotWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolNotWrong.txt" >> %file%
echo. >> %file%

:: Boolean Parentheses
echo. >> %file%
echo **Boolean Parentheses** >> %file%
echo. >> %file%

echo *boolParensCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolParensCorrect.txt" >> %file%
echo. >> %file%

echo *boolParensWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolParensWrong.txt" >> %file%
echo. >> %file%

:: Boolean Equal
echo. >> %file%
echo **Boolean Equal Operations** >> %file%
echo. >> %file%

echo *boolEqualCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolEqualCorrect.txt" >> %file%
echo. >> %file%

echo *boolEqualWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolEqualWrong.txt" >> %file%
echo. >> %file%

:: Boolean Not Equal
echo. >> %file%
echo **Boolean Not Equal Operations** >> %file%
echo. >> %file%

echo *boolNotEqualCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolNotEqualCorrect.txt" >> %file%
echo. >> %file%

echo *boolNotEqualWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolNotEqualWrong.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Comparison Operations
:: ----------------------------------------

:: Less Than
echo. >> %file%
echo **Less Than Comparisons** >> %file%
echo. >> %file%

echo *lessCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\lessCorrect.txt" >> %file%
echo. >> %file%

echo *lessWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\lessWrong.txt" >> %file%
echo. >> %file%

:: Less Than or Equal
echo. >> %file%
echo **Less Than or Equal Comparisons** >> %file%
echo. >> %file%

echo *lessEqualCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\lessEqualCorrect.txt" >> %file%
echo. >> %file%

echo *lessEqualWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\lessEqualWrong.txt" >> %file%
echo. >> %file%

:: Greater Than
echo. >> %file%
echo **Greater Than Comparisons** >> %file%
echo. >> %file%

echo *greaterCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\greaterCorrect.txt" >> %file%
echo. >> %file%

echo *greaterWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\greaterWrong.txt" >> %file%
echo. >> %file%

:: Greater Than or Equal
echo. >> %file%
echo **Greater Than or Equal Comparisons** >> %file%
echo. >> %file%

echo *greaterEqualCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\greaterEqualCorrect.txt" >> %file%
echo. >> %file%

echo *greaterEqualWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\greaterEqualWrong.txt" >> %file%
echo. >> %file%

:: Equal
echo. >> %file%
echo **Equal Comparisons** >> %file%
echo. >> %file%

echo *equalCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\equalCorrect.txt" >> %file%
echo. >> %file%

echo *equalWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\equalWrong.txt" >> %file%
echo. >> %file%

:: Not Equal
echo. >> %file%
echo **Not Equal Comparisons** >> %file%
echo. >> %file%

echo *NotEqualCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\NotEqualCorrect.txt" >> %file%
echo. >> %file%

echo *NotEqualWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\NotEqualWrong.txt" >> %file%
echo. >> %file%
