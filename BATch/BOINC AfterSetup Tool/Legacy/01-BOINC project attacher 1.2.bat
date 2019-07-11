@echo off
REM BOINC project attacher v1.2 by MechanoRealist
REM Set your BOINC install directory here:
set boincdir=C:\Software\BOINC
REM Special Syntax is: boinccmd --project_attach WEB_ADR WEAK_ID
REM IMPORTANT!!!: Always move the "set endstop=1" to the last entry of the succession you want to use.
title BOINC project attacher
color 1e
set donefin=0
set remhide=REM
:openmenu
cls
echo  -----------------------------------------------------------------------------
echo  ^|                                                                           ^|
echo  ^|                          BOINC PROJECT ATTACHER                           ^|
echo  ^|                                                                           ^|
echo  -----------------------------------------------------------------------------
echo  ^|                                                                           ^|
echo  ^|                [a] - Attach BOINC account manager                         ^|
echo  ^|                [s] - Continue to attachment of projects                   ^|
echo  ^|                [d] - Open download webpage for BOINC                      ^|
echo  ^|                [f] - Open download webpage for TThrottle                  ^|
echo  ^|                                                                           ^|
echo  ^|                [q] - Exit                                                 ^|
echo  ^|                                                                           ^|
echo  ^|                                                                           ^|
echo  -----------------------------------------------------------------------------
choice /c asdfq /n >nul
if errorlevel 5 exit
if errorlevel 4 (
start "" http://efmer.com/b/?q=tthrottle_download_version
goto openmenu
)
if errorlevel 3 (
start "" https://boinc.berkeley.edu/download.php
goto openmenu
)
if errorlevel 2 (
cls
goto Begin
)
if errorlevel 1 goto accountman

:Begin
ver>nul REM This sets errorlevel to 0
set pjtnr=1
set endstop=0
:prcounting
call :project%pjtnr%
if %ERRORLEVEL% GTR 0 goto whentwrong
if %donefin%==1 (
echo.
echo Project %pjtnr% has been added successfully
pause
echo.
)
if %endstop%==0 (
set /a pjtnr=%pjtnr%+1
goto prcounting
)
if %donefin%==1 goto finished
set remhide=
call :installpath
echo.
echo Welcome to BOINC project attacher.
echo There are %pjtnr% projects that will be added.
echo Press any key to begin.
echo ---------------------------------------------------
echo.
pause >nul
set donefin=1
goto Begin
:finished
echo.
echo ---------------------------------------------------
echo All projects were added without error.
echo Press any key to exit.
pause >nul
exit

:accountman
ver>nul
cls
call :installpath
echo.
echo BOINC manager will be added on keypress.
echo.
pause
boinccmd --join_acct_mgr http://bam.boincstats.com/ 211445_44981ea50dcc3b05253afb14979b9850 ""
echo.
if %ERRORLEVEL% GTR 0 goto bamwrong
echo Command was executed successfully.
echo.
pause
goto openmenu

:installpath
if exist "%programfiles%\BOINC\boinccmd.exe" (
cd /d "%programfiles%\BOINC"
)
if exist "%programfiles(x86)%\BOINC\boinccmd.exe" (
cd /d "%programfiles(x86)%\BOINC"
)
if exist "%boincdir%\boinccmd.exe" (
cd /d "%boincdir%"
) else ( goto nopath )
goto :EOF

:project1
%remhide% boinccmd --project_attach http://asteroidsathome.net/boinc/ 62f15e5221e1d947537bc465ac3b7644
goto :EOF

:project2
%remhide% boinccmd --project_attach http://boinc.bakerlab.org/rosetta/ f986266031acd906444e72fcaddc7bd1
goto :EOF

:project3
%remhide% boinccmd --project_attach http://boinc.fzk.de/poem/ 5256d4c5ef459c5111d846e5803712fa
goto :EOF

:project4
%remhide% boinccmd --project_attach http://boinc.gorlaeus.net/ 4179caa817c76e576bc9b3e998030055
goto :EOF

:project5
%remhide% boinccmd --project_attach http://einstein.phys.uwm.edu/ eaca9477e796994864fd5ab2ec8d135d
goto :EOF

:project6
%remhide% boinccmd --project_attach http://findah.ucd.ie/ f1e737979fde81550b696bca95fa65ef
goto :EOF

:project7
%remhide% boinccmd --project_attach http://milkyway.cs.rpi.edu/milkyway/ 35728df06ebe145bd58c6000f4a0fee9
goto :EOF

:project8
%remhide% boinccmd --project_attach https://numberfields.asu.edu/NumberFields/ c3493183a748bbcc85f33fe92284c1e3
goto :EOF

:project9
%remhide% boinccmd --project_attach http://pogs.theskynet.org/pogs/ 3dc03f3f339c2a3e54dd0f5bee15a9c3
goto :EOF

:project10
%remhide% boinccmd --project_attach http://sat.isa.ru/pdsat/ 7f1b6c8f4bf36f75de83152b1112e600
goto :EOF
11
:project11
%remhide% boinccmd --project_attach http://universeathome.pl/universe/ 9d391b5184ea7333eadf540402a0c45a
goto :EOF

:project12
%remhide% boinccmd --project_attach http://www.malariacontrol.net/ 8f782f4504bd693df5342460586027af
goto :EOF

:project13
%remhide% boinccmd --project_attach http://www.worldcommunitygrid.org 07e74f566c4fae1bdd1d187045089d46
set endstop=1
goto :EOF

:whentwrong
color f4
echo Something is wrong with project %pjtnr% !
echo Application will now terminate.
pause
exit

:bamwrong
color f4
echo Something whent wrong when trying to add the account manager !
echo Application will now terminate.
pause
exit

:nopath
color f4
echo The application can not find boinccmd.exe!
echo Please check that the correct directory is being selected.
echo Application will now terminate.
pause
exit