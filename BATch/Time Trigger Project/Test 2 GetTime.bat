@echo off
REM Using code from SS64 GetTime.cmd
goto jump

SETLOCAL
For /f "tokens=1-3 delims=1234567890 " %%a in ("%time%") Do set "delims=%%a%%b%%c"
For /f "tokens=1-4 delims=%delims%" %%G in ("%time%") Do (
  Set _hh=%%G
  Set _min=%%H
  Set _ss=%%I
  Set _ms=%%J
)
:: Strip any leading spaces
Set _hh=%_hh: =%
:: Ensure the hours have a leading zero
if 1%_hh% LSS 20 Set _hh=0%_hh%
Echo The time is:   %_hh%:%_min%:%_ss%
ENDLOCAL&Set _time=%_hh%:%_min%
pause
exit

:jump
:: Use this: Edited by MechanoRealist
SETLOCAL
For /f "tokens=1-3 delims=1234567890 " %%a in ("%time%") Do set "delims=%%a%%b%%c"
For /f "tokens=1-4 delims=%delims%" %%G in ("%time%") Do (
  Set thh=%%G
  Set tmin=%%H
  Set tss=%%I
  Set ths=%%J
)
:: Strip any leading spaces
Set thh=%thh: =%
ENDLOCAL& (
  Set nowhh=%thh%
  Set nowmin=%tmin%
  Set nowss=%tss%
  Set nowhs=%ths%
)
echo:
echo Time is %nowhh%:%nowmin%:%nowss%,%nowhs%
echo:
pause
exit


