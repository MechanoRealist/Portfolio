@echo off
REM Registry data extraction syntax: "call :getreg key_path registry_value output_variable"
color 1e
title Test Environment
set _defaultkey="HKLM\SOFTWARE\Space Sciences Laboratory, U.C. Berkeley\BOINC Setup"
set _debug=0
if not exist config.ini goto noConfig
set _acptdvars1=pjt#accman#rpcpass#remohost
set _acptdvars2=url#email
set _CrProgPath=%CD%
if exist "%CD%\remote_hosts.cfg" (
  set _RHcfgPres=1
) else ( set _RHcfgPres=0 )

call :getreg %_defaultkey% DATADIR _DataPath
call :getreg %_defaultkey% INSTALLDIR _InstallPath

call :readconfig Config.ini _acptdvars1
call :readconfig ProjectURLs.ini _acptdvars2

call :checkcore

:openmenu
cls
echo  -----------------------------------------------------------------------------
echo  ^|                                                                           ^|
echo  ^|                          Test environment                            ^|
echo  ^|                                                                           ^|
echo  -----------------------------------------------------------------------------
echo  ^|                                                                           ^|
echo  ^|                [a] - something to test                         ^|
echo  ^|                [s] - check variables                   ^|
echo  ^|                [d] - Nothing                                 ^|
echo  ^|                [f] - Nothing                                ^|
echo  ^|                [z] - Nothing                      ^|
echo  ^|                [x] - Nothing                  ^|
echo  ^|                                                                           ^|
echo  ^|                [q] - Exit                                                 ^|
echo  ^|                                                                           ^|
echo  ^|                                                                           ^|
echo  -----------------------------------------------------------------------------
choice /c asdfzxq /n >nul
if errorlevel 7 exit
if errorlevel 6 goto nothing
if errorlevel 5 goto nothing
if errorlevel 4 goto nothing
if errorlevel 3 goto nothing
if errorlevel 2 goto dumpvar
if errorlevel 1 goto lookup

:nothing
echo This does nothing.
pause>nul
goto openmenu


:lookup
setlocal EnableDelayedExpansion
cls
ver>nul
set _count_err=0
call :instp
echo:
echo Welcome to BOINC Weak key fetcher.
echo There are %_url_ctr% URLs that will be checked.
echo It is the account %_email1% that will be used.
echo ---------------------------------------------------
echo:
set /P _assgndpswrd=Enter the password for the account: 
if not defined _assgndpswrd goto noPass

for /L %%G in (1,1,%_url_ctr%) do (
  call :keylookup %%G
)
echo:
echo Finished...
endlocal
pause
goto openmenu

:keylookup
for /F "tokens=2 delims=:" %%K in (
  'boinccmd --lookup_account !_url%1! %_email1% %_assgndpswrd% ^|find "account key"') do (
    echo %%K
  )

::pause
echo:

goto :EOF







:finlook
echo ---------------------------------------------------
set /a _finproj=%_pjt_ctr%-%_count_err%
if %_count_err% LSS 1 (
echo All projects were added without error.
) else (
echo %_finproj% projects were added without error.
echo %_count_err% errored out.
)
echo Press any key to return to main.
pause>nul
endlocal
goto openmenu



:dumpvar
REM This will dump all read variables for development purposes
setlocal EnableDelayedExpansion
for %%K in (%_varmemo:#=,%) do (
  for /L %%L in (1,1,!%%K_ctr!) do (
    if defined %%K%%L echo %%K%%L is !%%K%%L!
  )
)
endlocal
pause
goto openmenu


:getreg
setlocal
set _rkey=%1
set _regvalname=%2
:: The next line is not redundant! It is vital for errorlevel!
reg query %_rkey% /v %_regvalname%>nul
if %ERRORLEVEL% GTR 0 ( call :ValNotFound
) else (
for /f "tokens=2*" %%A in ('reg query %_rkey% /v %_regvalname% ^|find "%_regvalname%"') do set _A=%%~B)
endlocal & set %3=%_A%
goto :EOF


:readconfig
setlocal EnableDelayedExpansion
set first=0
set _entrynr=0
set _good=0
set _alrfnd=0
set _acptdvars=!%2!
for /F "usebackq eol=; tokens=1,2 delims==" %%A in ("%1") do (
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
  )
)
for %%O in (!_memordt!) do (
  set "_portstr=!_portstr!,"%%~O_ctr=!%%~O_ctr!""
)
endlocal & (
  for %%Z in (%_portstr%) do (
    set %%~Z
  )
  set _varmemo=%_varmemo%
)
goto :EOF



:instp
if exist "%_InstallPath%boinccmd.exe" (
cd /d "%_InstallPath%"
) else ( goto noIpath )
goto :EOF

:checkcore
tasklist |find "boinc.exe"
if %ERRORLEVEL% GTR 0 (
  "%_InstallPath%boinc.exe" --detach_console
)
goto :EOF

::Below this is only error conditions -----------------------------------------------------------------------

:genwrong


:whentwrong
color 4f
echo Something is wrong with project %1 !
echo !pjt%1!
echo You may have to add it manually
call :erranim
set /a _count_err+=1
pause
color 1e
goto :EOF

:bamwrong
color 4f
echo Something whent wrong when trying to add the account manager !
echo Application will now terminate.
call :erranim
pause
exit

:missacm
color 4f
echo No account manager was found in the config.
echo Please add accman variable to the config and provide account info.
call :erranim
pause
goto openmenu

:noIpath
color 4f
echo The application can not find boinccmd.exe!
echo Please check that the correct directory is being selected.
echo Application will now terminate.
call :erranim
pause
exit

:noDpath
color 4f
echo The application can not find BOINC's Data directory!
echo Please check that the correct directory is being selected.
echo Application will now terminate.
call :erranim
pause
exit

:noPass
color 4f
echo WARNING Password can not be empty!
call :erranim
pause
goto openmenu

:genmissvar
color 4f
echo There is no %1 variable in the config.
echo The variable is vital for the function of this element.
echo Please add it to the config and make sure it is correctly formatted.
echo Application will now terminate.
call :erranim
pause
exit

:ValNotFound
echo:
color 4f
echo ERROR! Registry value %_regvalname% was not found!
echo Is BOINC installed on this computer?
echo Application will continue on input
call :erranim
pause
color 1e
goto :EOF

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

:noConfig
cls
echo:
echo Hello! It has been detected that there is no Config.ini .
echo The application has very limited functionality without a config.
echo:
echo If this is the first run time, or the config has somehow become lost,
echo you might wish to generate a generic Config.ini?
choice
if errorlevel 2 goto dealwithit
if errorlevel 1 goto generatic

:dealwithit
echo:
echo Please place the config together with the Batch application.
echo Application will now terminate.
pause
exit

:generatic
echo ;This is a BOINC AfterSetup Tool config file.>>Config.ini
echo ;The compatiable variables are: rpcpass remohost accman pjt>>Config.ini
echo:>>Config.ini
echo ;GUI RPC password for remote control>>Config.ini
echo rpcpass=YourRPCPasswordHere>>Config.ini
echo:>>Config.ini
echo ;Remote hosts to allow access>>Config.ini
echo ;Usually IPs on your LAN>>Config.ini
echo remohost=192.168.x.x>>Config.ini
echo:>>Config.ini
echo remohost=192.168.x.x>>Config.ini
echo:>>Config.ini
echo remohost=192.168.x.x>>Config.ini
echo:>>Config.ini
echo ;Account manager credentials to attach BAM or similar to BOINC Manager>>Config.ini
echo ;Special Syntax is: accman=WEB_ADR ACC_NAME PASSWORD>>Config.ini
echo accman=http://bam.boincstats.com/ username password>>Config.ini
echo:>>Config.ini
echo ;BOINC Projects using weak IDs>>Config.ini
echo ;Special Syntax is: pjt=WEB_ADR WEAK_ID>>Config.ini
echo pjt=http://somescienceproject.org/ weakid1>>Config.ini
echo:>>Config.ini
echo pjt=http://otherscienceproject.net/ weakid2>>Config.ini
echo:>>Config.ini
echo pjt=http://coolscience.edu/ weakid3>>Config.ini
echo:
echo A generic Config.ini should have been generated now.
echo Remember to edit it to your specifications.
echo:
echo Application will now terminate.
echo:
pause
exit