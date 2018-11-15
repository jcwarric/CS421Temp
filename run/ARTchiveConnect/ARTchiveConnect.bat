@ECHO OFF
ECHO.------------------------
ECHO - ARTchiveConnect.bat  -
ECHO.------------------------
ECHO.
SET /P username="Enter your SVSU Username: "
SET serverName=10.8.30.21
SET portNumber=1433
SET forwardedPort=%portNumber%
ECHO.
plink.exe -v -x -a -T -C -noagent -ssh -L 127.0.0.1:%forwardedPort%:%serverName%:%portNumber% %username%@csis.svsu.edu
