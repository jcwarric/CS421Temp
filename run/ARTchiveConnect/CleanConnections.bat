@ECHO OFF
ECHO.------------------------
ECHO - CleanConnections.bat -
ECHO.------------------------
ECHO.
SET /P username="Enter your SVSU Username: "
ECHO.
plink.exe -ssh %username%@csis.svsu.edu pkill -u %username%
ECHO.
ECHO Connections closed.
ECHO.
PAUSE
