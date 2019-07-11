@echo off
set workdir=%userprofile%\Pictures

color 4e
title Find string in files' name
cd /d %workdir%
:blank
cls
echo Working in: %CD%
set itemcount=0

:openmenu
echo  [s] Search
echo  [d] Clear screen
echo  [q] Exit
echo:
choice /c sdq >nul
if ERRORLEVEL 3 exit
if ERRORLEVEL 2 goto blank
if ERRORLEVEL 1 goto search


:search
setlocal EnableDelayedExpansion
set /p thatword=Search for: 
echo:
echo Result:
dir /b | find /I /N "%thatword%"
for /F "delims=[] tokens=1,2" %%G in ('dir /b ^| find /I /N "%thatword%"') do (
  set /a itemcount+=1
  set foundex%%G=%%H
  if !itemcount! LSS 2 set nopick=%%H
)
if %itemcount% LSS 1 (
echo Nothing with this string was found.
goto end
)
echo:
echo %itemcount% items were found
choice /M "Open file?"
if ERRORLEVEL 2 goto end
if ERRORLEVEL 1 goto pickfile

:pickfile
if %itemcount% LSS 2 (
start "" "%workdir%\%nopick%"
goto end
)
set /p thefile=Enter file number: 
if not defined foundex%thefile% (
echo "[#]" denotes the file number
echo The entered file number is not present in the current search. Try again.
goto pickfile
)
echo Opening "!foundex%thefile%!"
start "" "%workdir%\!foundex%thefile%!"
:end
endlocal
echo --------------------------------------------------
echo:
goto openmenu