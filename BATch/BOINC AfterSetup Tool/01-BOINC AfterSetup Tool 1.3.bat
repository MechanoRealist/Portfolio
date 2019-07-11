@echo off
REM BOINC AfterSetup Tool v1.3 by MechanoRealist
REM Registry data extraction syntax: "call :getreg key_path registry_value output_variable"
color 1e
title BOINC AfterSetup Tool
set _defaultkey="HKLM\SOFTWARE\Space Sciences Laboratory, U.C. Berkeley\BOINC Setup"
set _debug=0
if not exist config.ini goto noConfig
set _acptdvars=pjt#accman#rpcpass#remohost
set _CrProgPath=%CD%
if exist "%CD%\remote_hosts.cfg" (
  set _RHcfgPres=1
) else ( set _RHcfgPres=0 )

call :getreg %_defaultkey% DATADIR _DataPath
call :getreg %_defaultkey% INSTALLDIR _InstallPath

call :readconfig

:openmenu
cls
echo  -----------------------------------------------------------------------------
echo  ^|                                                                           ^|
echo  ^|                          BOINC AFTERSETUP TOOL                            ^|
echo  ^|                                                                           ^|
echo  -----------------------------------------------------------------------------
echo  ^|                                                                           ^|
echo  ^|                [a] - Attach BOINC account manager                         ^|
echo  ^|                [s] - Continue to attachment of projects                   ^|
echo  ^|                [d] - Setup remote control                                 ^|
echo  ^|                [f] - Install cc_config.xml                                ^|
echo  ^|                [z] - Open download webpage for BOINC                      ^|
echo  ^|                [x] - Open download webpage for TThrottle                  ^|
echo  ^|                                                                           ^|
echo  ^|                [q] - Exit                                                 ^|
echo  ^|                                                                           ^|
echo  ^|                                                                           ^|
echo  -----------------------------------------------------------------------------
choice /c asdfzxq /n >nul
if errorlevel 7 exit
if errorlevel 6 (
start "" http://efmer.com/b/?q=tthrottle_download_version
goto openmenu
)
if errorlevel 5 (
start "" https://boinc.berkeley.edu/download.php
goto openmenu
)
if errorlevel 4 goto BoincConf
if errorlevel 3 goto RemoteCtrl
if errorlevel 2 goto ProjAttach
if errorlevel 1 goto accountman

:accountman
ver>nul REM This sets errorlevel to 0
cls
if not defined _accman1 goto missacm
call :instp
echo:
echo BOINC manager will be added on keypress.
echo:
pause
boinccmd --join_acct_mgr %_accman1% ""
echo:
if %ERRORLEVEL% GTR 0 goto bamwrong
echo Command was executed successfully.
echo:
pause
goto openmenu


:ProjAttach
setlocal EnableDelayedExpansion
cls
ver>nul
set _count_err=0
call :instp
echo:
echo Welcome to BOINC project attacher.
echo There are %_pjt_ctr% projects that will be added.
echo Press any key to begin.
echo ---------------------------------------------------
echo:
pause >nul
for /L %%G in (1,1,%_pjt_ctr%) do (
  call :AddPjt %%G
)
goto finatch

:AddPjt
boinccmd --project_attach !_pjt%1!
if %ERRORLEVEL% GTR 0 (
  call :whentwrong %1
) else (
echo:
echo Project %1 has been added successfully
pause
echo:
)
goto :EOF

:finatch
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

:RemoteCtrl
ver>nul
cls
echo:
echo Welcome to Remote Control establishment.
if %_RHcfgPres% == 1 (
echo A remote_hosts.cfg was found with the program.
echo It will be copied to the Data directory.
) else (
echo No remote_hosts.cfg was present.
echo The Config will be searched for remote host entries.
)
echo:
echo Press any key to begin.
echo ---------------------------------------------------
echo:
pause>nul
if exist "%_DataPath%" ( cd /d "%_DataPath%") else ( goto noDpath)
if not defined _rpcpass1 call :genmissvar rpcpass
if %_RHcfgPres% == 0 (
  if not defined _remohost_ctr call :genmissvar remohost
)
if exist gui_rpc_auth.cfg del gui_rpc_auth.cfg
echo %_rpcpass1%>>gui_rpc_auth.cfg
if %_RHcfgPres% == 1 (
copy /Y "%_CrProgPath%\remote_hosts.cfg" remote_hosts.cfg
)
if %_RHcfgPres% == 0 (
  if exist remote_hosts.cfg del remote_hosts.cfg
  setlocal EnableDelayedExpansion
  for /L %%H in (1,1,%_remohost_ctr%) do (
    echo !_remohost%%H!>>remote_hosts.cfg
  )
  endlocal
)
echo The operation has been performed.
echo:
echo Press any key to return to main.
pause>nul
endlocal
goto openmenu
:BoincConf
ver>nul
cls
echo:
if not exist "%_CrProgPath%\cc_config.xml" (
  echo You must provide a cc_config.xml in the batch program folder to use this element.
  pause
  goto openmenu
)
if exist %_DataPath% ( cd /d %_DataPath%) else ( goto noDpath)
copy /Y "%_CrProgPath%\cc_config.xml" cc_config.xml
echo cc_config.xml has been copied to BOINC Data directory
echo:
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


::Below this is only error conditions -----------------------------------------------------------------------

:whentwrong
color f4
echo Something is wrong with project %1 !
echo !pjt%1!
echo You may have to add it manually
call :erranim
set /a _count_err+=1
pause
color 1e
goto :EOF

:bamwrong
color f4
echo Something whent wrong when trying to add the account manager !
echo Application will now terminate.
call :erranim
pause
exit

:missacm
color f4
echo No account manager was found in the config.
echo Please add accman variable to the config and provide account info.
call :erranim
pause
goto openmenu

:noIpath
color f4
echo The application can not find boinccmd.exe!
echo Please check that the correct directory is being selected.
echo Application will now terminate.
call :erranim
pause
exit

:noDpath
color f4
echo The application can not find BOINC's Data directory!
echo Please check that the correct directory is being selected.
echo Application will now terminate.
call :erranim
pause
exit

:genmissvar
color f4
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