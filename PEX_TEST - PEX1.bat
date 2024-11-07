:: Creates a Variable for the Output File
@SET file="pex_test_results.txt"

:: Erases Everything Currently In the Output File
type NUL>%file%

:: ----------------------------------------
:: TITLE
:: ----------------------------------------
echo PEX TEST CASES (C1C Unnamed) >> %file%

:: ----------------------------------------
:: TOY LANGUAGE
:: ----------------------------------------
echo. >> %file%
echo **Testing Toy Language** >> %file%
echo. >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex1\Toy Language Test.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Floats
:: ----------------------------------------
echo. >> %file%
echo **Testing Floats** >> %file%
echo. >> %file%

echo *Floats - Valid.txt>> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex1\Floats - Valid.txt" >> %file%
echo. >> %file%

echo *Floats - Invalid 1.txt>> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex1\Floats - Invalid 1.txt" >> %file%
echo. >> %file%

echo *Floats - Invalid 2.txt>> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex1\Floats - Invalid 2.txt" >> %file%
echo. >> %file%

echo *Floats - Invalid 3.txt>> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex1\Floats - Invalid 3.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: Strings
:: ----------------------------------------
echo. >> %file%
echo **Testing Strings** >> %file%
echo. >> %file%

echo *Strings - Valid.txt>> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex1\Strings - Valid.txt" >> %file%
echo. >> %file%

echo *Strings - Invalid 1.txt>> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex1\Strings - Invalid 1.txt" >> %file%
echo. >> %file%

echo *Strings - Invalid 2.txt>> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex1\Strings - Invalid 2.txt" >> %file%
echo. >> %file%

:: ----------------------------------------
:: IDs
:: ----------------------------------------
echo. >> %file%
echo **Testing IDs** >> %file%
echo. >> %file%

echo *IDs - Valid.txt>> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex1\IDs - Valid.txt" >> %file%
echo. >> %file%

echo *IDs - Invalid.txt>> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex1\IDs - Invalid.txt" >> %file%
echo. >> %file%

pause