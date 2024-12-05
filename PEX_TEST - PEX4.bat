:: Creates a Variable for the Output File
@SET file="pex4_test_results.txt"

:: Erases Everything Currently In the Output File
type NUL>%file%

:: ----------------------------------------
:: TITLE
:: ----------------------------------------
echo PEX4 TEST CASES >> %file%

echo *test1.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex4\test1.txt" >> %file%
echo. >> %file%

echo *test2.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex4\test2.txt" >> %file%
echo. >> %file%

echo *test3.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex4\test3.txt" >> %file%
echo. >> %file%

echo *test4.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex4\test4.txt" >> %file%
echo. >> %file%

echo *test5.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex4\test5.txt" >> %file%
echo. >> %file%

echo *test6.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex4\test6.txt" >> %file%
echo. >> %file%

echo *test7.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex4\test7.txt" >> %file%
echo. >> %file%

echo *test8.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex4\test8.txt" >> %file%
echo. >> %file%

echo *test9.txt >> %file%
bin\Debug\ConsoleApplication.exe "testcases\pex4\test9.txt" >> %file%
echo. >> %file%