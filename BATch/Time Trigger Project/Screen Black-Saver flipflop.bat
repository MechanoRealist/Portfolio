@echo off
set BATchDir=%CD%
set _debug=1
set _acptdvars=StartT#EndT#PathTo
set _linenr=0
set _good=0
set _inilinecount=0
set _JobCount=1
REM Entering a local variable environment and reading the config file.
:readconfig
setlocal
for /F "usebackq eol=; tokens=1,2 delims==" %%A in ("Config.ini") do (
  set _A=%%~A
  set _B=%%~B
  call :configvars
)
if "%_portstr:~0,1%" == "," set _portstr=%_portstr:~1%
endlocal & (
  for %%Z in (%_portstr%) do (
    set %%~Z
  )
  set _JobCount=%_JobCount%
)
call :Results
pause

exit

:configvars
  set /a _linenr+=1
  for %%G in (%_acptdvars:#=,%) do (
    if %%G == %_A% set _good=1
  )
  if %_good% LSS 1 (
    call :varierror
	goto :EOF
  )
  set _good=0
  set %_A%%_JobCount%=%_B%
  set /a _inilinecount+=1
  if %_inilinecount% GTR 3 (
    set /a _JobCount+=1
    set _inilinecount=1
  )
  set "_portstr=%_portstr%,"%_A%%_JobCount%=%_B%""
  if %_debug% == 1 call :Debug
goto :EOF

:Results
echo:
echo JobCount is %_JobCount%
echo StartT1 is %StartT1%
echo EndT1 is %EndT1%
echo PathTo1 is %PathTo1%
echo StartT2 is %StartT2%
echo EndT2 is %EndT2%
echo PathTo2 is %PathTo2%
echo StartT3 is %StartT3%
echo EndT is %EndT3%
echo PathTo3 is %PathTo3%
echo:
goto :EOF

:varierror
echo WARNING! A variable in config.ini line %_linenr%
echo does not have an accepted variable name!
call :erranim
pause
color 07
goto :EOF

:erranim
color 4f
for /L %%z in (1,1,3) do (
pathping localhost -n -q 1 -p 50>nul
color f4
pathping localhost -n -q 1 -p 50>nul
color 4f
)
echo:
goto :EOF

:Debug
echo Export string is %_portstr%
echo Accepted variables is %_acptdvars%
echo Variable set to %_A%%_JobCount%=%_B%
echo linenr is %_linenr%
echo JobCount is %_JobCount%
echo inilinecount is %_inilinecount%
pause
echo:
goto :EOF
------------------------------------------------------------------------------------------------
echo:
for /f "tokens=1-3 delims=:" %%a in ("%time%") do if %%a geq 7 if %%a leq 18 echo hello
echo:
pause

