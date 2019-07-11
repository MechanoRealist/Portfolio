@echo off
REM This is a dynamic method. However Delayed Expansion is necessary
REM I will try and make it as self learning as possible.

set _acptdvars=StartT#EndT#PathTo
set _debug=0

goto readconfig
REM Entering a local variable environment and reading the config file.

::Using delayed expansion
::ANY variable that needs to change inside the for loop must use ! instead of %
:: Doing LSS comparisons are for whatever reason more stable than GTR comparisons.
:readconfig
setlocal EnableDelayedExpansion
set first=0
set _entrynr=0
set _good=0
set _alrfnd=0
for /F "usebackq eol=; tokens=1,2 delims==" %%A in ("Config.ini") do (
  set /a _entrynr+=1
  set _ReadVar=%%~A
  for %%G in (%_acptdvars:#=,%) do (
    if "%%~G" == "%%~A" set _good=1
  )
  if !_good! LSS 1 (
    call :varierror
  ) else (
  set _good=0
  set _memordt=!_varmemo:#=,!
  for %%V in (!_memordt!) do (
    if "%%~V" == "_%%~A" set _alrfnd=1
  )
  if !_alrfnd! LSS 1 (
    set "_varmemo=!_varmemo!#_%%~A"
	set _%%~A_ctr=1
	) else ( set /a _%%~A_ctr+=1 )
  set _alrfnd=0
  if !first! LSS 1 (
    set _varmemo=!_varmemo:~1!
	set first=1 )
  set "_portstr=!_portstr!,"_%%~A!_%%~A_ctr!=%%~B""
  if %_debug% == 1 (
  set _A=%%~A& set _B=%%~B
  call :Debug
  )
  )
)
for %%O in (!_memordt!) do (
  set "_portstr=!_portstr!,"%%~O_ctr=!%%~O_ctr!""
)
if %_debug% == 1 call :final
endlocal & (
  for %%Z in (%_portstr%) do (
    set %%~Z
  )
  set _varmemo=%_varmemo%
)


:AnStats
REM This an analysis of how many times different variables show up.
REM It also acts as a check against duplicate or missing variables
setlocal EnableDelayedExpansion
set _first=0
set _present=1
set _alrfnd=0
set _BigDatErr=0
for %%I in (%_varmemo:#=,%) do (
  set _valu=!%%I_ctr!
  if 1 NEQ !_valu! (
    for %%V in (!_valdx!) do (
      if "%%~V" == "!_valu!" set _alrfnd=1
	  )
    if !_alrfnd! LSS 1 (
    set "_valdx=!_valdx!,!_valu!"
	set "_n!_valu!stk=1"
	) else ( set /a "_n!_valu!stk+=1" )
	set _alrfnd=0
  )
)
for %%N in (%_valdx%) do (
  set _previous=!_present!
  set _present=!_n%%Nstk!
  if not !_previous! == !_present! (
    if !_previous! LSS !_present! (
      set _mostvar=%%N
    )
  )
)
if not defined _mostvar (
  set _BigDatErr=1
) else (
for %%N in (%_valdx%) do (
  if %%N LSS !_mostvar! (
    for %%I in (%_varmemo:#=,%) do (
	  if %%N == !%%I_ctr! (
        set "_L_errlst=!_L_errlst!,%%I"
	  )
	)
  )
  if !_mostvar! LSS %%N (
    for %%I in (%_varmemo:#=,%) do (
	  if %%N == !%%I_ctr! (
        set "_H_errlst=!_H_errlst!,%%I"
	  )
	)
  )
)
)
endlocal & (
set _mostvar=%_mostvar%
set _L_errlst=%_L_errlst%
set _H_errlst=%_H_errlst%
set _BigDatErr=%_BigDatErr%
)


:Results
REM These are some dynamic ways of reading though the collected data
echo:
if %_BigDatErr% == 1 goto BDataError
echo This is what the program found in the config file
echo:
pause
setlocal EnableDelayedExpansion
for %%G in (%_varmemo:#=,%) do (
echo !%%G_ctr! %%G were found )
echo:
echo Most variables show up %_mostvar% times.
if defined _L_errlst (
  echo:
  echo Variables have been decected that either have missing enties
  echo or are duplicates of special variables, like settings.
  echo List:
  for %%H in (%_L_errlst%) do (
    echo %%H show up only !%%H_ctr! times.
  )
)
if defined _H_errlst (
  echo:
  echo Variables have been detected that are duplicates of data variables.
  echo They must be removed from the config to avoid data mismatch.
  echo List:
  for %%H in (%_H_errlst%) do (
    echo %%H show up !%%H_ctr! times.
  )
)
pause
echo:
for /L %%K in (1,1,%_mostvar%) do (
  for %%L in (%_varmemo:#=,%) do (
    if defined %%L%%K echo %%L%%K is !%%L%%K!
  )
)
endlocal
echo:
pause
exit

REM This will dump all read variables for development purposes
setlocal EnableDelayedExpansion
for %%K in (%_varmemo:#=,%) do (
  for /L %%L in (1,1,!%%K_ctr!) do (
    if defined %%K%%L echo %%K%%L is !%%K%%L!
  )
)
endlocal

:Debug
echo Variable memo is %_varmemo%
echo Export string is %_portstr%
echo Accepted variables is %_acptdvars%
echo Variable counter for %_A% is !_%_A%_ctr!
echo Variable set to %_A%!_%_A%_ctr!=%_B%
echo entrynr is %_entrynr%
pause
echo:
goto :EOF

:final
echo This is the string that is fed to the final extractor at endlocal:
echo %_portstr%
echo And this is the string of variables that were found
echo %_varmemo%
goto :EOF

:BDataError
cls
echo:
color 4f
echo DATA MISMATCH! You done goofed!
echo No variables in the config are of equal frequency.
echo It's all a mess...DOOM I TELL YOU! DOOOOOM!
call :erranim
timeout /T 10 >nul
exit

:varierror
echo:
color 4f
echo WARNING! A variable in config.ini
echo does not have an accepted variable name!
echo It is entry number %_entrynr% Name: %_ReadVar%
call :erranim
pause
color 07
goto :EOF

:erranim
for /L %%z in (1,1,3) do (
pathping localhost -n -q 1 -p 50>nul
color f4
pathping localhost -n -q 1 -p 50>nul
color 4f
)
echo:
goto :EOF