:: Creates a Variable for the Output File
@SET file="pex_test_results.txt"

:: Erases Everything Currently In the Output File
type NUL>%file%

:: ----------------------------------------
:: TITLE
:: ----------------------------------------
echo PEX TEST CASES (C1C Unnamed) >> %file%

:: ----------------------------------------
:: Main Structure
:: ----------------------------------------
echo. >> %file%
echo **main structure** >> %file%
echo. >> %file%

echo *main - good.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\main - good.txt" >> %file%
echo. >> %file%

echo *main - invalid 1.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\main - invalid 1.txt" >> %file%
echo. >> %file%

echo *main - invalid 2.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\main - invalid 2.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Variable and Constant Declarations
:: ----------------------------------------
echo. >> %file%
echo **Variable and Constant Declarations** >> %file%
echo. >> %file%

echo *var dec - good.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\var dec - good.txt" >> %file%
echo. >> %file%

echo *var dec - invalid 1.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\var dec - invalid 1.txt" >> %file%
echo. >> %file%

echo *var dec - invalid 2.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\var dec - invalid 2.txt" >> %file%
echo. >> %file%

echo *var dec - invalid 3.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\var dec - invalid 3.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Conditional Statements (IFs)
:: ----------------------------------------
echo. >> %file%
echo **Conditional Statements (IFs)** >> %file%
echo. >> %file%

echo *conditional - good.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\conditional - good.txt" >> %file%
echo. >> %file%

echo *conditional - invalid 1.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\conditional - invalid 1.txt" >> %file%
echo. >> %file%

echo *conditional - invalid 2.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\conditional - invalid 2.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Iterative Statements (LOOPs)
:: ----------------------------------------
echo. >> %file%
echo **Iterative Statements (LOOPs)** >> %file%
echo. >> %file%

echo *conditional - good.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\loop - good.txt" >> %file%
echo. >> %file%

echo *conditional - invalid 1.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\loop - invalid 1.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Assignment Statements
:: ----------------------------------------
echo. >> %file%
echo **Assignment Statements (LOOPs)** >> %file%
echo. >> %file%

echo *conditional - good.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\assignment - good.txt" >> %file%
echo. >> %file%

echo *conditional - invalid 1.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\assignment - invalid 1.txt" >> %file%
echo. >> %file%

echo *conditional - invalid 2.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\assignment - invalid 2.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: function declarations w/ formal parameters
:: ----------------------------------------
echo. >> %file%
echo **function declarations w/ formal parameters** >> %file%
echo. >> %file%

echo *func defs - good.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\func defs - good.txt" >> %file%
echo. >> %file%

echo *func defs - invalid 1.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\func defs - invalid 1.txt" >> %file%
echo. >> %file%

echo *func defs - invalid 2.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\func defs - invalid 2.txt" >> %file%
echo. >> %file%

echo *func defs - invalid 3.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\func defs - invalid 3.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: function calls w/ actual parameters
:: ----------------------------------------
echo. >> %file%
echo **function calls w/ actual parameters** >> %file%
echo. >> %file%

echo *func defs - good.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex2\func calls - good.txt" >> %file%
echo. >> %file%