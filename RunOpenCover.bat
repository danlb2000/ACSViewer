REM Remove any previous test execution files to prevent issues overwriting
IF EXIST "%~dp0AcsLib.trx" del "%~dp0AcsLib.trx%"

"%~dp0\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%VSINSTALLDIR%\Common7\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0..\AcsViewer\AcsLibTest\bin\Debug\AcsLibTest.dll\" /resultsfile:\"%~dp0AcsLib.trx\"" ^
-filter:"+[AcsLib*]* -[AcsLibTess]*" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0\GeneratedReports\AcsLib.xml"

"%~dp0\packages\ReportGenerator.2.4.3.0\tools\ReportGenerator.exe" ^
-reports:"%~dp0\GeneratedReports\AcsLib.xml" ^
-targetdir:"%~dp0\GeneratedReports\ReportGenerator Output"

start "report" "%~dp0\GeneratedReports\ReportGenerator Output\index.htm"
