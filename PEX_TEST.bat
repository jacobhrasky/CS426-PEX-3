:: Creates a Variable for the Output File
@SET file="pex3_test_results.txt"

:: Erases Everything Currently In the Output File
type NUL>%file%

:: ----------------------------------------
:: TITLE
:: ----------------------------------------
echo PEX3 TEST CASES >> %file%

:: ----------------------------------------
:: Declarations
:: ----------------------------------------
echo *declarationCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\declarationCorrect.txt" >> %file%
echo. >> %file%

echo *declarationWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\declarationWrong.txt" >> %file%
echo. >> %file%

echo *varDeclarationCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\varDeclarationCorrect.txt" >> %file%
echo. >> %file%

echo *varDeclarationWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\varDeclarationWrong.txt" >> %file%
echo. >> %file%

echo *paramDeclarationCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\paramDeclarationCorrect.txt" >> %file%
echo. >> %file%

echo *paramDeclarationWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\paramDeclarationWrong.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Constants
:: ----------------------------------------
echo *constDeclarationCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\constDeclarationCorrect.txt" >> %file%
echo. >> %file%

echo *constDeclarationWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\constDeclarationWrong.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: If and While Statements
:: ----------------------------------------
echo *ifCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\ifCorrect.txt" >> %file%
echo. >> %file%

echo *ifWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\ifWrong.txt" >> %file%
echo. >> %file%

echo *whileCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\whileCorrect.txt" >> %file%
echo. >> %file%

echo *whileWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\whileWrong.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Arithmetic Operations
:: ----------------------------------------
echo *plusCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\plusCorrect.txt" >> %file%
echo. >> %file%

echo *plusWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\plusWrong.txt" >> %file%
echo. >> %file%

echo *subCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\subCorrect.txt" >> %file%
echo. >> %file%

echo *subWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\subWrong.txt" >> %file%
echo. >> %file%

echo *multCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\multCorrect.txt" >> %file%
echo. >> %file%

echo *multWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\multWrong.txt" >> %file%
echo. >> %file%

echo *divideCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\divideCorrect.txt" >> %file%
echo. >> %file%

echo *divideWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\divideWrong.txt" >> %file%
echo. >> %file%

echo *negationCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\negationCorrect.txt" >> %file%
echo. >> %file%

echo *negationWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\negationWrong.txt" >> %file%
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

echo *boolAndCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolAndCorrect.txt" >> %file%
echo. >> %file%

echo *boolAndWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolAndWrong.txt" >> %file%
echo. >> %file%

echo *boolOrCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolOrCorrect.txt" >> %file%
echo. >> %file%

echo *boolOrWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolOrWrong.txt" >> %file%
echo. >> %file%

echo *boolNotCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolNotCorrect.txt" >> %file%
echo. >> %file%

echo *boolNotWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolNotWrong.txt" >> %file%
echo. >> %file%

echo *boolParensCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolParensCorrect.txt" >> %file%
echo. >> %file%

echo *boolParensWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolParensWrong.txt" >> %file%
echo. >> %file%

echo *boolEqualCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolEqualCorrect.txt" >> %file%
echo. >> %file%

echo *boolEqualWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\boolEqualWrong.txt" >> %file%
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

echo *lessCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\lessCorrect.txt" >> %file%
echo. >> %file%

echo *lessWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\lessWrong.txt" >> %file%
echo. >> %file%

echo *lessEqualCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\lessEqualCorrect.txt" >> %file%
echo. >> %file%

echo *lessEqualWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\lessEqualWrong.txt" >> %file%
echo. >> %file%

echo *greaterCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\greaterCorrect.txt" >> %file%
echo. >> %file%

echo *greaterWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\greaterWrong.txt" >> %file%
echo. >> %file%

echo *greaterEqualCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\greaterEqualCorrect.txt" >> %file%
echo. >> %file%

echo *greaterEqualWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\greaterEqualWrong.txt" >> %file%
echo. >> %file%

echo *equalCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\equalCorrect.txt" >> %file%
echo. >> %file%

echo *equalWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\equalWrong.txt" >> %file%
echo. >> %file%

echo *NotEqualCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\NotEqualCorrect.txt" >> %file%
echo. >> %file%

echo *NotEqualWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\NotEqualWrong.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Assignment Statements
:: ----------------------------------------
echo *assignCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\assignCorrect.txt" >> %file%
echo. >> %file%

echo *assignWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\assignWrong.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Function Declarations
:: ----------------------------------------
echo *funcDeclarationCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\funcDeclarationCorrect.txt" >> %file%
echo. >> %file%

echo *funcDeclarationWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\funcDeclarationWrong.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Function Calls
:: ----------------------------------------
echo *funcCallCorrect.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\funcCallCorrect.txt" >> %file%
echo. >> %file%

echo *funcCallWrong.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex3\funcCallWrong.txt" >> %file%
echo. >> %file%