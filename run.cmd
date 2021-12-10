@echo off
IF "%2" == "" GOTO HELP

serverless invoke local -f viewspots -d "{\"filename\": \"%1\", \"viewPointCount\": %2}"
GOTO END

:HELP
echo:
echo Usage: run.cmd ^<mesh file.json^> ^<number of viewpoints^>
echo:

:END
